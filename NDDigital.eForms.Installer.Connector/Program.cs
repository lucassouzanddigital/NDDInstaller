using NDDigital.eForms.Installer.Connector.Controls.Manager;
using NDDigital.eForms.Installer.Connector.Instalation.Connector;
using NDDigital.eForms.Installer.Connector.Verification;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Windows.Forms;

namespace NDDigital.eForms.Installer.Connector
{
    static class Program
    {
        //static bool autenticacaoUsuario = false;
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            //autenticacaoUsuario = System.Security.Principal.WindowsIdentity.GetCurrent().IsAuthenticated;

            if (IsAdministrator())
            {
                if (Verifications.ValidaWindows())
                {
                    if (!Verifications.VerificaIIS())
                    {
                        if (eConnector.InstallConnectorVerify())
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
                        MessageBox.Show("O Internet Information Service não está instalado e este é um pré-requisito para prosseguir com a instalação. Instale o Internet Information Service e execute o instalador do e-Connector novamente."
                                                                                       , "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                else
                {
                    MessageBox.Show("O e-Forms não está homologado para o Sistema Operacional atual: " + Verifications.ProductName +
                                                                                      ". Não é possível prosseguir.", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
