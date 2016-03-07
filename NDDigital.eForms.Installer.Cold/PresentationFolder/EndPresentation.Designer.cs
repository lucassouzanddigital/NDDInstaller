namespace NDDigital.eForms.Installer.Cold.PresentationFolder
{
    partial class EndPresentation
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(EndPresentation));
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.BtnFinish = new System.Windows.Forms.Button();
            this.restartNow = new System.Windows.Forms.RadioButton();
            this.restartLater = new System.Windows.Forms.RadioButton();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // textBox1
            // 
            this.textBox1.BackColor = System.Drawing.SystemColors.Control;
            this.textBox1.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox1.Location = new System.Drawing.Point(188, 3);
            this.textBox1.Multiline = true;
            this.textBox1.Name = "textBox1";
            this.textBox1.ReadOnly = true;
            this.textBox1.Size = new System.Drawing.Size(290, 270);
            this.textBox1.TabIndex = 39;
            this.textBox1.TabStop = false;
            this.textBox1.Text = resources.GetString("textBox1.Text");
            // 
            // pictureBox1
            // 
            this.pictureBox1.ErrorImage = ((System.Drawing.Image)(resources.GetObject("pictureBox1.ErrorImage")));
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.InitialImage = ((System.Drawing.Image)(resources.GetObject("pictureBox1.InitialImage")));
            this.pictureBox1.Location = new System.Drawing.Point(2, 106);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(196, 62);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 40;
            this.pictureBox1.TabStop = false;
            // 
            // BtnFinish
            // 
            this.BtnFinish.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.BtnFinish.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnFinish.Location = new System.Drawing.Point(401, 276);
            this.BtnFinish.Name = "BtnFinish";
            this.BtnFinish.Size = new System.Drawing.Size(75, 23);
            this.BtnFinish.TabIndex = 38;
            this.BtnFinish.Text = "Concluir";
            this.BtnFinish.UseVisualStyleBackColor = true;
            this.BtnFinish.Click += new System.EventHandler(this.BtnFinish_Click);
            // 
            // restartNow
            // 
            this.restartNow.AutoSize = true;
            this.restartNow.Location = new System.Drawing.Point(208, 181);
            this.restartNow.Name = "restartNow";
            this.restartNow.Size = new System.Drawing.Size(99, 17);
            this.restartNow.TabIndex = 41;
            this.restartNow.Text = "Reiniciar agora.";
            this.restartNow.UseVisualStyleBackColor = true;
            // 
            // restartLater
            // 
            this.restartLater.AutoSize = true;
            this.restartLater.Checked = true;
            this.restartLater.Location = new System.Drawing.Point(208, 204);
            this.restartLater.Name = "restartLater";
            this.restartLater.Size = new System.Drawing.Size(169, 17);
            this.restartLater.TabIndex = 42;
            this.restartLater.TabStop = true;
            this.restartLater.Text = "Reiniciar manualmente depois.";
            this.restartLater.UseVisualStyleBackColor = true;
            // 
            // EndPresentation
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.restartLater);
            this.Controls.Add(this.restartNow);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.BtnFinish);
            this.Name = "EndPresentation";
            this.Size = new System.Drawing.Size(479, 302);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Button BtnFinish;
        private System.Windows.Forms.RadioButton restartNow;
        private System.Windows.Forms.RadioButton restartLater;
    }
}
