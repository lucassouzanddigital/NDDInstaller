using Microsoft.Win32;
using NDDigital.eForms.Installer.Connector.Verification;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NDDigital.eForms.Installer.Connector.Controls.Manager
{
    public class ControllerClass
    {
        public static string Version = "4.5.7.0";

        public static int VersionControl = 4570;

        public static bool isUpdate { get; set; }

        //guardando caminho escolhidos na instalação
        public static string RootFolder { get; set; }
        public static string WorkFolder { get; set; }
        public static string PathFolder = null;

        public static void VerifyRegKeysIFUpdate()
        {
            if (isUpdate)
            {
                WorkFolder = Verifications.HKLM_GetString(@"SOFTWARE\NDDigital\eForms\Connector", "PathWorkFolder");
                PathFolder = Verifications.HKLM_GetString(@"SOFTWARE\Microsoft\Windows\CurrentVersion\Uninstall\NDDigital eForms Connector", "InstallLocation");
                RootFolder = Verifications.HKLM_GetString(@"SOFTWARE\NDDigital\eForms\Connector", "PathWorkFolder");
            }
        }

        public static bool PathConnectorVerify()
        {
            RegistryKey registryKey = null;
            bool retorno = false;

            var HKLM = RegistryKey.OpenBaseKey(RegistryHive.LocalMachine, RegistryView.Registry64);

            registryKey = HKLM.OpenSubKey(@"SOFTWARE\Microsoft\Windows\CurrentVersion\Uninstall\NDDigital eForms Connector");

            if (registryKey == null)
            {
                var HKLMX86 = RegistryKey.OpenBaseKey(RegistryHive.LocalMachine, RegistryView.Registry32);
                registryKey = HKLMX86.OpenSubKey(@"SOFTWARE\Microsoft\Windows\CurrentVersion\Uninstall\NDDigital eForms Connector");
            }

            try
            {
                PathFolder = registryKey.GetValue("InstallLocation").ToString();

            }
            catch (Exception)
            {

            }
            finally { }

            if (PathFolder != null)
            {
                retorno = true;
            }

            return retorno;
        }

        //Banco já criado ou não
        public static bool SGBDCreated { get; set; }
        public static bool SGBDCreatedCold { get; set; }

        //banco selecionado para a insatalação
        public static bool SQL2005 = false;
        public static bool SQL2008 = false;
        public static bool SQL2012 = false;
        public static bool SQL2014 = false;
        public static bool Oracle = false;
        public static bool Informix = false;
    }
}
