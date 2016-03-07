using Installer.Instalation.Import;
using Installer.Manager;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Windows.Forms;

namespace Installer
{
    static class Program
    {
        //static bool userAuthenticate = false;
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            //userAuthenticate = System.Security.Principal.WindowsIdentity.GetCurrent().IsAuthenticated;

            if (IsAdministrator())
            {
                if (ControllerClass.PathConnectorVerify())
                {
                    if (ImportService.InstallImportVerify())
                    {
                        
                        Application.EnableVisualStyles();
                        Application.SetCompatibleTextRenderingDefault(false);
                        Application.Run(new StartPage());

                    }
                    else
                   {
                       Application.Exit();

                    }
                }
                else
               {
                    MessageBox.Show("Connector service não está instalado!" + " Não é possível prosseguir.", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }

            else
            {

                MessageBox.Show("O usuário da sessão atual não possui direitos de administrador para realizar a instalação." +
                                                                                      " Não é possível prosseguir.", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Error);

                Application.Exit();
            }
        }

        private static bool IsAdministrator()
        {
            WindowsIdentity identity = WindowsIdentity.GetCurrent();
            WindowsPrincipal principal = new WindowsPrincipal(identity);
            return principal.IsInRole(WindowsBuiltInRole.Administrator);
        }
    }
}
