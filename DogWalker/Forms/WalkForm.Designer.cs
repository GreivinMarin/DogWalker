
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
            this.cmdClearFilters = new System.Windows.Forms.Button();
            this.btnSearch = new System.Windows.Forms.Button();
            this.label8 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.dtpToDate = new System.Windows.Forms.DateTimePicker();
            this.dtpFromDate = new System.Windows.Forms.DateTimePicker();
            this.txtDogName = new System.Windows.Forms.TextBox();
            this.txtClientName = new System.Windows.Forms.TextBox();
            this.chkFilterByDate = new System.Windows.Forms.CheckBox();
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
            this.cmbDog.Location = new System.Drawing.Point(56, 47);
            this.cmbDog.Name = "cmbDog";
            this.cmbDog.Size = new System.Drawing.Size(250, 21);
            this.cmbDog.TabIndex = 1;
            // 
            // cmbClient
            // 
            this.cmbClient.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.cmbClient.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cmbClient.Location = new System.Drawing.Point(56, 12);
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
            this.dgvWalks.Location = new System.Drawing.Point(12, 129);
            this.dgvWalks.Name = "dgvWalks";
            this.dgvWalks.RowHeadersVisible = false;
            this.dgvWalks.Size = new System.Drawing.Size(879, 391);
            this.dgvWalks.TabIndex = 2;
            this.dgvWalks.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.DgvWalks_CellClick);
            this.dgvWalks.ColumnHeaderMouseClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.dgvWalks_ColumnHeaderMouseClick);
            // 
            // dtpDate
            // 
            this.dtpDate.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpDate.Location = new System.Drawing.Point(390, 13);
            this.dtpDate.Name = "dtpDate";
            this.dtpDate.Size = new System.Drawing.Size(115, 22);
            this.dtpDate.TabIndex = 2;
            // 
            // txtDuration
            // 
            this.txtDuration.Location = new System.Drawing.Point(390, 47);
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
            this.txtDuration.Size = new System.Drawing.Size(115, 22);
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
            this.label1.Location = new System.Drawing.Point(17, 15);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(41, 16);
            this.label1.TabIndex = 4;
            this.label1.Text = "Client";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(17, 50);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(34, 16);
            this.label2.TabIndex = 5;
            this.label2.Text = "Dog";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(334, 15);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(37, 16);
            this.label3.TabIndex = 6;
            this.label3.Text = "Date";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(334, 50);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(58, 16);
            this.label4.TabIndex = 7;
            this.label4.Text = "Duration";
            // 
            // btnAdd
            // 
            this.btnAdd.Location = new System.Drawing.Point(540, 47);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(150, 20);
            this.btnAdd.TabIndex = 8;
            this.btnAdd.Text = "Add";
            this.btnAdd.UseVisualStyleBackColor = true;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // btnClear
            // 
            this.btnClear.Location = new System.Drawing.Point(540, 12);
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
            this.tabWalkOptions.Size = new System.Drawing.Size(883, 111);
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
            this.tpagAdd.Size = new System.Drawing.Size(875, 85);
            this.tpagAdd.TabIndex = 0;
            this.tpagAdd.Text = "Add Walk";
            this.tpagAdd.ToolTipText = "Add new walk";
            this.tpagAdd.UseVisualStyleBackColor = true;
            // 
            // tpagSearch
            // 
            this.tpagSearch.Controls.Add(this.chkFilterByDate);
            this.tpagSearch.Controls.Add(this.cmdClearFilters);
            this.tpagSearch.Controls.Add(this.btnSearch);
            this.tpagSearch.Controls.Add(this.label8);
            this.tpagSearch.Controls.Add(this.label7);
            this.tpagSearch.Controls.Add(this.label6);
            this.tpagSearch.Controls.Add(this.label5);
            this.tpagSearch.Controls.Add(this.dtpToDate);
            this.tpagSearch.Controls.Add(this.dtpFromDate);
            this.tpagSearch.Controls.Add(this.txtDogName);
            this.tpagSearch.Controls.Add(this.txtClientName);
            this.tpagSearch.Location = new System.Drawing.Point(4, 22);
            this.tpagSearch.Name = "tpagSearch";
            this.tpagSearch.Padding = new System.Windows.Forms.Padding(3);
            this.tpagSearch.Size = new System.Drawing.Size(875, 85);
            this.tpagSearch.TabIndex = 1;
            this.tpagSearch.Text = "Search Filters";
            this.tpagSearch.UseVisualStyleBackColor = true;
            // 
            // cmdClearFilters
            // 
            this.cmdClearFilters.Location = new System.Drawing.Point(705, 10);
            this.cmdClearFilters.Name = "cmdClearFilters";
            this.cmdClearFilters.Size = new System.Drawing.Size(150, 21);
            this.cmdClearFilters.TabIndex = 11;
            this.cmdClearFilters.Text = "Clear";
            this.cmdClearFilters.UseVisualStyleBackColor = true;
            this.cmdClearFilters.Click += new System.EventHandler(this.cmdClearFilters_Click);
            // 
            // btnSearch
            // 
            this.btnSearch.Location = new System.Drawing.Point(705, 47);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(150, 20);
            this.btnSearch.TabIndex = 10;
            this.btnSearch.Text = "Search";
            this.btnSearch.UseVisualStyleBackColor = true;
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(482, 49);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(69, 16);
            this.label8.TabIndex = 8;
            this.label8.Text = "Final Date";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(482, 12);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(70, 16);
            this.label7.TabIndex = 7;
            this.label7.Text = "Initial Date";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(17, 50);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(74, 16);
            this.label6.TabIndex = 6;
            this.label6.Text = "Dog Name";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(17, 15);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(81, 16);
            this.label5.TabIndex = 5;
            this.label5.Text = "Client Name";
            // 
            // dtpToDate
            // 
            this.dtpToDate.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpToDate.Location = new System.Drawing.Point(563, 47);
            this.dtpToDate.Name = "dtpToDate";
            this.dtpToDate.Size = new System.Drawing.Size(111, 22);
            this.dtpToDate.TabIndex = 4;
            // 
            // dtpFromDate
            // 
            this.dtpFromDate.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpFromDate.Location = new System.Drawing.Point(563, 9);
            this.dtpFromDate.Name = "dtpFromDate";
            this.dtpFromDate.Size = new System.Drawing.Size(111, 22);
            this.dtpFromDate.TabIndex = 3;
            // 
            // txtDogName
            // 
            this.txtDogName.Location = new System.Drawing.Point(104, 47);
            this.txtDogName.Name = "txtDogName";
            this.txtDogName.Size = new System.Drawing.Size(223, 22);
            this.txtDogName.TabIndex = 1;
            // 
            // txtClientName
            // 
            this.txtClientName.Location = new System.Drawing.Point(104, 12);
            this.txtClientName.Name = "txtClientName";
            this.txtClientName.Size = new System.Drawing.Size(223, 22);
            this.txtClientName.TabIndex = 0;
            // 
            // chkFilterByDate
            // 
            this.chkFilterByDate.AutoSize = true;
            this.chkFilterByDate.Checked = true;
            this.chkFilterByDate.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkFilterByDate.Location = new System.Drawing.Point(358, 12);
            this.chkFilterByDate.Name = "chkFilterByDate";
            this.chkFilterByDate.Size = new System.Drawing.Size(106, 20);
            this.chkFilterByDate.TabIndex = 12;
            this.chkFilterByDate.Text = "Filter by Date";
            this.chkFilterByDate.UseVisualStyleBackColor = true;
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
        private System.Windows.Forms.TextBox txtDogName;
        private System.Windows.Forms.TextBox txtClientName;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.DateTimePicker dtpToDate;
        private System.Windows.Forms.DateTimePicker dtpFromDate;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Button cmdClearFilters;
        private System.Windows.Forms.Button btnSearch;
        private System.Windows.Forms.CheckBox chkFilterByDate;
    }
}