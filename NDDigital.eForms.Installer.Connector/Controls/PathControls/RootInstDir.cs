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

namespace  NDDigital.eForms.Installer.Connector.Controls.PathControls
{
    public partial class RootInstDir : UserControl
    {
        

        public RootInstDir()
        {
            InitializeComponent();
        }

        //Ação botão voltar
        private void btnVoltar_Click(object sender, EventArgs e)
        {
            UserControl _panControl;
            this.Controls.Clear();
            _panControl = new PathInstDir();
            this.Controls.Add(_panControl);
        }

        //Ação botão avançar
        private void btnAvanc_Click(object sender, EventArgs e)
        {
            if (!Directory.Exists(txtRootDir.Text))
            {
                Directory.CreateDirectory(txtRootDir.Text);
            }

            UserControl _panControl;
            this.Controls.Clear();
            _panControl = new WorkFolderInstDir();
            this.Controls.Add(_panControl);
            ControllerClass.RootFolder = txtRootDir.Text;
            
        }

        //Ação botão cancelar
        private void btnCanc_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Deseja realmente cancelar a instalação?", "Atenção", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                StartPage.ActiveForm.Close();
            }  
        }

        //Ação botão escolher pasta
        private void btnRootDir_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog choiceFolder = new FolderBrowserDialog();
            choiceFolder.ShowDialog();
            if (choiceFolder.SelectedPath != "")
            {
                txtRootDir.Text = choiceFolder.SelectedPath;
            }
        }

    }
}
