namespace StarUML_Keyfilemaker
{
    partial class FormMain
    {

        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormMain));
            this.btnGenerate = new System.Windows.Forms.Button();
            this.txtName = new System.Windows.Forms.TextBox();
            this.cbLicenseVersion = new System.Windows.Forms.ComboBox();
            this.cbLicenseType = new System.Windows.Forms.ComboBox();
            this.lblCredits = new System.Windows.Forms.Label();
            this.lblName = new System.Windows.Forms.Label();
            this.lblLicenseVersion = new System.Windows.Forms.Label();
            this.lblEdition = new System.Windows.Forms.Label();
            this.btnPatch = new System.Windows.Forms.Button();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // btnGenerate
            // 
            this.btnGenerate.Location = new System.Drawing.Point(276, 208);
            this.btnGenerate.Name = "btnGenerate";
            this.btnGenerate.Size = new System.Drawing.Size(94, 29);
            this.btnGenerate.TabIndex = 0;
            this.btnGenerate.Text = "&Generate";
            this.btnGenerate.UseVisualStyleBackColor = true;
            this.btnGenerate.Click += new System.EventHandler(this.btnGenerate_Click);
            // 
            // txtName
            // 
            this.txtName.Location = new System.Drawing.Point(76, 103);
            this.txtName.Name = "txtName";
            this.txtName.Size = new System.Drawing.Size(394, 22);
            this.txtName.TabIndex = 1;
            // 
            // cbLicenseVersion
            // 
            this.cbLicenseVersion.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbLicenseVersion.FormattingEnabled = true;
            this.cbLicenseVersion.Location = new System.Drawing.Point(76, 136);
            this.cbLicenseVersion.Name = "cbLicenseVersion";
            this.cbLicenseVersion.Size = new System.Drawing.Size(394, 24);
            this.cbLicenseVersion.TabIndex = 2;
            // 
            // cbLicenseType
            // 
            this.cbLicenseType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbLicenseType.FormattingEnabled = true;
            this.cbLicenseType.Location = new System.Drawing.Point(76, 170);
            this.cbLicenseType.Name = "cbLicenseType";
            this.cbLicenseType.Size = new System.Drawing.Size(394, 24);
            this.cbLicenseType.TabIndex = 3;
            // 
            // lblCredits
            // 
            this.lblCredits.AutoSize = true;
            this.lblCredits.Enabled = false;
            this.lblCredits.Location = new System.Drawing.Point(12, 214);
            this.lblCredits.Name = "lblCredits";
            this.lblCredits.Size = new System.Drawing.Size(88, 16);
            this.lblCredits.TabIndex = 5;
            this.lblCredits.Text = "(c) Ghost0507";
            // 
            // lblName
            // 
            this.lblName.AutoSize = true;
            this.lblName.Location = new System.Drawing.Point(12, 106);
            this.lblName.Name = "lblName";
            this.lblName.Size = new System.Drawing.Size(53, 16);
            this.lblName.TabIndex = 6;
            this.lblName.Text = "Name..:";
            // 
            // lblLicenseVersion
            // 
            this.lblLicenseVersion.AutoSize = true;
            this.lblLicenseVersion.Location = new System.Drawing.Point(12, 139);
            this.lblLicenseVersion.Name = "lblLicenseVersion";
            this.lblLicenseVersion.Size = new System.Drawing.Size(56, 16);
            this.lblLicenseVersion.TabIndex = 7;
            this.lblLicenseVersion.Text = "Version:";
            // 
            // lblEdition
            // 
            this.lblEdition.AutoSize = true;
            this.lblEdition.Location = new System.Drawing.Point(15, 173);
            this.lblEdition.Name = "lblEdition";
            this.lblEdition.Size = new System.Drawing.Size(54, 16);
            this.lblEdition.TabIndex = 8;
            this.lblEdition.Text = "Type....:";
            // 
            // btnPatch
            // 
            this.btnPatch.Location = new System.Drawing.Point(376, 208);
            this.btnPatch.Name = "btnPatch";
            this.btnPatch.Size = new System.Drawing.Size(94, 29);
            this.btnPatch.TabIndex = 9;
            this.btnPatch.Text = "&Patch";
            this.btnPatch.UseVisualStyleBackColor = true;
            this.btnPatch.Click += new System.EventHandler(this.btnPatch_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.Color.White;
            this.pictureBox1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.pictureBox1.Image = global::StarUML_Keyfilemaker.Properties.Resources.banner;
            this.pictureBox1.Location = new System.Drawing.Point(12, 12);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(458, 85);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.pictureBox1.TabIndex = 4;
            this.pictureBox1.TabStop = false;
            // 
            // FormMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(482, 245);
            this.Controls.Add(this.btnPatch);
            this.Controls.Add(this.lblEdition);
            this.Controls.Add(this.lblLicenseVersion);
            this.Controls.Add(this.lblName);
            this.Controls.Add(this.lblCredits);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.cbLicenseType);
            this.Controls.Add(this.cbLicenseVersion);
            this.Controls.Add(this.txtName);
            this.Controls.Add(this.btnGenerate);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FormMain";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Load += new System.EventHandler(this.FormMain_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnGenerate;
        private System.Windows.Forms.TextBox txtName;
        private System.Windows.Forms.ComboBox cbLicenseVersion;
        private System.Windows.Forms.ComboBox cbLicenseType;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label lblCredits;
        private System.Windows.Forms.Label lblName;
        private System.Windows.Forms.Label lblLicenseVersion;
        private System.Windows.Forms.Label lblEdition;
        private System.Windows.Forms.Button btnPatch;
    }
}

