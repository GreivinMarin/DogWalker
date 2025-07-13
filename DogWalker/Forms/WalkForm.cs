using DogWalker.Core.Entities;
using DogWalker.Core.Interfaces;
using DogWalker.Infrastructure.Data;
using DogWalker.Infrastructure.Repositories;
using DogWalker.UI.Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DogWalker.UI.Forms
{
    public partial class WalkForm : Form
    {
        private readonly IWalkRepository _walkRepository;
        private readonly IClientRepository _clientRepository;
        private readonly IDogRepository _dogRepository;

        private Dictionary<string, int> _clientNameToId;
        private Dictionary<string, int> _dogNameToId;

        public WalkForm(
            IClientRepository clientRepository,
            IDogRepository dogRepository,
            IWalkRepository walkRepository)
        {
            InitializeComponent();

            _clientRepository = clientRepository;
            _dogRepository = dogRepository;
            _walkRepository = walkRepository;

            dgvWalks.AutoGenerateColumns = false;
            dgvWalks.AllowUserToAddRows = false;
            dgvWalks.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
        }

        private async void WalkForm_Load(object sender, EventArgs e)
        {
            await LoadDataAsync();
        }

        private async Task LoadDataAsync()
        {
            dgvWalks.Columns.Clear();
            dgvWalks.DataSource = (await _walkRepository.GetAllAsync()).ToList();

            dgvWalks.Columns.Add(new DataGridViewTextBoxColumn { HeaderText = "ID", DataPropertyName = "Id" });
            dgvWalks.Columns.Add(new DataGridViewTextBoxColumn { HeaderText = "Client", DataPropertyName = "ClientName" });
            dgvWalks.Columns.Add(new DataGridViewTextBoxColumn { HeaderText = "Dog", DataPropertyName = "DogName" });
            dgvWalks.Columns.Add(new DataGridViewTextBoxColumn { HeaderText = "Date", DataPropertyName = "Date" });
            dgvWalks.Columns.Add(new DataGridViewTextBoxColumn { HeaderText = "Duration", DataPropertyName = "Duration" });

            dgvWalks.Columns.Add(new DataGridViewButtonColumn { Text = "Edit", UseColumnTextForButtonValue = true, Width = 60 });
            dgvWalks.Columns.Add(new DataGridViewButtonColumn { Text = "Delete", UseColumnTextForButtonValue = true, Width = 60 });

            dgvWalks.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        }

        private async void btnAdd_Click(object sender, EventArgs e)
        {
            var clients = (await _clientRepository.GetAllAsync()).ToList();
            var dogs = (await _dogRepository.GetAllAsync()).ToList();

            _clientNameToId = clients.ToDictionary(c => $"{c.Name} {c.LastName}", c => c.Id);
            _dogNameToId = dogs.ToDictionary(d => d.Name, d => d.Id);

            var fields = new Dictionary<string, string>
            {
                { "Client", "" },
                { "Dog", "" },
                { "Date", DateTime.Today.ToString("yyyy-MM-dd") },
                { "Duration", "30" }
            };

            var comboOptions = new Dictionary<string, List<string>>
            {
                { "Client", _clientNameToId.Keys.ToList() },
                { "Dog", _dogNameToId.Keys.ToList() }
            };

            var result = Prompt.ShowMultiFieldDialog(fields, "Add Walk", comboOptions);

            if (result != null)
            {
                var walk = new Walk
                {
                    IdClient = _clientNameToId[result["Client"]],
                    IdDog = _dogNameToId[result["Dog"]],
                    Date = result["Date"],
                    Duration = double.Parse(result["Duration"])
                };

                await _walkRepository.AddAsync(walk);
                await LoadDataAsync();
            }
        }

        private async void dgvWalks_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;
            var walk = dgvWalks.Rows[e.RowIndex].DataBoundItem as Walk;

            if (dgvWalks.Columns[e.ColumnIndex].HeaderText == "Edit")
            {
                var clients = (await _clientRepository.GetAllAsync()).ToList();
                var dogs = (await _dogRepository.GetAllAsync()).ToList();

                _clientNameToId = clients.ToDictionary(c => $"{c.Name} {c.LastName}", c => c.Id);
                _dogNameToId = dogs.ToDictionary(d => d.Name, d => d.Id);

                string selectedClient = _clientNameToId.FirstOrDefault(x => x.Value == walk.IdClient).Key;
                string selectedDog = _dogNameToId.FirstOrDefault(x => x.Value == walk.IdDog).Key;

                var fields = new Dictionary<string, string>
                {
                    { "Client", selectedClient },
                    { "Dog", selectedDog },
                    { "Date", walk.Date },
                    { "Duration", walk.Duration.ToString() }
                };

                var comboOptions = new Dictionary<string, List<string>>
                {
                    { "Client", _clientNameToId.Keys.ToList() },
                    { "Dog", _dogNameToId.Keys.ToList() }
                };

                var result = Prompt.ShowMultiFieldDialog(fields, "Edit Walk", comboOptions);

                if (result != null)
                {
                    walk.IdClient = _clientNameToId[result["Client"]];
                    walk.IdDog = _dogNameToId[result["Dog"]];
                    walk.Date = result["Date"];
                    walk.Duration = double.Parse(result["Duration"]);

                    await _walkRepository.UpdateAsync(walk);
                    await LoadDataAsync();
                }
            }
            else if (dgvWalks.Columns[e.ColumnIndex].HeaderText == "Delete")
            {
                if (MessageBox.Show("Are you sure to delete this walk?", "Confirm", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    await _walkRepository.DeleteAsync(walk.Id);
                    await LoadDataAsync();
                }
            }
        }
    }
}
