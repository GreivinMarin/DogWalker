using DogWalker.Infrastructure.Data;
using DogWalker.Infrastructure.Repositories;
using DogWalker.UI.Forms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DogWalker.UI
{
    public partial class MainForm : Form
    {
        private readonly string _connectionString;

        public MainForm()
        {
            InitializeComponent();
            IsMdiContainer = true;
            _connectionString = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;
        }

        private void mnuBreeds_Click(object sender, EventArgs e)
        {
            var dbContext = new DatabaseContext(_connectionString);
            var repo = new BreedRepository(dbContext);
            var form = new BreedForm(repo)
            {
                MdiParent = this
            };
            form.Show();
        }

        private void mnuClients_Click(object sender, EventArgs e)
        {
            var dbContext = new DatabaseContext(_connectionString);
            var repo = new ClientRepository(dbContext);
            var form = new ClientForm(repo)
            {
                MdiParent = this
            };
            form.Show();
        }

        private void mnuDogs_Click(object sender, EventArgs e)
        {
            var dbContext = new DatabaseContext(_connectionString);
            var repoDog = new DogRepository(dbContext);
            var repoBreed = new BreedRepository(dbContext);
            var form = new DogForm(repoDog, repoBreed)
            {
                MdiParent = this
            };
            form.Show();
        }

        private void mnuWalks_Click(object sender, EventArgs e)
        {
            var dbContext = new DatabaseContext(_connectionString);
            var repoDog = new DogRepository(dbContext);
            var repoClient = new ClientRepository(dbContext);
            var repoWalk = new WalkRepository(dbContext);
            var form = new WalkForm(repoClient, repoDog, repoWalk);
            form.Show();
        }
    }
}
