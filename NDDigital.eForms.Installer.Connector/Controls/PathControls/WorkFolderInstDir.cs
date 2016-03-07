using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using NDDigital.eForms.Installer.Connector.Controls.Manager;
using NDDigital.eForms.Installer.Connector.Controls.PathControls;
using NDDigital.eForms.Installer.Connector;

namespace NDDigital.eForms.Installer.Connector.Controls.PathControls
{
    public partial class WorkFolderInstDir : UserControl
    {
       
        public WorkFolderInstDir()
        {
            InitializeComponent();
        }

        //Ação botão escolher pasta
        private void btnWorkDir_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog choiceFolder = new FolderBrowserDialog();
            choiceFolder.ShowDialog();
            if (choiceFolder.SelectedPath != "")
            {
                txtWorkDir.Text = choiceFolder.SelectedPath;
            }
        }

        //Ação botão avançar
        private void btnAvanc_Click(object sender, EventArgs e)
        {
            if (!Directory.Exists(txtWorkDir.Text))
            {
                Directory.CreateDirectory(txtWorkDir.Text);
            }

            ControllerClass.WorkFolder = txtWorkDir.Text;
            UserControl _panControl;
            this.Controls.Clear();
            _panControl = new AllConfigurationControl();
            this.Controls.Add(_panControl);
            
        }

        //Ação botão voltar
        private void btnVoltar_Click(object sender, EventArgs e)
        {
            UserControl _panControl;
            this.Controls.Clear();
            _panControl = new RootInstDir();
            this.Controls.Add(_panControl);
        }

        //Ação botão cancelar
        private void btnCanc_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Deseja realmente cancelar a instalação?", "Atenção", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                StartPage.ActiveForm.Close();
            }  
        }
    }
}
