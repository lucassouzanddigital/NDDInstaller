using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Runtime.InteropServices;
using System.Diagnostics;
using NDDigital.eForms.Installer.EntryDocuments.Manager;
using System.IO;

namespace NDDigital.eForms.Installer.EntryDocuments.PresentationFolder
{
    public partial class EndPresentation : UserControl
    {
        public EndPresentation()
        {
            InitializeComponent();

            System.IO.Directory.Delete(@"c:\Inst", true);

            if (!ControllerClass.isUpdate)
            {
                if (Directory.Exists(@"c:\delete"))
                {
                    System.IO.Directory.Delete(@"c:\delete", true);
                }
            }
        }

        private void BtnFinish_Click(object sender, EventArgs e)
        {
            if (restartNow.Checked == true)
            {
                StartPage.ActiveForm.Close();

                ProcessStartInfo psi = new ProcessStartInfo();
                psi.FileName = "shutdown.exe";
                psi.Arguments = "-r -f -t 0";
                psi.CreateNoWindow = true;
                Process p = Process.Start(psi);

            }
            else if (restartLater.Checked == true)
            {
                StartPage.ActiveForm.Close();
            }
        }
    }
}
