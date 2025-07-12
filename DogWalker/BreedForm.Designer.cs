
namespace DogWalker.UI
{
    partial class BreedForm
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
            this.dgvBreeds = new System.Windows.Forms.DataGridView();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btnAddBreed = new System.Windows.Forms.Button();
            this.txtBreedName = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.dgvBreeds)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // dgvBreeds
            // 
            this.dgvBreeds.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvBreeds.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvBreeds.Location = new System.Drawing.Point(9, 85);
            this.dgvBreeds.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.dgvBreeds.Name = "dgvBreeds";
            this.dgvBreeds.RowHeadersVisible = false;
            this.dgvBreeds.RowHeadersWidth = 51;
            this.dgvBreeds.RowTemplate.Height = 24;
            this.dgvBreeds.Size = new System.Drawing.Size(582, 224);
            this.dgvBreeds.TabIndex = 0;
            this.dgvBreeds.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvBreeds_CellClick);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btnAddBreed);
            this.groupBox1.Controls.Add(this.txtBreedName);
            this.groupBox1.Location = new System.Drawing.Point(9, 15);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(582, 65);
            this.groupBox1.TabIndex = 4;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Add breed";
            // 
            // btnAddBreed
            // 
            this.btnAddBreed.Location = new System.Drawing.Point(170, 30);
            this.btnAddBreed.Margin = new System.Windows.Forms.Padding(2);
            this.btnAddBreed.Name = "btnAddBreed";
            this.btnAddBreed.Size = new System.Drawing.Size(66, 20);
            this.btnAddBreed.TabIndex = 4;
            this.btnAddBreed.Text = "Add";
            this.btnAddBreed.UseVisualStyleBackColor = true;
            // 
            // txtBreedName
            // 
            this.txtBreedName.Location = new System.Drawing.Point(5, 30);
            this.txtBreedName.Margin = new System.Windows.Forms.Padding(2);
            this.txtBreedName.Name = "txtBreedName";
            this.txtBreedName.Size = new System.Drawing.Size(150, 20);
            this.txtBreedName.TabIndex = 3;
            this.txtBreedName.Click += new System.EventHandler(this.btnAddBreed_Click);
            // 
            // BreedForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(600, 320);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.dgvBreeds);
            this.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.Name = "BreedForm";
            this.Text = "BreedForm";
            ((System.ComponentModel.ISupportInitialize)(this.dgvBreeds)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvBreeds;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button btnAddBreed;
        private System.Windows.Forms.TextBox txtBreedName;
    }
}