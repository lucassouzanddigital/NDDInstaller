using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NDDigital.eForms.Installer.Connector.Verification
{
    public class Verifications
    {
        public static string ProductName = HKLM_GetString(@"SOFTWARE\Microsoft\Windows NT\CurrentVersion", "ProductName");
        public static Version winVersion = Environment.OSVersion.Version;
        public static string winVersion2 = Environment.UserName;
        public static string CurrentWindowsName = "";

        //Valida o SO para permitir ou não a instalação do eForms
        public static bool ValidaWindows()
        {

            bool windows = false;

            if (winVersion.Major + "." + winVersion.MajorRevision == "5.0")
            {
                CurrentWindowsName = "Windows 2000";
                windows = false;
            }
            if (winVersion.Major + "." + winVersion.MajorRevision == "5.1")
            {
                CurrentWindowsName = "Windows XP";
                windows = false;
            }
            if (winVersion.Major + "." + winVersion.MajorRevision == "5.2" && !ProductName.Contains("Home"))
            {
                CurrentWindowsName = "Windows Server 2003";
                windows = true;
            }
            if (winVersion.Major + "." + winVersion.MajorRevision == "6.0" && !ProductName.Contains("Vista"))
            {
                CurrentWindowsName = "Windows Server 2008 x86";
                windows = true;
            }
            if (winVersion.Major + "." + winVersion.MajorRevision == "6.1" && ProductName.Contains('7'))
            {
                CurrentWindowsName = "Windows Server 2008 x64";
                windows = true;
            }

            if (winVersion.Major + "." + winVersion.MajorRevision == "6.2")
            {
                CurrentWindowsName = "Windows Server 2012";
                windows = true;
            }
            if (winVersion.Major + "." + winVersion.MajorRevision == "6.3")
            {
                CurrentWindowsName = "Windows Server 2012 R2";
                windows = true;
            }

            return windows;
        }

        public static bool VerificaIIS() 
        {
            bool Exists;

            string RetornoVerificacao = HKLM_GetString(@"SYSTEM\CurrentControlSet\Services\W3SVC", "ImagePath");

            if(RetornoVerificacao == "" || RetornoVerificacao == null)
            {
                Exists = false;
            }
            else
            {
                Exists = true;
            }

            return Exists;
        }

        //Pega nome do Windows em execução
        public static string HKLM_GetString(string path, string key)
        {
            try
            {
                RegistryKey rk = Registry.LocalMachine.OpenSubKey(path);
                if (rk == null) return "";
                return (string)rk.GetValue(key);
            }
            catch { return ""; }
        }
    }
}
