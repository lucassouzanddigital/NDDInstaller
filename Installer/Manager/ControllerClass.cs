using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Installer.Manager
{
    public static class ControllerClass
    {
        public static int VersionControl = 4580;

        public static bool isUpdate { get; set; }

        public static string PathFolder = null;
        
        public static bool PathConnectorVerify()
        {            
            RegistryKey registryKey = null;
            bool returns = false;

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
                returns = true;
            }

            return returns;
           
        }
    }
}
