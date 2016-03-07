namespace  NDDigital.eForms.Installer.Connector.Controls
{
    partial class StartPageControl
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
            this.groupDominio = new System.Windows.Forms.GroupBox();
            this.label1 = new System.Windows.Forms.Label();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.groupSGBDs = new System.Windows.Forms.GroupBox();
            this.radiosql2005 = new System.Windows.Forms.RadioButton();
            this.radiosql2008 = new System.Windows.Forms.RadioButton();
            this.radiosql2012 = new System.Windows.Forms.RadioButton();
            this.radiosql2014 = new System.Windows.Forms.RadioButton();
            this.radiooracle = new System.Windows.Forms.RadioButton();
            this.radioinformix = new System.Windows.Forms.RadioButton();
            this.btnCanc = new System.Windows.Forms.Button();
            this.btnAvanc = new System.Windows.Forms.Button();
            this.btnVoltar = new System.Windows.Forms.Button();
            this.groupDominio.SuspendLayout();
            this.groupSGBDs.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupDominio
            // 
            this.groupDominio.BackColor = System.Drawing.SystemColors.Control;
            this.groupDominio.Controls.Add(this.label1);
            this.groupDominio.Controls.Add(this.textBox1);
            this.groupDominio.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupDominio.Location = new System.Drawing.Point(3, 197);
            this.groupDominio.Name = "groupDominio";
            this.groupDominio.Size = new System.Drawing.Size(237, 66);
            this.groupDominio.TabIndex = 8;
            this.groupDominio.TabStop = false;
            this.groupDominio.Text = "Domínio";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 31);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(86, 15);
            this.label1.TabIndex = 1;
            this.label1.Text = "Novo domínio:";
            // 
            // textBox1
            // 
            this.textBox1.Enabled = false;
            this.textBox1.Location = new System.Drawing.Point(98, 28);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(117, 21);
            this.textBox1.TabIndex = 0;
            // 
            // groupSGBDs
            // 
            this.groupSGBDs.BackColor = System.Drawing.SystemColors.Control;
            this.groupSGBDs.Controls.Add(this.radiosql2005);
            this.groupSGBDs.Controls.Add(this.radiosql2008);
            this.groupSGBDs.Controls.Add(this.radiosql2012);
            this.groupSGBDs.Controls.Add(this.radiosql2014);
            this.groupSGBDs.Controls.Add(this.radiooracle);
            this.groupSGBDs.Controls.Add(this.radioinformix);
            this.groupSGBDs.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupSGBDs.Location = new System.Drawing.Point(3, 3);
            this.groupSGBDs.Name = "groupSGBDs";
            this.groupSGBDs.Size = new System.Drawing.Size(473, 188);
            this.groupSGBDs.TabIndex = 7;
            this.groupSGBDs.TabStop = false;
            this.groupSGBDs.Text = "Selecione o SGBD a ser utilizado";
            // 
            // radiosql2005
            // 
            this.radiosql2005.AutoSize = true;
            this.radiosql2005.Checked = true;
            this.radiosql2005.Location = new System.Drawing.Point(9, 30);
            this.radiosql2005.Name = "radiosql2005";
            this.radiosql2005.Size = new System.Drawing.Size(213, 19);
            this.radiosql2005.TabIndex = 11;
            this.radiosql2005.TabStop = true;
            this.radiosql2005.Text = "SQL SERVER OU EXPRESS 2005";
            this.radiosql2005.UseVisualStyleBackColor = true;
            // 
            // radiosql2008
            // 
            this.radiosql2008.AutoSize = true;
            this.radiosql2008.Location = new System.Drawing.Point(9, 52);
            this.radiosql2008.Name = "radiosql2008";
            this.radiosql2008.Size = new System.Drawing.Size(213, 19);
            this.radiosql2008.TabIndex = 10;
            this.radiosql2008.Text = "SQL SERVER OU EXPRESS 2008";
            this.radiosql2008.UseVisualStyleBackColor = true;
            // 
            // radiosql2012
            // 
            this.radiosql2012.AutoSize = true;
            this.radiosql2012.Location = new System.Drawing.Point(9, 75);
            this.radiosql2012.Name = "radiosql2012";
            this.radiosql2012.Size = new System.Drawing.Size(213, 19);
            this.radiosql2012.TabIndex = 9;
            this.radiosql2012.Text = "SQL SERVER OU EXPRESS 2012";
            this.radiosql2012.UseVisualStyleBackColor = true;
            // 
            // radiosql2014
            // 
            this.radiosql2014.AutoSize = true;
            this.radiosql2014.Location = new System.Drawing.Point(9, 97);
            this.radiosql2014.Name = "radiosql2014";
            this.radiosql2014.Size = new System.Drawing.Size(213, 19);
            this.radiosql2014.TabIndex = 8;
            this.radiosql2014.Text = "SQL SERVER OU EXPRESS 2014";
            this.radiosql2014.UseVisualStyleBackColor = true;
            // 
            // radiooracle
            // 
            this.radiooracle.AutoSize = true;
            this.radiooracle.Location = new System.Drawing.Point(9, 121);
            this.radiooracle.Name = "radiooracle";
            this.radiooracle.Size = new System.Drawing.Size(73, 19);
            this.radiooracle.TabIndex = 7;
            this.radiooracle.Text = "ORACLE";
            this.radiooracle.UseVisualStyleBackColor = true;
            // 
            // radioinformix
            // 
            this.radioinformix.AutoSize = true;
            this.radioinformix.Location = new System.Drawing.Point(9, 144);
            this.radioinformix.Name = "radioinformix";
            this.radioinformix.Size = new System.Drawing.Size(84, 19);
            this.radioinformix.TabIndex = 6;
            this.radioinformix.Text = "INFORMIX";
            this.radioinformix.UseVisualStyleBackColor = true;
            // 
            // btnCanc
            // 
            this.btnCanc.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCanc.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCanc.Location = new System.Drawing.Point(401, 276);
            this.btnCanc.Name = "btnCanc";
            this.btnCanc.Size = new System.Drawing.Size(75, 23);
            this.btnCanc.TabIndex = 3;
            this.btnCanc.Text = "Cancelar";
            this.btnCanc.UseVisualStyleBackColor = true;
            this.btnCanc.Click += new System.EventHandler(this.btnCanc_Click);
            // 
            // btnAvanc
            // 
            this.btnAvanc.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btnAvanc.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAvanc.Location = new System.Drawing.Point(311, 276);
            this.btnAvanc.Name = "btnAvanc";
            this.btnAvanc.Size = new System.Drawing.Size(75, 23);
            this.btnAvanc.TabIndex = 2;
            this.btnAvanc.Text = "Próximo >";
            this.btnAvanc.UseVisualStyleBackColor = true;
            this.btnAvanc.Click += new System.EventHandler(this.btnAvanc_Click);
            // 
            // btnVoltar
            // 
            this.btnVoltar.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnVoltar.Location = new System.Drawing.Point(230, 276);
            this.btnVoltar.Name = "btnVoltar";
            this.btnVoltar.Size = new System.Drawing.Size(75, 23);
            this.btnVoltar.TabIndex = 1;
            this.btnVoltar.Text = "< Voltar";
            this.btnVoltar.UseVisualStyleBackColor = true;
            this.btnVoltar.Click += new System.EventHandler(this.btnVoltar_Click);
            // 
            // StartPageControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.groupSGBDs);
            this.Controls.Add(this.groupDominio);
            this.Controls.Add(this.btnVoltar);
            this.Controls.Add(this.btnCanc);
            this.Controls.Add(this.btnAvanc);
            this.Name = "StartPageControl";
            this.Size = new System.Drawing.Size(479, 302);
            this.groupDominio.ResumeLayout(false);
            this.groupDominio.PerformLayout();
            this.groupSGBDs.ResumeLayout(false);
            this.groupSGBDs.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupDominio;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.GroupBox groupSGBDs;
        private System.Windows.Forms.RadioButton radiosql2005;
        private System.Windows.Forms.RadioButton radiosql2008;
        private System.Windows.Forms.RadioButton radiosql2012;
        private System.Windows.Forms.RadioButton radiosql2014;
        private System.Windows.Forms.RadioButton radiooracle;
        private System.Windows.Forms.RadioButton radioinformix;
        private System.Windows.Forms.Button btnCanc;
        private System.Windows.Forms.Button btnAvanc;
        private System.Windows.Forms.Button btnVoltar;
    }
}
