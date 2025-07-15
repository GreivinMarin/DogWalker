
namespace DogWalker.UI
{
    partial class MainForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.mnuProcesses = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuWalks = new System.Windows.Forms.ToolStripMenuItem();
            this.catalogsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuClients = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuDogs = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuBreeds = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuExit = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuProcesses,
            this.catalogsToolStripMenuItem,
            this.mnuExit});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Padding = new System.Windows.Forms.Padding(4, 2, 0, 2);
            this.menuStrip1.Size = new System.Drawing.Size(1087, 24);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // mnuProcesses
            // 
            this.mnuProcesses.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuWalks});
            this.mnuProcesses.Name = "mnuProcesses";
            this.mnuProcesses.Size = new System.Drawing.Size(70, 20);
            this.mnuProcesses.Text = "Processes";
            // 
            // mnuWalks
            // 
            this.mnuWalks.Name = "mnuWalks";
            this.mnuWalks.Size = new System.Drawing.Size(105, 22);
            this.mnuWalks.Text = "Walks";
            this.mnuWalks.Click += new System.EventHandler(this.mnuWalks_Click);
            // 
            // catalogsToolStripMenuItem
            // 
            this.catalogsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuClients,
            this.mnuDogs,
            this.mnuBreeds});
            this.catalogsToolStripMenuItem.Name = "catalogsToolStripMenuItem";
            this.catalogsToolStripMenuItem.Size = new System.Drawing.Size(65, 20);
            this.catalogsToolStripMenuItem.Text = "Catalogs";
            // 
            // mnuClients
            // 
            this.mnuClients.Name = "mnuClients";
            this.mnuClients.Size = new System.Drawing.Size(110, 22);
            this.mnuClients.Text = "Clients";
            this.mnuClients.Click += new System.EventHandler(this.mnuClients_Click);
            // 
            // mnuDogs
            // 
            this.mnuDogs.Name = "mnuDogs";
            this.mnuDogs.Size = new System.Drawing.Size(110, 22);
            this.mnuDogs.Text = "Dogs";
            this.mnuDogs.Click += new System.EventHandler(this.mnuDogs_Click);
            // 
            // mnuBreeds
            // 
            this.mnuBreeds.Name = "mnuBreeds";
            this.mnuBreeds.Size = new System.Drawing.Size(110, 22);
            this.mnuBreeds.Text = "Breeds";
            this.mnuBreeds.Click += new System.EventHandler(this.mnuBreeds_Click);
            // 
            // mnuExit
            // 
            this.mnuExit.Name = "mnuExit";
            this.mnuExit.Size = new System.Drawing.Size(37, 20);
            this.mnuExit.Text = "Exit";
            this.mnuExit.Click += new System.EventHandler(this.mnuExit_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1087, 539);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "MainForm";
            this.Text = "DogWalker";
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem mnuProcesses;
        private System.Windows.Forms.ToolStripMenuItem mnuWalks;
        private System.Windows.Forms.ToolStripMenuItem catalogsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem mnuClients;
        private System.Windows.Forms.ToolStripMenuItem mnuDogs;
        private System.Windows.Forms.ToolStripMenuItem mnuBreeds;
        private System.Windows.Forms.ToolStripMenuItem mnuExit;
    }
}

