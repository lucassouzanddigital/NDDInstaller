using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ServiceProcess;
using System.Windows.Forms;
using System.Diagnostics;
using Microsoft.Win32;
using System.Configuration.Install;
using Installer.Manager;

namespace Installer.Service
{
    public class Services
    {

        //Parando todas as instancias
        public static void ServiceStop()
        {
            ServiceController import = new ServiceController("NDDigitaleFormsImportService");

            try
            {
                if ((import.Status.Equals(ServiceControllerStatus.Running)) ||
                    (import.Status.Equals(ServiceControllerStatus.StartPending)))
                {
                    import.Stop();
                }
                
            }

            catch (Exception ex)
            {
                MessageBox.Show("Erro ao parar o serviço \n" + ex.Message);
            }

        }

        //Inicia todos as instancias
        public static void ServiceStart()
        {
            ServiceController import = new ServiceController("NDDigitaleFormsImportService");
            
            try
            {
                if ((import.Status.Equals(ServiceControllerStatus.Stopped)) ||
                    (import.Status.Equals(ServiceControllerStatus.StopPending)))
                {
                    import.Start();                   
                }
               
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro ao iniciar o serviço \n" + ex.Message);
            }
            
        }              

        //Cria um serviço novo e registra o mesmo no caminho System\Current\Services
        public static void CreateService(string executablePath, string serviceName, string serviceDescription, string displayServiceName)
        {
            ServiceProcessInstaller ProcesServiceInstaller = new ServiceProcessInstaller();
            ProcesServiceInstaller.Account = ServiceAccount.User;

            ServiceInstaller service = new ServiceInstaller();
            InstallContext Context = new System.Configuration.Install.InstallContext();
            String path = String.Format("/assemblypath={0}", executablePath);
            String[] cmdline = { path };

            Context = new System.Configuration.Install.InstallContext("", cmdline);
            service.Context = Context;
            service.DisplayName = displayServiceName;
            service.Description = serviceDescription;
            service.ServiceName = serviceName;
            service.StartType = ServiceStartMode.Automatic;
            service.Parent = ProcesServiceInstaller;

            System.Collections.Specialized.ListDictionary state = new System.Collections.Specialized.ListDictionary();

            ServiceController serviceExists = new ServiceController(serviceName);

            service.Install(state);

        }

    }
}
