using DogWalker.Core.Classes;
using DogWalker.Core.Entities;
using DogWalker.Core.Helpers;
using DogWalker.Core.Interfaces;
using DogWalker.UI.Classes;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DogWalker.UI.Forms
{
    public partial class WalkForm : Form
    {
        private readonly IClientRepository _clientRepository;
        private readonly IDogRepository _dogRepository;
        private readonly IWalkRepository _walkRepository;
        private List<Walk> _walksList;

        public WalkForm(IClientRepository clientRepo, IDogRepository dogRepo, IWalkRepository walkRepo)
        {
            InitializeComponent();
            _clientRepository = clientRepo;
            _dogRepository = dogRepo;
            _walkRepository = walkRepo;
        }

        private async void WalkForm_Load(object sender, EventArgs e)
        {
            tabWalkOptions.SelectedIndex = 1;
            ConfigureGrid();
            await LoadClientsAsync();
            await LoadDogsAsync();
            ClearAddTabFields();
            ClearFiltersSearchFields();
            await LoadWalksAsync();            
        }

        private void ConfigureGrid()
        {
            dgvWalks.AutoGenerateColumns = true;
            dgvWalks.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvWalks.RowHeadersVisible = false;
            dgvWalks.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvWalks.MultiSelect = false;
            dgvWalks.ReadOnly = true;
            dgvWalks.AllowUserToAddRows = false;
            dgvWalks.AllowUserToDeleteRows = false;
            dgvWalks.AllowUserToResizeRows = false;
            dgvWalks.BackgroundColor = Color.White;
            dgvWalks.BorderStyle = BorderStyle.None;            
        }

        private async Task LoadClientsAsync()
        {
            var clients = (await _clientRepository.GetAllAsync()).ToList();
            
            clients.Insert(0, new Client
            {
                Id = 0,
                Name = "Please select a client"
            });

            cmbClient.DataSource = clients.ToList();
            cmbClient.DisplayMember = "FullName";
            cmbClient.ValueMember = "Id";
            cmbClient.SelectedIndex = 0;
        }

        private async Task LoadDogsAsync()
        {
            var dogs = (await _dogRepository.GetAllAsync()).ToList();

            dogs.Insert(0, new Dog
            {
                Id = 0,
                Name = "Please select a dog"
            });

            cmbDog.DataSource = dogs.ToList();
            cmbDog.DisplayMember = "Name";
            cmbDog.ValueMember = "Id";
            cmbDog.SelectedIndex = 0;
        }

        private async Task LoadWalksAsync()
        {
            dgvWalks.Columns.Clear();

            var criteria = new WalkSearchCriteria
            {
                ClientName = txtClientName.Text.Trim(),
                DogName = txtDogName.Text.Trim(),
                FilterByDate = chkFilterByDate.Checked,
                FromDate = dtpFromDate.Value.Date,
                ToDate = dtpToDate.Value.Date
            };

            _walksList = (await _walkRepository.SearchAsync(criteria)).ToList();
            dgvWalks.DataSource = _walksList;
            
            ConfigureGridColumns();
        }

        private void ConfigureGridColumns()
        {
            dgvWalks.Columns["Id"].Visible = false;
            dgvWalks.Columns["IdClient"].Visible = false;
            dgvWalks.Columns["IdDog"].Visible = false;

            dgvWalks.Columns["ClientName"].HeaderText = "Client";
            dgvWalks.Columns["DogName"].HeaderText = "Dog";
            dgvWalks.Columns["Date"].HeaderText = "Date";
            dgvWalks.Columns["Duration"].HeaderText = "Duration (min)";

            dgvWalks.Columns["ClientName"].DisplayIndex = 0;
            dgvWalks.Columns["DogName"].DisplayIndex = 1;
            dgvWalks.Columns["Date"].DisplayIndex = 2;
            dgvWalks.Columns["Duration"].DisplayIndex = 3;

            // prevent duplicated columns
            if (dgvWalks.Columns["btnEdit"] != null)
                dgvWalks.Columns.Remove("btnEdit");

            if (dgvWalks.Columns["btnDelete"] != null)
                dgvWalks.Columns.Remove("btnDelete");

            if (dgvWalks.Columns["btnEdit"] == null)
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
                dgvWalks.Columns.Add(btnEdit);
            }

            if (dgvWalks.Columns["btnDelete"] == null)
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
                dgvWalks.Columns.Add(btnDelete);
            }
        }

        private void ClearAddTabFields()
        {
            txtDuration.Value = 1;
            dtpDate.Value = DateTime.Today;
            cmbClient.SelectedIndex = 0;
            cmbDog.SelectedIndex = 0;
        }

        private void ClearFiltersSearchFields()
        {
            txtClientName.Text = "";
            txtDogName.Text = "";
            chkFilterByDate.Checked = true;
            dtpFromDate.Value = new DateTime(DateTime.Today.Year, DateTime.Today.Month, 1);
            dtpToDate.Value = DateTime.Today;
        }

        private async void btnAdd_Click(object sender, EventArgs e)
        {
            if (cmbClient.SelectedItem == null || cmbClient.SelectedValue == null || (int)cmbClient.SelectedValue == 0)
            {
                MessageBox.Show("Please select a valid client from the list.");
                cmbClient.Focus();
                return;
            }

            if (cmbDog.SelectedItem == null || cmbDog.SelectedValue == null || (int)cmbDog.SelectedValue == 0)
            {
                MessageBox.Show("Please select a valid dog from the list.");
                cmbDog.Focus();
                return;
            }

            // Date Validation
            DateTime selectedDate = dtpDate.Value.Date;
            if (selectedDate == DateTime.MinValue)
            {
                MessageBox.Show("Please select a valid date.");
                dtpDate.Focus();
                return;
            }

            // Date can't be in the future? need to clarify requirement
            if (selectedDate > DateTime.Today)
            {
                MessageBox.Show("The selected date cannot be in the future.");
                dtpDate.Focus();
                return;
            }

            if (txtDuration.Value <= 0)
            {
                MessageBox.Show("Please enter a duration greater than zero.");
                txtDuration.Focus();
                return;
            }

            var walk = new Walk
            {
                IdClient = (int)cmbClient.SelectedValue,
                IdDog = (int)cmbDog.SelectedValue,
                Date = dtpDate.Value.ToString("yyyy-MM-dd"),
                Duration = (double)txtDuration.Value
            };

            await _walkRepository.AddAsync(walk);
            await LoadWalksAsync();
            ClearAddTabFields();
        }

        private async void DgvWalks_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;

            var row = dgvWalks.Rows[e.RowIndex].DataBoundItem as Walk;
            if (row == null) return;

            var column = dgvWalks.Columns[e.ColumnIndex].Name;

            if (column == "btnEdit")
            {
                var clients = (await _clientRepository.GetAllAsync()).ToList();
                var dogs = (await _dogRepository.GetAllAsync()).ToList();

                var data = new Dictionary<string, string>
                {
                    ["Client"] = row.ClientName,
                    ["Dog"] = row.DogName,
                    ["Date"] = row.Date,
                    ["Duration"] = row.Duration.ToString()
                };

                var combos = new Dictionary<string, List<string>>
                {
                    ["Client"] = clients.Select(c => c.Name + " " + c.LastName).ToList(),
                    ["Dog"] = dogs.Select(d => d.Name).ToList()
                };

                var result = Prompt.ShowMultiFieldDialog(data, "Edit Walk", combos);
                if (result == null) return;

                var selectedClient = clients.FirstOrDefault(c => (c.Name + " " + c.LastName) == result["Client"]);
                var selectedDog = dogs.FirstOrDefault(d => d.Name == result["Dog"]);

                if (selectedClient == null || selectedDog == null) return;

                row.IdClient = selectedClient.Id;
                row.IdDog = selectedDog.Id;
                row.Date = result["Date"];
                row.Duration = double.Parse(result["Duration"]);

                await _walkRepository.UpdateAsync(row);
                await LoadWalksAsync();
                ClearAddTabFields();
            }
            else if (column == "btnDelete")
            {
                var confirm = MessageBox.Show("Are you sure you want to delete this walk?", "Confirm", MessageBoxButtons.YesNo);
                if (confirm == DialogResult.Yes)
                {
                    await _walkRepository.DeleteAsync(row.Id);
                    await LoadWalksAsync();
                }
            }
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            ClearAddTabFields();
        }

        private async void btnSearch_Click(object sender, EventArgs e)
        {
            await LoadWalksAsync();
        }

        private void cmdClearFilters_Click(object sender, EventArgs e)
        {
            ClearFiltersSearchFields();
        }

        private void dgvWalks_ColumnHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            var clickedColumn = dgvWalks.Columns[e.ColumnIndex];

            // Ignore the sort for actions columns
            if (clickedColumn is DataGridViewButtonColumn ||
                clickedColumn.Name == "btnEdit" ||
                clickedColumn.Name == "btnDelete")
                return;

            string propertyName = clickedColumn.DataPropertyName;

            // asc/desc sorting
            bool ascending = clickedColumn.HeaderCell.SortGlyphDirection != SortOrder.Ascending;

            var sortedList = WalkSearchHelper.SortList(_walksList, propertyName, ascending);            

            // Reasign the sorted list as datasource
            dgvWalks.Columns.Clear();
            dgvWalks.DataSource = null;
            dgvWalks.DataSource = sortedList;
            _walksList = sortedList;

            ConfigureGridColumns(); 

            // indicates the sort direction.
            clickedColumn = dgvWalks.Columns[propertyName];
            clickedColumn.HeaderCell.SortGlyphDirection = ascending ? SortOrder.Ascending : SortOrder.Descending;
        }
    }
}
