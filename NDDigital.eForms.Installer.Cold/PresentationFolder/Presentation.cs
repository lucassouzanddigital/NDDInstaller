using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using NDDigital.eForms.Installer.Cold.Controls.ProgressControls;
using NDDigital.eForms.Installer.Cold.Manager;
using System.Diagnostics;
using NDDigital.eForms.Installer.Cold.Instalation;
using NDDigital.eForms.Installer.Cold.Service;
using NDDigital.eForms.Installer.Cold.Instalation.Entry;
using System.Threading;
using NDDigital.eForms.Installer.Cold.Compression;
using System.IO;
using NDDigital.eForms.Installer.Cold.Controls;

namespace NDDigital.eForms.Installer.Cold.PresentationFolder
{
    public partial class Presentation : UserControl
    {

        public Presentation()
        {
            InitializeComponent();
        }

        //Ação botão avançar
        private void BtnNext_Click(object sender, EventArgs e)
        {
            UserControl _panControl;
            this.Controls.Clear();
            _panControl = new SGBDChoice();
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
