using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using NDDigital.eForms.Installer.Connector;
using NDDigital.eForms.Installer.Connector.PresentationFolder;
using NDDigital.eForms.Installer.Connector.Controls.Oracle;
using NDDigital.eForms.Installer.Connector.Controls.Informix;
using NDDigital.eForms.Installer.Connector.Controls.SQL;

namespace NDDigital.eForms.Installer.Connector.Controls
{
    public partial class StartPageControl : UserControl
    {

        public StartPageControl()
        {
            InitializeComponent();

        }

        //Ação Botão Avançar
        private void btnAvanc_Click(object sender, EventArgs e)
        {
            UserControl _panControl;

            //SQL
            if (radiosql2005.Checked || radiosql2008.Checked || radiosql2012.Checked
                                                                            || radiosql2014.Checked)
            {
                this.Controls.Clear();
                _panControl = new ConnetionSQL();
                this.Controls.Add(_panControl);
            }


            //Oracle
            if (radiooracle.Checked)
            {
                this.Controls.Clear();
                _panControl = new ConnectionOracleInf();
                this.Controls.Add(_panControl);
            }

            //Informix
            if (radioinformix.Checked)
            {
                this.Controls.Clear();
                _panControl = new ConnectionInformixInf();
                this.Controls.Add(_panControl);

            }
        }

        //Ação Botão Cancelar
        private void btnCanc_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Deseja realmente cancelar a instalação?", "Atenção", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                StartPage.ActiveForm.Close();
            }
        }

        //Ação do botão voltar
        private void btnVoltar_Click(object sender, EventArgs e)
        {
            UserControl _panControl;
            this.Controls.Clear();
            _panControl = new Presentation();
            this.Controls.Add(_panControl);

        }
    }
}