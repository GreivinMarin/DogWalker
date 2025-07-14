
namespace DogWalker.UI.Forms
{
    partial class WalkForm
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
            this.cmbDog = new System.Windows.Forms.ComboBox();
            this.cmbClient = new System.Windows.Forms.ComboBox();
            this.dgvWalks = new System.Windows.Forms.DataGridView();
            this.dtpDate = new System.Windows.Forms.DateTimePicker();
            this.txtDuration = new System.Windows.Forms.NumericUpDown();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.btnAdd = new System.Windows.Forms.Button();
            this.btnClear = new System.Windows.Forms.Button();
            this.tabWalkOptions = new System.Windows.Forms.TabControl();
            this.tpagAdd = new System.Windows.Forms.TabPage();
            this.tpagSearch = new System.Windows.Forms.TabPage();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.textBox2 = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.dgvWalks)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtDuration)).BeginInit();
            this.tabWalkOptions.SuspendLayout();
            this.tpagAdd.SuspendLayout();
            this.tpagSearch.SuspendLayout();
            this.SuspendLayout();
            // 
            // cmbDog
            // 
            this.cmbDog.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.cmbDog.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cmbDog.Location = new System.Drawing.Point(56, 59);
            this.cmbDog.Name = "cmbDog";
            this.cmbDog.Size = new System.Drawing.Size(250, 21);
            this.cmbDog.TabIndex = 1;
            // 
            // cmbClient
            // 
            this.cmbClient.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.cmbClient.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cmbClient.Location = new System.Drawing.Point(56, 24);
            this.cmbClient.Name = "cmbClient";
            this.cmbClient.Size = new System.Drawing.Size(250, 21);
            this.cmbClient.TabIndex = 0;
            // 
            // dgvWalks
            // 
            this.dgvWalks.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvWalks.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvWalks.Location = new System.Drawing.Point(12, 155);
            this.dgvWalks.Name = "dgvWalks";
            this.dgvWalks.RowHeadersVisible = false;
            this.dgvWalks.Size = new System.Drawing.Size(879, 365);
            this.dgvWalks.TabIndex = 2;
            this.dgvWalks.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.DgvWalks_CellClick);
            // 
            // dtpDate
            // 
            this.dtpDate.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpDate.Location = new System.Drawing.Point(390, 25);
            this.dtpDate.Name = "dtpDate";
            this.dtpDate.Size = new System.Drawing.Size(115, 20);
            this.dtpDate.TabIndex = 2;
            // 
            // txtDuration
            // 
            this.txtDuration.Location = new System.Drawing.Point(390, 59);
            this.txtDuration.Maximum = new decimal(new int[] {
            1440,
            0,
            0,
            0});
            this.txtDuration.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.txtDuration.Name = "txtDuration";
            this.txtDuration.Size = new System.Drawing.Size(115, 20);
            this.txtDuration.TabIndex = 3;
            this.txtDuration.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(17, 27);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(33, 13);
            this.label1.TabIndex = 4;
            this.label1.Text = "Client";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(17, 62);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(27, 13);
            this.label2.TabIndex = 5;
            this.label2.Text = "Dog";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(334, 27);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(30, 13);
            this.label3.TabIndex = 6;
            this.label3.Text = "Date";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(334, 62);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(47, 13);
            this.label4.TabIndex = 7;
            this.label4.Text = "Duration";
            // 
            // btnAdd
            // 
            this.btnAdd.Location = new System.Drawing.Point(540, 59);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(150, 20);
            this.btnAdd.TabIndex = 8;
            this.btnAdd.Text = "Add";
            this.btnAdd.UseVisualStyleBackColor = true;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // btnClear
            // 
            this.btnClear.Location = new System.Drawing.Point(540, 24);
            this.btnClear.Name = "btnClear";
            this.btnClear.Size = new System.Drawing.Size(150, 21);
            this.btnClear.TabIndex = 9;
            this.btnClear.Text = "Clear";
            this.btnClear.UseVisualStyleBackColor = true;
            this.btnClear.Click += new System.EventHandler(this.btnClear_Click);
            // 
            // tabWalkOptions
            // 
            this.tabWalkOptions.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tabWalkOptions.Controls.Add(this.tpagAdd);
            this.tabWalkOptions.Controls.Add(this.tpagSearch);
            this.tabWalkOptions.Location = new System.Drawing.Point(12, 12);
            this.tabWalkOptions.Name = "tabWalkOptions";
            this.tabWalkOptions.SelectedIndex = 0;
            this.tabWalkOptions.Size = new System.Drawing.Size(883, 137);
            this.tabWalkOptions.TabIndex = 5;
            // 
            // tpagAdd
            // 
            this.tpagAdd.Controls.Add(this.btnClear);
            this.tpagAdd.Controls.Add(this.btnAdd);
            this.tpagAdd.Controls.Add(this.cmbClient);
            this.tpagAdd.Controls.Add(this.label4);
            this.tpagAdd.Controls.Add(this.label1);
            this.tpagAdd.Controls.Add(this.label3);
            this.tpagAdd.Controls.Add(this.cmbDog);
            this.tpagAdd.Controls.Add(this.txtDuration);
            this.tpagAdd.Controls.Add(this.label2);
            this.tpagAdd.Controls.Add(this.dtpDate);
            this.tpagAdd.Location = new System.Drawing.Point(4, 22);
            this.tpagAdd.Name = "tpagAdd";
            this.tpagAdd.Padding = new System.Windows.Forms.Padding(3);
            this.tpagAdd.Size = new System.Drawing.Size(875, 111);
            this.tpagAdd.TabIndex = 0;
            this.tpagAdd.Text = "Add Walk";
            this.tpagAdd.ToolTipText = "Add new walk";
            this.tpagAdd.UseVisualStyleBackColor = true;
            // 
            // tpagSearch
            // 
            this.tpagSearch.Controls.Add(this.textBox2);
            this.tpagSearch.Controls.Add(this.textBox1);
            this.tpagSearch.Location = new System.Drawing.Point(4, 22);
            this.tpagSearch.Name = "tpagSearch";
            this.tpagSearch.Padding = new System.Windows.Forms.Padding(3);
            this.tpagSearch.Size = new System.Drawing.Size(875, 111);
            this.tpagSearch.TabIndex = 1;
            this.tpagSearch.Text = "Search Filters";
            this.tpagSearch.UseVisualStyleBackColor = true;
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(73, 15);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(112, 20);
            this.textBox1.TabIndex = 0;
            // 
            // textBox2
            // 
            this.textBox2.Location = new System.Drawing.Point(73, 52);
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(112, 20);
            this.textBox2.TabIndex = 1;
            // 
            // WalkForm
            // 
            this.ClientSize = new System.Drawing.Size(908, 532);
            this.Controls.Add(this.tabWalkOptions);
            this.Controls.Add(this.dgvWalks);
            this.Name = "WalkForm";
            this.Load += new System.EventHandler(this.WalkForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvWalks)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtDuration)).EndInit();
            this.tabWalkOptions.ResumeLayout(false);
            this.tpagAdd.ResumeLayout(false);
            this.tpagAdd.PerformLayout();
            this.tpagSearch.ResumeLayout(false);
            this.tpagSearch.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvWalks;
        private System.Windows.Forms.ComboBox cmbDog;
        private System.Windows.Forms.ComboBox cmbClient;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.NumericUpDown txtDuration;
        private System.Windows.Forms.DateTimePicker dtpDate;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnClear;
        private System.Windows.Forms.TabControl tabWalkOptions;
        private System.Windows.Forms.TabPage tpagAdd;
        private System.Windows.Forms.TabPage tpagSearch;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.TextBox textBox1;
    }
}