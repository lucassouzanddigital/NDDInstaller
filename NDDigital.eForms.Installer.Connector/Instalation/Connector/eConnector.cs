using Microsoft.Win32;
using NDDigital.eForms.Installer.Connector.Controls.Manager;
using NDDigital.eForms.Installer.Connector.Controls.SQL;
using NDDigital.eForms.Installer.Connector.Verification;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Windows.Forms;

namespace NDDigital.eForms.Installer.Connector.Instalation.Connector
{
    public static class eConnector
    {
        private static SymmetricAlgorithm symAlg = new RijndaelManaged();
        private static string strChaveVI = "C#&UjO){QwzFcsPs";
        public static string DefaultKey = "%$#@!a12345";

        public static void CreateFolderConnector()
        {
            if (!Directory.Exists(ControllerClass.PathFolder + @"\Connector\Connector Settings"))
            {
                Directory.CreateDirectory(ControllerClass.PathFolder + @"\Connector\Connector Settings");
            }

            if (!Directory.Exists(ControllerClass.PathFolder + @"\Connector\Connector Service"))
            {
                Directory.CreateDirectory(ControllerClass.PathFolder + @"\Connector\Connector Service");
            }

            if (!Directory.Exists(ControllerClass.PathFolder + @"\Connector\Connector Services"))
            {
                Directory.CreateDirectory(ControllerClass.PathFolder + @"\Connector\Connector Services");
            }

            if (!Directory.Exists(ControllerClass.PathFolder + @"\Connector\Connector Services"))
            {
                Directory.CreateDirectory(ControllerClass.PathFolder + @"\Connector\Connector Services");
            }

            if (!Directory.Exists(ControllerClass.PathFolder + @"\Connector\B2B Service"))
            {
                Directory.CreateDirectory(ControllerClass.PathFolder + @"\Connector\B2B Service");
            }
            
            if (!Directory.Exists(ControllerClass.PathFolder + @"\Connector\DPEC Server"))
            {
                Directory.CreateDirectory(ControllerClass.PathFolder + @"\Connector\DPEC Server");
            }

            if (!Directory.Exists(ControllerClass.PathFolder + @"\Componentes"))
            {
                Directory.CreateDirectory(ControllerClass.PathFolder + @"\Componentes");
            }

        }

        //Criação de chave de registro
        public static void CreateNDDigitalRegKeys()
        {
            RegistryKey NDDigital;
            NDDigital = Registry.LocalMachine.CreateSubKey(@"SOFTWARE\NDDigital\eForms\Connector");
            NDDigital.SetValue("VersionControl", ControllerClass.VersionControl.ToString());
            NDDigital.SetValue("Version", ControllerClass.Version);
            NDDigital.SetValue("Provider", "2");
            NDDigital.SetValue("ConnectionString", Encrypt(DefaultKey, "user id=" + ConnetionSQL.UserConnectorSQL + ";password=" + ConnetionSQL.SenhaConnectorSQL + ";server=" + ConnetionSQL.ServidorConnectorSQL + ";database=" + ConnetionSQL.SGBDConnectorSQL + ";connection timeout=150"));
            NDDigital.SetValue("PrintERPDirectory", ControllerClass.WorkFolder + @"\eForms\PrintERPDirectory");
            NDDigital.SetValue("DPECDirectory", ControllerClass.WorkFolder + @"\eForms\DPECDirectory");
            NDDigital.SetValue("InstanceTotal1", "1");
            NDDigital.SetValue("InstanceTotal", "1");
            NDDigital.SetValue("PathWorkFolder", ControllerClass.WorkFolder + @"\eForms");

            NDDigital.Close();

            RegistryKey RegistroUninstallConnector;
            RegistroUninstallConnector = Registry.LocalMachine.CreateSubKey(@"Software\Microsoft\Windows\CurrentVersion\Uninstall\NDDigital eForms Connector");
            RegistroUninstallConnector.SetValue("InstallLocation", ControllerClass.PathFolder);
            RegistroUninstallConnector.Close();

        }

        //Verifica se já existe uma versão instalada ou é instalação zerada
        public static bool InstallConnectorVerify()
        {
            int version = 0;
            string returnRegKey = null;
            bool retorns = false;
            RegistryKey registryKey = null;
            RegistryKey HKLM = RegistryKey.OpenBaseKey(RegistryHive.LocalMachine, RegistryView.Registry64);

            registryKey = HKLM.OpenSubKey(@"SOFTWARE\NDDigital\eForms\Connector");

            if (registryKey == null)
            {
                var HKLMX86 = RegistryKey.OpenBaseKey(RegistryHive.LocalMachine, RegistryView.Registry32);
                registryKey = HKLMX86.OpenSubKey(@"SOFTWARE\NDDigital\eForms\Connector");
            }

            try
            {
                returnRegKey = registryKey.GetValue("VersionControl").ToString();
                version = Convert.ToInt32(returnRegKey);
            }
            catch (Exception) { }
            finally { }


            if (returnRegKey != null)
            {
                if (version == ControllerClass.VersionControl)
                {
                    MessageBox.Show("O e-Connector já encontra-se instalada neste Ambiente!", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Error);

                }
                else if (version > ControllerClass.VersionControl)
                {
                    MessageBox.Show("Existe uma versão superior do e-Connector instalada neste Ambiente!", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Error);

                }
                else
                {
                    ControllerClass.isUpdate = true;
                    retorns = true;
                }
            }

            else { retorns = true; }
            return retorns;

        }

        //Atualiza chave de registro com a versão instalada
        public static void VersionControlUpdate()
        {
            RegistryKey Service;
            Service = Registry.LocalMachine.CreateSubKey(@"SOFTWARE\NDDigital\eForms\Connector");
            Service.SetValue("VersionControl", ControllerClass.VersionControl.ToString());
        }
        
        //Criptografa a Connection String do e-Forms
        public static string Encrypt(string key, string str)
        {
            ICryptoTransform encryptor = symAlg.CreateEncryptor(Encoding.ASCII.GetBytes(key), Encoding.ASCII.GetBytes(strChaveVI));
            ASCIIEncoding ascii = new ASCIIEncoding();
            byte[] textBytes = ascii.GetBytes(str);
            byte[] cryptTextBytes = Operation(encryptor, textBytes);

            return (Convert.ToBase64String(cryptTextBytes));
        }

        private static byte[] Operation(ICryptoTransform op, byte[] input)
        {
            MemoryStream msOutput = new MemoryStream();

            CryptoStream encStream = new CryptoStream(msOutput, op, CryptoStreamMode.Write);
            encStream.Write(input, 0, input.Length);
            encStream.Close();

            return msOutput.ToArray();
        }
        
        public static bool VerifyDBMGRResult()
        {
            bool result;

            string ok = Verifications.HKLM_GetString(@"SOFTWARE\NDDigital\eForms\Connector", "DBMGR_Status");
            
            if(ok == "1")
            {
                result = true;
            }
            else
            {
                result = false;
            }
            return result;
        }
    }
}

