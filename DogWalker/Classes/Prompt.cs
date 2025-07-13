using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace DogWalker.UI.Classes
{
    public static class Prompt
    {
        public static Dictionary<string, string> ShowMultiFieldDialog(
            Dictionary<string, string> fields,
            string title,
            Dictionary<string, List<string>> comboOptions = null)
        {
            var form = new Form()
            {
                Width = 420,
                Height = fields.Count * 40 + 100,
                FormBorderStyle = FormBorderStyle.FixedDialog,
                Text = title,
                StartPosition = FormStartPosition.CenterParent
            };

            var controls = new Dictionary<string, Control>();

            int top = 20;
            foreach (var field in fields)
            {
                var label = new Label() { Left = 20, Top = top + 3, Text = field.Key, Width = 120 };
                Control input;

                if (comboOptions != null && comboOptions.ContainsKey(field.Key))
                {
                    var combo = new ComboBox()
                    {
                        Left = 150,
                        Top = top,
                        Width = 200,
                        DropDownStyle = ComboBoxStyle.DropDownList
                    };
                    combo.Items.AddRange(comboOptions[field.Key].ToArray());
                    combo.SelectedItem = field.Value;
                    input = combo;
                }
                else if (field.Key.ToLower().Contains("date"))
                {
                    var dtp = new DateTimePicker()
                    {
                        Left = 150,
                        Top = top,
                        Width = 200,
                        Format = DateTimePickerFormat.Custom,
                        CustomFormat = "yyyy-MM-dd"
                    };

                    if (DateTime.TryParse(field.Value, out var dt))
                        dtp.Value = dt;

                    input = dtp;
                }
                else
                {
                    input = new TextBox()
                    {
                        Left = 150,
                        Top = top,
                        Width = 200,
                        Text = field.Value
                    };
                }

                form.Controls.Add(label);
                form.Controls.Add(input);
                controls[field.Key] = input;
                top += 35;
            }

            var buttonOk = new Button() { Text = "OK", Left = 150, Width = 100, Top = top + 10, DialogResult = DialogResult.OK };
            var buttonCancel = new Button() { Text = "Cancel", Left = 260, Width = 100, Top = top + 10, DialogResult = DialogResult.Cancel };

            form.Controls.Add(buttonOk);
            form.Controls.Add(buttonCancel);
            form.AcceptButton = buttonOk;
            form.CancelButton = buttonCancel;

            if (form.ShowDialog() != DialogResult.OK)
                return null;

            var result = new Dictionary<string, string>();
            foreach (var kvp in controls)
            {
                if (kvp.Value is TextBox txt)
                    result[kvp.Key] = txt.Text.Trim();
                else if (kvp.Value is DateTimePicker dtp)
                    result[kvp.Key] = dtp.Value.ToString("yyyy-MM-dd");
                else if (kvp.Value is ComboBox cmb)
                    result[kvp.Key] = cmb.SelectedItem?.ToString();
            }

            return result;
        }
    }
}
