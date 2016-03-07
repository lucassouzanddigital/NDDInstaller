using Installer.Controls.ProgressControls;
using Installer.Manager;
using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Installer.Instalation.Import
{
    public class ImportService
    {
        //Criação das pastas de destino das DLLs
        public void CreateFolderImport()
        {
            if (!Directory.Exists(ControllerClass.PathFolder + @"\Connector\Import Service"))
            {
                Directory.CreateDirectory(ControllerClass.PathFolder + @"\Connector\Import Service");
            }

        }

        //Criação de chave de registro
        public void CreateConferencingRegKeys()
        {
            RegistryKey Conferencing;
            Conferencing = Registry.LocalMachine.CreateSubKey(@"SOFTWARE\Microsoft\Conferencing\XmlImportService");
            Conferencing.SetValue("Enable", "");
            Conferencing.Close();


        }

        //Criação de chave de registro
        public void CreateNDDigitalRegKeys()
        {
            RegistryKey Servico;
            Servico = Registry.LocalMachine.CreateSubKey(@"SOFTWARE\NDDigital\eForms\XmlImportService");
            Servico.SetValue("VersionControl", ControllerClass.VersionControl.ToString());
            Servico.SetValue("InstallLocation", ControllerClass.PathFolder + @"\Connector\Import Service");

            Servico.Close();

        }

        //Verifica se já existe uma versão instalada ou é instalação zerada
        public static bool InstallImportVerify()
        {
            int version = 0;
            string regKeyReturn = null;
            bool returns = false;

            RegistryKey registryKey = null;
            RegistryKey HKLM = RegistryKey.OpenBaseKey(RegistryHive.LocalMachine, RegistryView.Registry64);

            registryKey = HKLM.OpenSubKey(@"SOFTWARE\NDDigital\eForms\XmlImportService");

            if (registryKey == null)
            {
                var HKLMX86 = RegistryKey.OpenBaseKey(RegistryHive.LocalMachine, RegistryView.Registry32);
                registryKey = HKLMX86.OpenSubKey(@"SOFTWARE\NDDigital\eForms\XmlImportService");
            }

            try
            {
                regKeyReturn = registryKey.GetValue("VersionControl").ToString();
                version = Convert.ToInt32(regKeyReturn);
            }
            catch (Exception) { }
            finally { }


            if (regKeyReturn != null)
            {


                if (version == ControllerClass.VersionControl)
                {
                    MessageBox.Show("O Import Service já encontra-se instalado neste Ambiente!", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Error);

                }
                else if (version > ControllerClass.VersionControl)
                {
                    MessageBox.Show("Existe uma versão superior do Import Service instalado neste Ambiente!", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Error);

                }
                else
                {
                    ControllerClass.isUpdate = true;
                    returns = true;
                }
            }
            else { returns = true; }
            return returns;

        }

        //Atualiza chave de registro com a versão instalada
        public static void VersionControlUpdate()
        {
            RegistryKey Servico;
            Servico = Registry.LocalMachine.CreateSubKey(@"SOFTWARE\NDDigital\eForms\XmlImportService");
            Servico.SetValue("VersionControl", ControllerClass.VersionControl.ToString());
        }

    }
}

