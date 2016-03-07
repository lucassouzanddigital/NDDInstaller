using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using NDDigital.eForms.Installer.Connector.Controls;
using NDDigital.eForms.Installer.Connector.Controls.Manager;

namespace NDDigital.eForms.Installer.Connector.PresentationFolder
{
    public partial class Presentation : UserControl
    {
        public Presentation()
        {
            InitializeComponent();
        }

        //Ação botão avançar
        private void btnAvanc_Click(object sender, EventArgs e)
        {
            if (!ControllerClass.isUpdate)
            {
                UserControl _panControl;
                this.Controls.Clear();
                _panControl = new StartPageControl();
                this.Controls.Add(_panControl);
            }
            else
            {
                UserControl _panControl;
                this.Controls.Clear();
                _panControl = new Progress();
                this.Controls.Add(_panControl);
            }
        }

        //Ação Botao Cancelar
        private void btnCanc_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Deseja realmente cancelar a instalação?", "Atenção", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                StartPage.ActiveForm.Close();
            }
        }
    }
}
