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
using NDDigital.eForms.Installer.Connector.Controls.SQL;
using NDDigital.eForms.Installer.Connector.Controls.Manager;

namespace NDDigital.eForms.Installer.Connector.Controls.PathControls
{
    public partial class PathInstDir : UserControl
    {

        public PathInstDir()
        {
            InitializeComponent();

        }

        //Ação botão escolher pasta
        private void button1_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog choiceFolder = new FolderBrowserDialog();
            choiceFolder.ShowDialog();
            if (choiceFolder.SelectedPath != "")
            {
                txtInstDir.Text = choiceFolder.SelectedPath;
            }
        }

        //Ação botão voltar
        private void btnVoltar_Click(object sender, EventArgs e)
        {
            UserControl _panControl;
            this.Controls.Clear();
            _panControl = new ConnectionSQLCold();
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

        //Ação botão avançar
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
    }
}
