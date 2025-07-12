using DogWalker.Core.Entities;
using DogWalker.Core.Interfaces;
using DogWalker.UI.Classes;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace DogWalker.UI
{
    public partial class ClientForm : Form
    {
        private readonly IClientRepository _clientRepository;

        public ClientForm(IClientRepository clientRepository)
        {
            InitializeComponent();
            _clientRepository = clientRepository;
            ConfigureGrid();
            LoadClients();
        }

        private void ConfigureGrid()
        {
            dgvClients.AutoGenerateColumns = true;
            dgvClients.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvClients.RowHeadersVisible = false;
            dgvClients.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvClients.MultiSelect = false;
            dgvClients.ReadOnly = true;
            dgvClients.AllowUserToAddRows = false;
            dgvClients.AllowUserToDeleteRows = false;
            dgvClients.AllowUserToResizeRows = false;
            dgvClients.BackgroundColor = Color.White;
            dgvClients.BorderStyle = BorderStyle.None;

            dgvClients.CellClick += dgvClients_CellClick;
        }

        private async void LoadClients()
        {
            var clients = await _clientRepository.GetAllAsync();
            dgvClients.DataSource = new List<Client>(clients);
            AddActionButtons();
        }

        private void AddActionButtons()
        {
            if (dgvClients.Columns["btnEdit"] == null)
            {
                var btnEdit = new DataGridViewButtonColumn
                {
                    Name = "btnEdit",
                    HeaderText = "",
                    Text = "Edit",
                    UseColumnTextForButtonValue = true,
                    AutoSizeMode = DataGridViewAutoSizeColumnMode.None,
                    Width = 60,
                    FillWeight = 60
                };
                dgvClients.Columns.Add(btnEdit);
            }

            if (dgvClients.Columns["btnDelete"] == null)
            {
                var btnDelete = new DataGridViewButtonColumn
                {
                    Name = "btnDelete",
                    HeaderText = "",
                    Text = "Delete",
                    UseColumnTextForButtonValue = true,
                    AutoSizeMode = DataGridViewAutoSizeColumnMode.None,
                    Width = 60,
                    FillWeight = 60
                };
                dgvClients.Columns.Add(btnDelete);
            }
        }

        private void ClearFields()
        {
            txtName.Clear();
            txtLastName.Clear();
            txtIdNumber.Clear();
            txtPhone.Clear();
        }

        private bool ValidateInput()
        {
            if (string.IsNullOrWhiteSpace(txtName.Text))
            {
                MessageBox.Show("Client name is required.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtName.Focus();
                return false;
            }

            if (string.IsNullOrWhiteSpace(txtLastName.Text))
            {
                MessageBox.Show("Client last name is required.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtLastName.Focus();
                return false;
            }

            if (string.IsNullOrWhiteSpace(txtPhone.Text))
            {
                MessageBox.Show("Client phone number is required.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtPhone.Focus();
                return false;
            }

            return true;
        }


        private async void btnAddClient_Click(object sender, EventArgs e)
        {

            if (!ValidateInput())
                return;

            var client = new Client
            {
                Name = txtName.Text.Trim(),
                LastName = txtLastName.Text.Trim(),
                Identification = txtIdNumber.Text.Trim(),
                Phone = txtPhone.Text.Trim()
            };

            await _clientRepository.AddAsync(client);
            ClearFields();
            LoadClients();
        }

        private async void dgvClients_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;

            var selectedClient = dgvClients.Rows[e.RowIndex].DataBoundItem as Client;
            if (selectedClient == null) return;

            var columnName = dgvClients.Columns[e.ColumnIndex].Name;

            if (columnName == "btnEdit")
            {
                var fieldValues = new Dictionary<string, string>
                {
                    { "Name", selectedClient.Name },
                    { "Last Name", selectedClient.LastName },
                    { "ID Number", selectedClient.Identification },
                    { "Phone", selectedClient.Phone }
                };

                var updatedValues = Prompt.ShowMultiFieldDialog(fieldValues, "Edit client");

                if (updatedValues != null)
                {
                    selectedClient.Name = updatedValues["Name"];
                    selectedClient.LastName = updatedValues["Last Name"];
                    selectedClient.Identification = updatedValues["ID Number"];
                    selectedClient.Phone = updatedValues["Phone"];

                    await _clientRepository.UpdateAsync(selectedClient);
                    LoadClients();
                }
            }
            else if (columnName == "btnDelete")
            {
                var confirm = MessageBox.Show("Do you want to delete this client?", "Confirm", MessageBoxButtons.YesNo);
                if (confirm == DialogResult.Yes)
                {
                    await _clientRepository.DeleteAsync(selectedClient.Id);
                    LoadClients();
                }
            }
        }


    }
}
