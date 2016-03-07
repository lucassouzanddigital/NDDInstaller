using NDDigital.eForms.Installer.Cold.Controls.ProgressControls;
using NDDigital.eForms.Installer.Cold.Manager;
using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace NDDigital.eForms.Installer.Cold.Instalation.Entry
{
    public class ColdProcessor
    {
        //Criação das pastas de destino das DLLs
        public void CreateFolderEntry()
        {
            if (!Directory.Exists(ControllerClass.PathFolder + @"\Cold\Cold Processor Service"))
            {
                Directory.CreateDirectory(ControllerClass.PathFolder + @"\Cold\Cold Processor Service");
            }

            if (!Directory.Exists(ControllerClass.RootFolder + @"\Webs\ColdService"))
            {
                Directory.CreateDirectory(ControllerClass.RootFolder + @"\Webs\ColdService");
            }

            if (!Directory.Exists(ControllerClass.RootFolder + @"\Webs\ColdWeb"))
            {
                Directory.CreateDirectory(ControllerClass.RootFolder + @"\Webs\ColdWeb");
            }
        }

        //Criação de chave de registro
        public void CreateNDDigitalRegKeys()
        {
            RegistryKey Servico;
            Servico = Registry.LocalMachine.CreateSubKey(@"SOFTWARE\NDDigital\eForms\Cold");
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

            registryKey = HKLM.OpenSubKey(@"SOFTWARE\NDDigital\eForms\Cold");

            if (registryKey == null)
            {
                var HKLMX86 = RegistryKey.OpenBaseKey(RegistryHive.LocalMachine, RegistryView.Registry32);
                registryKey = HKLMX86.OpenSubKey(@"SOFTWARE\NDDigital\eForms\Cold");
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
                    MessageBox.Show("O NDDigital Cold já encontra-se instalado neste Ambiente!", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Error);

                }
                else if (version > ControllerClass.VersionControl)
                {
                    MessageBox.Show("Existe uma versão superior do NDDigital Cold Service instalado neste Ambiente!", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Error);

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
            Servico = Registry.LocalMachine.CreateSubKey(@"SOFTWARE\NDDigital\eForms\Cold");
            Servico.SetValue("VersionControl", ControllerClass.VersionControl.ToString());
        }

    }
}

