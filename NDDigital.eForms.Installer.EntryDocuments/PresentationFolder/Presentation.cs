using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using NDDigital.eForms.Installer.EntryDocuments.Controls.ProgressControls;
using NDDigital.eForms.Installer.EntryDocuments.Manager;
using System.Diagnostics;
using NDDigital.eForms.Installer.EntryDocuments.Instalation;
using NDDigital.eForms.Installer.EntryDocuments.Service;
using NDDigital.eForms.Installer.EntryDocuments.Instalation.Entry;
using System.Threading;
using NDDigital.eForms.Installer.EntryDocuments.Compression;
using System.IO;

namespace NDDigital.eForms.Installer.EntryDocuments.PresentationFolder
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
