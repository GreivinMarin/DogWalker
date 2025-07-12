using DogWalker.Core.Entities;
using DogWalker.Core.Interfaces;
using DogWalker.Infrastructure.Data;
using DogWalker.Infrastructure.Repositories;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Windows.Forms;
using System.Threading.Tasks;
using DogWalker.UI.Classes;

namespace DogWalker.UI
{
    public partial class BreedForm : Form
    {
        private readonly IBreedRepository _repo;

        public BreedForm(IBreedRepository repo)
        {
            InitializeComponent();
            
            _repo = repo;            
            LoadBreeds();
        }

        private async void LoadBreeds()
        {
            try
            {
                       
                var breeds = await _repo.GetAllAsync();
                dgvBreeds.DataSource = new List<Breed>(breeds);
                dgvBreeds.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
                AddActionButtons();                
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading the breeds: {ex.Message}");
            }
        }        

        private void AddActionButtons()
        {
            if (dgvBreeds.Columns["btnEdit"] == null)
            {
                var btnEdit = new DataGridViewButtonColumn
                {
                    Name = "btnEdit",
                    HeaderText = "",
                    Text = "Edit",
                    UseColumnTextForButtonValue = true,
                    Width = 30,
                    FillWeight = 30
                };
                dgvBreeds.Columns.Add(btnEdit);
            }

            if (dgvBreeds.Columns["btnDelete"] == null)
            {
                var btnDelete = new DataGridViewButtonColumn
                {
                    Name = "btnDelete",
                    HeaderText = "",
                    Text = "Delete",
                    UseColumnTextForButtonValue = true,
                    Width = 30,
                    FillWeight = 30
                };
                dgvBreeds.Columns.Add(btnDelete);
            }
        }

        private async void btnAddBreed_Click(object sender, EventArgs e)
        {
            var name = txtBreedName.Text.Trim();
            if (string.IsNullOrEmpty(name))
            {
                MessageBox.Show("Please type a valid name.");
                return;
            }

            var newBreed = new Breed { Name = name };

            try
            {
                await _repo.AddAsync(newBreed);
                txtBreedName.Clear();
                LoadBreeds(); // Recargar la grilla
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading Breed: {ex.Message}");
            }
        }

        private async void dgvBreeds_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;

            var selectedBreed = dgvBreeds.Rows[e.RowIndex].DataBoundItem as Breed;
            if (selectedBreed == null) return;

            string columnName = dgvBreeds.Columns[e.ColumnIndex].Name;

            if (columnName == "btnEdit")
            {                
                var fieldValues = new Dictionary<string, string>
                {
                    { "Name", selectedBreed.Name },

                };
                var updatedValues = Prompt.ShowMultiFieldDialog(fieldValues, "Edit Breed");

                if (updatedValues != null)
                {
                    selectedBreed.Name = updatedValues["Name"];
                    bool updated = await _repo.UpdateAsync(selectedBreed);
                    if (updated)
                        LoadBreeds();
                    else
                        MessageBox.Show("Error updating the breed.");
                }
            }
            else if (columnName == "btnDelete")
            {
                var confirm = MessageBox.Show("Are you sure deleting the breed?", "Confirm Delete", MessageBoxButtons.YesNo);
                if (confirm == DialogResult.Yes)
                {
                    bool deleted = await _repo.DeleteAsync(selectedBreed.Id);
                    if (deleted)
                        LoadBreeds();
                    else
                        MessageBox.Show("Error deleting the breed.");
                }
            }
        }

    }
}
