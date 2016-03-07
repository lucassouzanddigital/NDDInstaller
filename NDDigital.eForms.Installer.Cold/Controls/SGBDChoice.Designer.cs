namespace NDDigital.eForms.Installer.Cold.Controls
{
    partial class SGBDChoice
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
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.radioOracle = new System.Windows.Forms.RadioButton();
            this.radioSQL = new System.Windows.Forms.RadioButton();
            this.groupDominio = new System.Windows.Forms.GroupBox();
            this.label1 = new System.Windows.Forms.Label();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.btnCanc = new System.Windows.Forms.Button();
            this.btnAvanc = new System.Windows.Forms.Button();
            this.btnVoltar = new System.Windows.Forms.Button();
            this.groupBox2.SuspendLayout();
            this.groupDominio.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.radioOracle);
            this.groupBox2.Controls.Add(this.radioSQL);
            this.groupBox2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            this.groupBox2.Location = new System.Drawing.Point(3, 3);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(473, 106);
            this.groupBox2.TabIndex = 41;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Selecione qual será o SGBD utilizado pelo Connector";
            // 
            // radioOracle
            // 
            this.radioOracle.AutoSize = true;
            this.radioOracle.Location = new System.Drawing.Point(9, 61);
            this.radioOracle.Name = "radioOracle";
            this.radioOracle.Size = new System.Drawing.Size(61, 19);
            this.radioOracle.TabIndex = 1;
            this.radioOracle.TabStop = true;
            this.radioOracle.Text = "Oracle";
            this.radioOracle.UseVisualStyleBackColor = true;
            // 
            // radioSQL
            // 
            this.radioSQL.AutoSize = true;
            this.radioSQL.Checked = true;
            this.radioSQL.Location = new System.Drawing.Point(9, 36);
            this.radioSQL.Name = "radioSQL";
            this.radioSQL.Size = new System.Drawing.Size(87, 19);
            this.radioSQL.TabIndex = 0;
            this.radioSQL.TabStop = true;
            this.radioSQL.Text = "SQL Server";
            this.radioSQL.UseVisualStyleBackColor = true;
            // 
            // groupDominio
            // 
            this.groupDominio.BackColor = System.Drawing.SystemColors.Control;
            this.groupDominio.Controls.Add(this.label1);
            this.groupDominio.Controls.Add(this.textBox1);
            this.groupDominio.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupDominio.Location = new System.Drawing.Point(3, 115);
            this.groupDominio.Name = "groupDominio";
            this.groupDominio.Size = new System.Drawing.Size(237, 66);
            this.groupDominio.TabIndex = 42;
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
            // btnCanc
            // 
            this.btnCanc.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCanc.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCanc.Location = new System.Drawing.Point(401, 276);
            this.btnCanc.Name = "btnCanc";
            this.btnCanc.Size = new System.Drawing.Size(75, 23);
            this.btnCanc.TabIndex = 43;
            this.btnCanc.Text = "Cancelar";
            this.btnCanc.UseVisualStyleBackColor = true;
            this.btnCanc.Click += new System.EventHandler(this.btnCanc_Click);
            // 
            // btnAvanc
            // 
            this.btnAvanc.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAvanc.Location = new System.Drawing.Point(310, 276);
            this.btnAvanc.Name = "btnAvanc";
            this.btnAvanc.Size = new System.Drawing.Size(75, 23);
            this.btnAvanc.TabIndex = 44;
            this.btnAvanc.Text = "Próximo >";
            this.btnAvanc.UseVisualStyleBackColor = true;
            this.btnAvanc.Click += new System.EventHandler(this.btnAvanc_Click);
            // 
            // btnVoltar
            // 
            this.btnVoltar.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnVoltar.Location = new System.Drawing.Point(229, 276);
            this.btnVoltar.Name = "btnVoltar";
            this.btnVoltar.Size = new System.Drawing.Size(75, 23);
            this.btnVoltar.TabIndex = 45;
            this.btnVoltar.Text = "< Voltar";
            this.btnVoltar.UseVisualStyleBackColor = true;
            this.btnVoltar.Click += new System.EventHandler(this.btnVoltar_Click);
            // 
            // SGBDChoice
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.btnVoltar);
            this.Controls.Add(this.btnCanc);
            this.Controls.Add(this.btnAvanc);
            this.Controls.Add(this.groupDominio);
            this.Controls.Add(this.groupBox2);
            this.Name = "SGBDChoice";
            this.Size = new System.Drawing.Size(479, 302);
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupDominio.ResumeLayout(false);
            this.groupDominio.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.GroupBox groupDominio;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.RadioButton radioOracle;
        private System.Windows.Forms.RadioButton radioSQL;
        private System.Windows.Forms.Button btnCanc;
        private System.Windows.Forms.Button btnAvanc;
        private System.Windows.Forms.Button btnVoltar;
    }
}
