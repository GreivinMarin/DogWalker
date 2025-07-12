using DogWalker.Infrastructure.Data;
using DogWalker.Infrastructure.Repositories;
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
    public partial class FrmMain : Form
    {
        private readonly string _connectionString;

        public FrmMain()
        {
            InitializeComponent();
            IsMdiContainer = true;
            _connectionString = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;
        }

        private void mnuBreeds_Click(object sender, EventArgs e)
        {
            var dbContext = new DatabaseContext(_connectionString);
            var breedRepo = new BreedRepository(dbContext);
            var form = new BreedForm(breedRepo)
            {
                MdiParent = this
            };
            form.Show();
        }
    }
}
