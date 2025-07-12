using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace DogWalker.UI.Classes
{
    public static class Prompt
    {
        public static Dictionary<string, string> ShowMultiFieldDialog(Dictionary<string, string> fields, string title)
        {
            var result = new Dictionary<string, string>();

            Form prompt = new Form()
            {
                Width = 400,
                Height = 70 + (fields.Count * 40),
                Text = title,
                StartPosition = FormStartPosition.CenterParent,
                FormBorderStyle = FormBorderStyle.FixedDialog,
                MaximizeBox = false,
                MinimizeBox = false
            };

            int top = 20;
            var textBoxes = new Dictionary<string, TextBox>();

            foreach (var field in fields)
            {
                var label = new Label() { Left = 10, Top = top, Text = field.Key, Width = 120 };
                var textBox = new TextBox() { Left = 140, Top = top - 3, Width = 220, Text = field.Value ?? "" };

                prompt.Controls.Add(label);
                prompt.Controls.Add(textBox);

                textBoxes[field.Key] = textBox;
                top += 35;
            }

            var btnOk = new Button()
            {
                Text = "OK",
                Left = 280,
                Width = 80,
                Top = top,
                DialogResult = DialogResult.OK
            };

            prompt.Controls.Add(btnOk);
            prompt.AcceptButton = btnOk;

            if (prompt.ShowDialog() == DialogResult.OK)
            {
                foreach (var kvp in textBoxes)
                {
                    result[kvp.Key] = kvp.Value.Text.Trim();
                }
                return result;
            }

            return null; // cancelled
        }
    }
}
