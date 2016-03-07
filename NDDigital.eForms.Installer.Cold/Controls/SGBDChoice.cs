using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using NDDigital.eForms.Installer.Cold.Controls.SGBDS;

namespace NDDigital.eForms.Installer.Cold.Controls
{
    public partial class SGBDChoice : UserControl
    {
        public SGBDChoice()
        {
            InitializeComponent();
        }

        private void btnAvanc_Click(object sender, EventArgs e)
        {
            UserControl _panControl;
            this.Controls.Clear();

            if (radioOracle.Checked)
            {
                _panControl = new OracleChoiced();
            }
            else
            {
                _panControl = new SQLChoiced();
            }

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
            UserControl _panControlStart;
            this.Controls.Clear();
            _panControlStart = new PresentationFolder.Presentation();
            this.Controls.Add(_panControlStart);
        }
    }
}
