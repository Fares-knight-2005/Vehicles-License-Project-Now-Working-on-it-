namespace DVLD_project.People_Forms
{
    partial class ctrUserIfoWithFilter
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.txtSearch = new System.Windows.Forms.TextBox();
            this.cmbSearch = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.picbAddNewPeron = new System.Windows.Forms.PictureBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.personCardControl1 = new DVLD_project.PersonCardControl();
            this.grbFilter = new System.Windows.Forms.GroupBox();
            this.errorProvider1 = new System.Windows.Forms.ErrorProvider(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.picbAddNewPeron)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.grbFilter.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).BeginInit();
            this.SuspendLayout();
            // 
            // txtSearch
            // 
            this.txtSearch.Location = new System.Drawing.Point(307, 35);
            this.txtSearch.Name = "txtSearch";
            this.txtSearch.Size = new System.Drawing.Size(184, 22);
            this.txtSearch.TabIndex = 10;
            this.txtSearch.TextChanged += new System.EventHandler(this.txtSearch_TextChanged);
            this.txtSearch.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtSearch_KeyPress);
            this.txtSearch.Validating += new System.ComponentModel.CancelEventHandler(this.txtSearch_Validating);
            // 
            // cmbSearch
            // 
            this.cmbSearch.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbSearch.FormattingEnabled = true;
            this.cmbSearch.Items.AddRange(new object[] {
            "Person ID",
            "National No"});
            this.cmbSearch.Location = new System.Drawing.Point(147, 33);
            this.cmbSearch.Name = "cmbSearch";
            this.cmbSearch.Size = new System.Drawing.Size(140, 24);
            this.cmbSearch.TabIndex = 9;
            this.cmbSearch.SelectedIndexChanged += new System.EventHandler(this.cmbSearch_SelectedIndexChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Elephant", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(1, 26);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(137, 30);
            this.label3.TabIndex = 8;
            this.label3.Text = "Filter By : ";
            // 
            // picbAddNewPeron
            // 
            this.picbAddNewPeron.Image = global::DVLD_project.Properties.Resources.person_boy__4_;
            this.picbAddNewPeron.Location = new System.Drawing.Point(544, 16);
            this.picbAddNewPeron.Name = "picbAddNewPeron";
            this.picbAddNewPeron.Size = new System.Drawing.Size(41, 41);
            this.picbAddNewPeron.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.picbAddNewPeron.TabIndex = 12;
            this.picbAddNewPeron.TabStop = false;
            this.picbAddNewPeron.Click += new System.EventHandler(this.picbAddNewPeron_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::DVLD_project.Properties.Resources.person_boy__3_;
            this.pictureBox1.Location = new System.Drawing.Point(497, 16);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(41, 41);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 11;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.Click += new System.EventHandler(this.pictureBox1_Click);
            // 
            // personCardControl1
            // 
            this.personCardControl1.Location = new System.Drawing.Point(30, 84);
            this.personCardControl1.Name = "personCardControl1";
            this.personCardControl1.Size = new System.Drawing.Size(653, 206);
            this.personCardControl1.TabIndex = 0;
            // 
            // grbFilter
            // 
            this.grbFilter.Controls.Add(this.txtSearch);
            this.grbFilter.Controls.Add(this.picbAddNewPeron);
            this.grbFilter.Controls.Add(this.cmbSearch);
            this.grbFilter.Controls.Add(this.pictureBox1);
            this.grbFilter.Controls.Add(this.label3);
            this.grbFilter.Location = new System.Drawing.Point(30, 15);
            this.grbFilter.Name = "grbFilter";
            this.grbFilter.Size = new System.Drawing.Size(653, 63);
            this.grbFilter.TabIndex = 0;
            this.grbFilter.TabStop = false;
            this.grbFilter.Text = "Filter";
            // 
            // errorProvider1
            // 
            this.errorProvider1.ContainerControl = this;
            // 
            // ctrUserIfoWithFilter
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.grbFilter);
            this.Controls.Add(this.personCardControl1);
            this.Name = "ctrUserIfoWithFilter";
            this.Size = new System.Drawing.Size(714, 318);
            ((System.ComponentModel.ISupportInitialize)(this.picbAddNewPeron)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.grbFilter.ResumeLayout(false);
            this.grbFilter.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private PersonCardControl personCardControl1;
        private System.Windows.Forms.TextBox txtSearch;
        private System.Windows.Forms.ComboBox cmbSearch;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.PictureBox picbAddNewPeron;
        private System.Windows.Forms.GroupBox grbFilter;
        private System.Windows.Forms.ErrorProvider errorProvider1;
    }
}
