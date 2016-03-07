using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
using NDDigital.eForms.Installer.Cold.Manager;
using NDDigital.eForms.Installer.Cold.Controls.SGBDS;

namespace NDDigital.eForms.Installer.Cold.Controls.PathsControls
{
    public partial class PathInstDir : UserControl
    {
        public PathInstDir()
        {
            InitializeComponent();
        }

        private void btnAvanc_Click(object sender, EventArgs e)
        {

            if (!Directory.Exists(txtInstDir.Text))
            {
                Directory.CreateDirectory(txtInstDir.Text);
            }

            UserControl _panControl;
            this.Controls.Clear();
            _panControl = new RootInstDir();
            ControllerClass.PathFolder = txtInstDir.Text + @"\eForms";
            this.Controls.Add(_panControl);
        }

        private void btnCanc_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Deseja realmente cancelar a instalação?", "Atenção", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                StartPage.ActiveForm.Close();
            }
        }

        private void btnVoltar_Click(object sender, EventArgs e)
        {
            UserControl _panControl;
            this.Controls.Clear();
            if (ControllerClass.SGBDChoiced == "Oracle")
            {
                _panControl = new OracleChoiced();
            }
            else
            {
                _panControl = new SQLChoiced();
            }

            this.Controls.Add(_panControl);
        }

        private void btnInstDir_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog choiceFolder = new FolderBrowserDialog();
            choiceFolder.ShowDialog();
            if (choiceFolder.SelectedPath != "")
            {
                txtInstDir.Text = choiceFolder.SelectedPath;
            }
        }
    }
}
