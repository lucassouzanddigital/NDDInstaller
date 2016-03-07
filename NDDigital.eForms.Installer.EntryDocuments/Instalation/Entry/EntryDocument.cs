using NDDigital.eForms.Installer.EntryDocuments.Controls.ProgressControls;
using NDDigital.eForms.Installer.EntryDocuments.Manager;
using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace NDDigital.eForms.Installer.EntryDocuments.Instalation.Entry
{
    public class EntryDocument
    {
        //Criação das pastas de destino das DLLs
        public void CreateFolderEntry()
        {
            if (!Directory.Exists(ControllerClass.PathFolder + @"\Connector\Entry Documents Service"))
            {
                Directory.CreateDirectory(ControllerClass.PathFolder + @"\Connector\Entry Documents Service");
            }

        }

        //Criação de chave de registro
        public void CreateNDDigitalRegKeys()
        {
            RegistryKey Servico;
            Servico = Registry.LocalMachine.CreateSubKey(@"SOFTWARE\NDDigital\eForms\Entry");
            Servico.SetValue("VersionControl", ControllerClass.VersionControl.ToString());
            Servico.SetValue("Version", ControllerClass.Version);
            Servico.SetValue("InstanceTotal", "1");

            Servico.Close();

        }

        //Verifica se já existe uma versão instalada ou é instalação zerada
        public static bool InstallEntryVerify()
        {
            int version = 0;
            string regKeyReturn = null;
            bool returns = false;

            RegistryKey registryKey = null;
            RegistryKey HKLM = RegistryKey.OpenBaseKey(RegistryHive.LocalMachine, RegistryView.Registry64);

            registryKey = HKLM.OpenSubKey(@"SOFTWARE\NDDigital\eForms\Entry");

            if (registryKey == null)
            {
                var HKLMX86 = RegistryKey.OpenBaseKey(RegistryHive.LocalMachine, RegistryView.Registry32);
                registryKey = HKLMX86.OpenSubKey(@"SOFTWARE\NDDigital\eForms\Entry");
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
                    MessageBox.Show("O Entry Documents Service já encontra-se instalado neste Ambiente!", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Error);

                }
                else if (version > ControllerClass.VersionControl)
                {
                    MessageBox.Show("Existe uma versão superior do Entry Dodocuments Service instalado neste Ambiente!", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Error);

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
            Servico = Registry.LocalMachine.CreateSubKey(@"SOFTWARE\NDDigital\eForms\Entry");
            Servico.SetValue("VersionControl", ControllerClass.VersionControl.ToString());
        }

    }
}

