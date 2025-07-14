using DogWalker.Core.Entities;
using DogWalker.Core.Interfaces;
using DogWalker.UI.Classes;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace DogWalker.UI.Forms
{
    public partial class DogForm : Form
    {
        private readonly IDogRepository _dogRepository;
        private readonly IBreedRepository _breedRepository;
        private List<Breed> _breeds;

        public DogForm(IDogRepository dogRepository, IBreedRepository breedRepository)
        {
            InitializeComponent();
            _dogRepository = dogRepository;
            _breedRepository = breedRepository;

            ConfigureGrid();
            LoadBreeds();
            LoadDogs();
        }

        private void ConfigureGrid()
        {
            dgvDogs.AutoGenerateColumns = true;
            dgvDogs.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvDogs.RowHeadersVisible = false;
            dgvDogs.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvDogs.MultiSelect = false;
            dgvDogs.ReadOnly = true;
            dgvDogs.AllowUserToAddRows = false;
            dgvDogs.AllowUserToDeleteRows = false;
            dgvDogs.AllowUserToResizeRows = false;
            dgvDogs.BackgroundColor = Color.White;
            dgvDogs.BorderStyle = BorderStyle.None;

            dgvDogs.CellClick += dgvDogs_CellClick;
        }

        private async void LoadBreeds()
        {
            _breeds = (await _breedRepository.GetAllAsync()).ToList();
            cmbBreed.DataSource = _breeds;
            cmbBreed.DisplayMember = "Name";
            cmbBreed.ValueMember = "Id";
        }

        private async void LoadDogs()
        {
            var dogs = (await _dogRepository.GetAllAsync()).ToList();

            // Map breed names (optional, since no JOIN is done)
            foreach (var dog in dogs)
            {
                var breed = _breeds.FirstOrDefault(b => b.Id == dog.IdBreed);
                dog.BreedName = breed?.Name ?? "(Unknown)";
            }

            dgvDogs.DataSource = null;
            dgvDogs.DataSource = dogs;
            AddActionButtons();
        }

        private void AddActionButtons()
        {
            // prevent duplicated columns
            if (dgvDogs.Columns["btnEdit"] != null)
                dgvDogs.Columns.Remove("btnEdit");

            if (dgvDogs.Columns["btnDelete"] != null)
                dgvDogs.Columns.Remove("btnDelete");

            if (dgvDogs.Columns["btnEdit"] == null)
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
                dgvDogs.Columns.Add(btnEdit);
            }

            if (dgvDogs.Columns["btnDelete"] == null)
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
                dgvDogs.Columns.Add(btnDelete);
            }
        }

        private async void btnAddDog_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtDogName.Text))
            {
                MessageBox.Show("Dog name is required.", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtDogName.Focus();
                return;
            }

            if (cmbBreed.SelectedItem == null)
            {
                MessageBox.Show("Please select a breed.", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var newDog = new Dog
            {
                Name = txtDogName.Text.Trim(),
                BirthDate = dtpBirth.Value.ToString("yyyy-MM-dd"),
                IdBreed = (int)cmbBreed.SelectedValue
            };

            await _dogRepository.AddAsync(newDog);
            ClearFields();
            LoadDogs();
        }

        private async void dgvDogs_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;

            var selectedDog = dgvDogs.Rows[e.RowIndex].DataBoundItem as Dog;
            if (selectedDog == null) return;

            var column = dgvDogs.Columns[e.ColumnIndex].Name;

            if (column == "btnEdit")
            {
                var breedNames = _breeds.Select(b => b.Name).ToList();
                var breedName = _breeds.FirstOrDefault(b => b.Id == selectedDog.IdBreed)?.Name ?? "";

                var values = new Dictionary<string, string>
                {
                    { "Name", selectedDog.Name },
                    { "BirthDate", selectedDog.BirthDate },
                    { "Breed", breedName }
                };

                var comboOptions = new Dictionary<string, List<string>>
                {
                    { "Breed", breedNames }
                };

                var updated = Prompt.ShowMultiFieldDialog(values, "Edit Dog", comboOptions);

                if (updated != null)
                {
                    selectedDog.Name = updated["Name"];
                    selectedDog.BirthDate = updated["BirthDate"];

                    var selectedBreed = _breeds.FirstOrDefault(b => b.Name.Equals(updated["Breed"], StringComparison.OrdinalIgnoreCase));
                    if (selectedBreed != null)
                        selectedDog.IdBreed = selectedBreed.Id;

                    await _dogRepository.UpdateAsync(selectedDog);
                    LoadDogs();
                }

            }
            else if (column == "btnDelete")
            {
                var confirm = MessageBox.Show("Are you sure you want to delete this dog?", "Confirm", MessageBoxButtons.YesNo);
                if (confirm == DialogResult.Yes)
                {
                    await _dogRepository.DeleteAsync(selectedDog.Id);
                    LoadDogs();
                }
            }
        }

        private void ClearFields()
        {
            txtDogName.Clear();
            dtpBirth.Value = DateTime.Today;
            cmbBreed.SelectedIndex = 0;
        }
    }
}
