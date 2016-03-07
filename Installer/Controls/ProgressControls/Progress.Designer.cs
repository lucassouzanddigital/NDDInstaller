namespace Installer.Controls.ProgressControls
{
    partial class Progress
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Progress));
            this.BtnNext = new System.Windows.Forms.Button();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.PctImport = new System.Windows.Forms.PictureBox();
            this.progressStatus = new System.Windows.Forms.ProgressBar();
            this.lblCopy = new System.Windows.Forms.Label();
            this.lblFile = new System.Windows.Forms.Label();
            this.lblProImport = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.PctImport)).BeginInit();
            this.SuspendLayout();
            // 
            // BtnNext
            // 
            this.BtnNext.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.BtnNext.Enabled = false;
            this.BtnNext.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnNext.Location = new System.Drawing.Point(401, 276);
            this.BtnNext.Name = "BtnNext";
            this.BtnNext.Size = new System.Drawing.Size(75, 23);
            this.BtnNext.TabIndex = 41;
            this.BtnNext.Text = "Avançar >";
            this.BtnNext.UseVisualStyleBackColor = true;
            this.BtnNext.Click += new System.EventHandler(this.BtnNext_Click);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.PctImport);
            this.groupBox2.Controls.Add(this.progressStatus);
            this.groupBox2.Controls.Add(this.lblCopy);
            this.groupBox2.Controls.Add(this.lblFile);
            this.groupBox2.Controls.Add(this.lblProImport);
            this.groupBox2.Controls.Add(this.label5);
            this.groupBox2.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox2.Location = new System.Drawing.Point(3, 29);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(473, 233);
            this.groupBox2.TabIndex = 40;
            this.groupBox2.TabStop = false;
            // 
            // PctImport
            // 
            this.PctImport.Image = ((System.Drawing.Image)(resources.GetObject("PctImport.Image")));
            this.PctImport.Location = new System.Drawing.Point(220, 25);
            this.PctImport.Name = "PctImport";
            this.PctImport.Size = new System.Drawing.Size(23, 24);
            this.PctImport.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.PctImport.TabIndex = 33;
            this.PctImport.TabStop = false;
            this.PctImport.Visible = false;
            // 
            // progressStatus
            // 
            this.progressStatus.Location = new System.Drawing.Point(24, 82);
            this.progressStatus.Name = "progressStatus";
            this.progressStatus.Size = new System.Drawing.Size(443, 21);
            this.progressStatus.Style = System.Windows.Forms.ProgressBarStyle.Continuous;
            this.progressStatus.TabIndex = 37;
            // 
            // lblCopy
            // 
            this.lblCopy.AutoSize = true;
            this.lblCopy.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            this.lblCopy.Location = new System.Drawing.Point(19, 106);
            this.lblCopy.Name = "lblCopy";
            this.lblCopy.Size = new System.Drawing.Size(0, 15);
            this.lblCopy.TabIndex = 36;
            // 
            // lblFile
            // 
            this.lblFile.AutoSize = true;
            this.lblFile.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            this.lblFile.Location = new System.Drawing.Point(101, 106);
            this.lblFile.Name = "lblFile";
            this.lblFile.Size = new System.Drawing.Size(0, 15);
            this.lblFile.TabIndex = 35;
            // 
            // lblProImport
            // 
            this.lblProImport.AutoSize = true;
            this.lblProImport.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblProImport.ForeColor = System.Drawing.Color.Black;
            this.lblProImport.Location = new System.Drawing.Point(130, 34);
            this.lblProImport.Name = "lblProImport";
            this.lblProImport.Size = new System.Drawing.Size(0, 18);
            this.lblProImport.TabIndex = 28;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.label5.ForeColor = System.Drawing.SystemColors.WindowText;
            this.label5.Location = new System.Drawing.Point(17, 34);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(102, 17);
            this.label5.TabIndex = 23;
            this.label5.Text = "Import Service:";
            // 
            // Progress
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.BtnNext);
            this.Controls.Add(this.groupBox2);
            this.Name = "Progress";
            this.Size = new System.Drawing.Size(479, 302);
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.PctImport)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button BtnNext;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.ProgressBar progressStatus;
        private System.Windows.Forms.Label lblCopy;
        private System.Windows.Forms.Label lblFile;
        private System.Windows.Forms.PictureBox PctImport;
        public System.Windows.Forms.Label lblProImport;
        private System.Windows.Forms.Label label5;

    }
}
