using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Diagnostics;
using System.IO;
using NDDigital.eForms.Installer.Connector.Controls.Manager;
using NDDigital.eForms.Installer.Connector.Controls.PathControls;
using NDDigital.eForms.Installer.Connector;


namespace NDDigital.eForms.Installer.Connector.Controls.PathControls
{
    public partial class AllConfigurationControl : UserControl
    {

        //  Instalacao instalacao = new Instalacao();

        public AllConfigurationControl()
        {
            InitializeComponent();

            //Cria TreeView com nodes (Nodes - caminhos escolhidos pelo usuario)
            treeView1.Nodes.Add("Pasta de instalação").Nodes.Add(ControllerClass.PathFolder);
            treeView1.Nodes.Add("Pasta de trabalho").Nodes.Add(ControllerClass.WorkFolder);
            treeView1.Nodes.Add("Pasta e-Monitor").Nodes.Add(ControllerClass.RootFolder);
            treeView1.Nodes.Add("Componentes");

            treeView1.ExpandAll();
        }

        //Ação botão voltar
        private void btnVoltar_Click(object sender, EventArgs e)
        {
            UserControl _panControl;
            this.Controls.Clear();
            _panControl = new WorkFolderInstDir();
            this.Controls.Add(_panControl);
        }

        //Ação botão avançar
        private void btnAvanc_Click(object sender, EventArgs e)
        {
            UserControl _panControl;
            this.Controls.Clear();
            _panControl = new Progress();
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