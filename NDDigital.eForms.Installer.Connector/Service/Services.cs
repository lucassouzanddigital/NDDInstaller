using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Diagnostics;
using Microsoft.Win32;
using System.ServiceProcess;
using System.Configuration.Install;


namespace NDDigital.eForms.Installer.Connector.Service
{
    public class Services
    {
        //Parando todas as instancias
        public static void ConnectorServiceStop()
        {
            StopingConnectorService();

            StopingConnectorServices();

            StopingColdProcessor();

            StopingColdFileGenerator();

            ServiceController import = new ServiceController("NDDigitaleFormsImportService");
            ServiceController B2B = new ServiceController("NDDigitaleFormsB2BService");
            ServiceController coldRequest = new ServiceController("NDDigitaleFormsColdRequestDistributorService");
            ServiceController DPEC = new ServiceController("NDDigitaleFormsDPECService");
            ServiceController ERP = new ServiceController("NDDigitaleFormsERPPrintService");
            ServiceController license = new ServiceController("NDDigitalLicenseService");

            try
            {
                if ((import.Status.Equals(ServiceControllerStatus.Running)) ||
                    (import.Status.Equals(ServiceControllerStatus.StartPending)))
                {
                    import.Stop();
                }

                if ((B2B.Status.Equals(ServiceControllerStatus.Running)) ||
                    (B2B.Status.Equals(ServiceControllerStatus.StartPending)))
                {
                    B2B.Stop();
                }

                if ((coldRequest.Status.Equals(ServiceControllerStatus.Running)) ||
                    (coldRequest.Status.Equals(ServiceControllerStatus.StartPending)))
                {
                    coldRequest.Stop();
                }

                if ((DPEC.Status.Equals(ServiceControllerStatus.Running)) ||
                    (DPEC.Status.Equals(ServiceControllerStatus.StartPending)))
                {
                    DPEC.Stop();
                }

                if ((ERP.Status.Equals(ServiceControllerStatus.Running)) ||
                    (ERP.Status.Equals(ServiceControllerStatus.StartPending)))
                {
                    ERP.Stop();
                }

                if ((license.Status.Equals(ServiceControllerStatus.Running)) ||
                    (license.Status.Equals(ServiceControllerStatus.StartPending)))
                {
                    license.Stop();
                }

            }

            catch (Exception ex)
            {
                MessageBox.Show("Erro ao parar o serviço \n" + ex.Message);
            }

        }

        //Inicia todos as instancias
        public static void ConnectorServiceStart()
        {

            StartConnectorService();

            StartConnectorServices();

            StartColdProcessor();

            StartColdFileGenerator();

            ServiceController import = new ServiceController("NDDigitaleFormsImportService");
            ServiceController B2B = new ServiceController("NDDigitaleFormsB2BService");
            ServiceController coldRequest = new ServiceController("NDDigitaleFormsColdRequestDistributorService");
            ServiceController DPEC = new ServiceController("NDDigitaleFormsDPECService");
            ServiceController ERP = new ServiceController("NDDigitaleFormsERPPrintService");
            ServiceController license = new ServiceController("NDDigitalLicenseService");

            try
            {
                if ((import.Status.Equals(ServiceControllerStatus.Stopped)) ||
                    (import.Status.Equals(ServiceControllerStatus.StopPending)))
                {
                    import.Start();
                }

                if ((B2B.Status.Equals(ServiceControllerStatus.Stopped)) ||
                    (B2B.Status.Equals(ServiceControllerStatus.StopPending)))
                {
                    B2B.Start();
                }

                if ((coldRequest.Status.Equals(ServiceControllerStatus.Stopped)) ||
                    (coldRequest.Status.Equals(ServiceControllerStatus.StopPending)))
                {
                    coldRequest.Start();
                }
                if ((DPEC.Status.Equals(ServiceControllerStatus.Stopped)) ||
                    (DPEC.Status.Equals(ServiceControllerStatus.StopPending)))
                {
                    DPEC.Start();
                }
                if ((ERP.Status.Equals(ServiceControllerStatus.Stopped)) ||
                    (ERP.Status.Equals(ServiceControllerStatus.StopPending)))
                {
                    ERP.Start();
                }
                if ((license.Status.Equals(ServiceControllerStatus.Stopped)) ||
                    (license.Status.Equals(ServiceControllerStatus.StopPending)))
                {
                    license.Start();
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro ao iniciar o serviço \n" + ex.Message);
            }

        }


        //Parando todas as instancias do Cold File Generator services
        private static void StopingColdFileGenerator()
        {
            int numeroControleServico = 1;
            ServiceController coldFileGenerator;
            int numeroInstanciasParadas = 0;
            int numeroInstanciasExistentes = Convert.ToInt32(VerifyInstanceTotal(@"SOFTWARE\NDDigital\eForms\Connector", "ColdFileGeneratorInstanceTotal"));
            string regValue = null;

            while (numeroInstanciasParadas != numeroInstanciasExistentes)
            {
                if (numeroControleServico == 0)
                {
                    coldFileGenerator = new ServiceController("NDDigitaleFormsColdFileGeneratorService" + numeroControleServico);

                    if ((coldFileGenerator.Status.Equals(ServiceControllerStatus.Running)) ||
                                                   (coldFileGenerator.Status.Equals(ServiceControllerStatus.StartPending)))
                    {
                        coldFileGenerator.Stop();
                    }

                    numeroInstanciasParadas += 1;
                    numeroControleServico += 1;
                }
                else
                {
                    regValue = VerifyInstanceTotal(@"SYSTEM\CurrentControlSet\Services\NDDigitaleFormsColdFileGeneratorService" + numeroControleServico, "DisplayName");

                    if (regValue != null)
                    {
                        coldFileGenerator = new ServiceController();
                        coldFileGenerator.ServiceName = "NDDigitaleFormsColdFileGeneratorService" + numeroControleServico;

                        if ((coldFileGenerator.Status.Equals(ServiceControllerStatus.Running)) ||
                                                  (coldFileGenerator.Status.Equals(ServiceControllerStatus.StartPending)))
                        {
                            coldFileGenerator.Stop();
                        }

                        numeroControleServico += 1;
                        numeroInstanciasParadas += 1;
                    }
                    else
                    {
                        numeroControleServico += 1;
                    }
                }

            }
        }

        //Parando todas as instancias do Cold Processor
        private static void StopingColdProcessor()
        {
            int controlNumberService = 0;
            ServiceController coldProcessor;
            int numberStopedInstances = 0;
            int numberExistenInstance = Convert.ToInt32(VerifyInstanceTotal(@"SOFTWARE\NDDigital\eForms\Connector", "ColdInstanceTotal"));
            string regValue = null;

            while (numberStopedInstances != numberExistenInstance)
            {
                if (controlNumberService == 0)
                {
                    coldProcessor = new ServiceController("NDDigitaleFormsColdProcessorService");

                    if ((coldProcessor.Status.Equals(ServiceControllerStatus.Running)) ||
                                                   (coldProcessor.Status.Equals(ServiceControllerStatus.StartPending)))
                    {
                        coldProcessor.Stop();

                    } numberStopedInstances += 1;
                    controlNumberService += 1;
                }
                else
                {
                    regValue = VerifyInstanceTotal(@"SYSTEM\CurrentControlSet\Services\NDDigitaleFormsColdProcessorService" + controlNumberService, "DisplayName");

                    if (regValue != null)
                    {
                        coldProcessor = new ServiceController();
                        coldProcessor.ServiceName = "NDDigitaleFormsColdProcessorService" + controlNumberService;

                        if ((coldProcessor.Status.Equals(ServiceControllerStatus.Running)) ||
                                                   (coldProcessor.Status.Equals(ServiceControllerStatus.StartPending)))
                        {
                            coldProcessor.Stop();
                        }

                        controlNumberService += 1;
                        numberStopedInstances += 1;
                    }
                    else
                    {
                        controlNumberService += 1;
                    }
                }

            }
        }

        //Parando todas as instancias do Connector Services
        private static void StopingConnectorServices()
        {
            int controlNumberService = 0;
            ServiceController service;
            int numberStopedInstances = 0;
            int numberExistenInstance = Convert.ToInt32(VerifyInstanceTotal(@"SOFTWARE\NDDigital\eForms\Connector", "InstanceTotal1"));
            string regValue = null;

            while (numberStopedInstances != numberExistenInstance)
            {
                if (controlNumberService == 0)
                {
                    service = new ServiceController("NDDigitaleFormsConnectorServices");

                    if ((service.Status.Equals(ServiceControllerStatus.Running)) ||
                                                   (service.Status.Equals(ServiceControllerStatus.StartPending)))
                    {
                        service.Stop();
                    }
                    numberStopedInstances += 1;
                    controlNumberService += 1;
                }
                else
                {
                    regValue = VerifyInstanceTotal(@"SYSTEM\CurrentControlSet\Services\NDDigitaleFormsConnectorServices" + controlNumberService, "DisplayName");

                    if (regValue != null)
                    {
                        service = new ServiceController();
                        service.ServiceName = "NDDigitaleFormsConnectorServices" + controlNumberService;

                        if ((service.Status.Equals(ServiceControllerStatus.Running)) ||
                                                   (service.Status.Equals(ServiceControllerStatus.StartPending)))
                        {
                            service.Stop();
                        }

                        controlNumberService += 1;
                        numberStopedInstances += 1;
                    }
                    else
                    {
                        controlNumberService += 1;
                    }
                }

            }
        }

        //Parando todas as instancias do Connector Service
        private static void StopingConnectorService()
        {
            int controlNumberService = 0;
            ServiceController service;
            int numberStopedInstances = 0;
            int numberExistenInstance = Convert.ToInt32(VerifyInstanceTotal(@"SOFTWARE\NDDigital\eForms\Connector", "InstanceTotal"));
            string regValue = null;

            while (numberStopedInstances != numberExistenInstance)
            {
                if (controlNumberService == 0)
                {
                    service = new ServiceController("NDDigitaleFormsConnectorService");

                    if ((service.Status.Equals(ServiceControllerStatus.Running)) ||
                                                    (service.Status.Equals(ServiceControllerStatus.StartPending)))
                    {
                        service.Stop();
                    }

                    numberStopedInstances += 1;
                    controlNumberService += 1;
                }
                else
                {
                    regValue = VerifyInstanceTotal(@"SYSTEM\CurrentControlSet\Services\NDDigitaleFormsConnectorService" + controlNumberService, "DisplayName");

                    if (regValue != null)
                    {
                        service = new ServiceController();
                        service.ServiceName = "NDDigitaleFormsConnectorService" + controlNumberService;
                        if ((service.Status.Equals(ServiceControllerStatus.Running)) ||
                                                        (service.Status.Equals(ServiceControllerStatus.StartPending)))
                        {
                            service.Stop();
                        }

                        numberStopedInstances += 1;
                        controlNumberService += 1;
                    }
                    else
                    {
                        controlNumberService += 1;
                    }
                }

            }
        }



        //Mata processo do Settings (o mesmo não possui serviço, apenas uma tarefa)
        private static void KillTaskSettings()
        {

            try
            {
                Process[] processosIE = Process.GetProcessesByName("NDDigital.eForms.Connector.Settings");
                if (processosIE.Length > 0)
                {
                    Process processo = processosIE[0];
                    processo.Kill();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro ao iniciar o \n" + ex.Message);
            }

        }


        //Verifica na chave de registro o numero de instancia do solicitado ao metodo
        private static string VerifyInstanceTotal(string RegString, string Key)
        {
            string valueKey = null;

            var HKLM = RegistryKey.OpenBaseKey(RegistryHive.LocalMachine, RegistryView.Registry64);

            RegistryKey registryKey = HKLM.OpenSubKey(RegString);

            if (registryKey == null)
            {
                var HKLMX86 = RegistryKey.OpenBaseKey(RegistryHive.LocalMachine, RegistryView.Registry32);
                registryKey = HKLMX86.OpenSubKey(RegString);
            }

            try
            {
                valueKey = registryKey.GetValue(Key).ToString();
            }
            catch (Exception)
            {

            }

            finally
            {

            }

            return valueKey;
        }



        //Iniciando todas as instancias do Connector Services
        private static void StartConnectorServices()
        {
            int controlNumberService = 0;
            ServiceController service;
            int numberStopedInstances = 0;
            int numberExistenInstance = Convert.ToInt32(VerifyInstanceTotal(@"SOFTWARE\NDDigital\eForms\Connector", "InstanceTotal1"));
            string regValue = null;

            while (numberStopedInstances != numberExistenInstance)
            {
                if (controlNumberService == 0)
                {
                    service = new ServiceController("NDDigitaleFormsConnectorServices");
                    service.Start();
                    numberStopedInstances += 1;
                    controlNumberService += 1;
                }
                else
                {
                    regValue = VerifyInstanceTotal(@"SYSTEM\CurrentControlSet\Services\NDDigitaleFormsConnectorServices" + controlNumberService, "DisplayName");

                    if (regValue != null)
                    {
                        service = new ServiceController();
                        service.ServiceName = "NDDigitaleFormsConnectorServices" + controlNumberService;
                        service.Start();
                        controlNumberService += 1;
                        numberStopedInstances += 1;
                    }
                    else
                    {
                        controlNumberService += 1;
                    }
                }

            }
        }

        //Iniciando todas as instancias do Connector Service
        private static void StartConnectorService()
        {
            int controlNumberService = 0;
            ServiceController service;
            int numberStopedInstances = 0;
            int numberExistenInstance = Convert.ToInt32(VerifyInstanceTotal(@"SOFTWARE\NDDigital\eForms\Connector", "InstanceTotal"));
            string regValue = null;

            while (numberStopedInstances != numberExistenInstance)
            {
                if (controlNumberService == 0)
                {
                    service = new ServiceController("NDDigitaleFormsConnectorService");

                    if ((service.Status.Equals(ServiceControllerStatus.Stopped)) ||
                                                    (service.Status.Equals(ServiceControllerStatus.StopPending)))
                    {
                        service.Start();
                    }

                    numberStopedInstances += 1;
                    controlNumberService += 1;
                }
                else
                {
                    regValue = VerifyInstanceTotal(@"SYSTEM\CurrentControlSet\Services\NDDigitaleFormsConnectorService" + controlNumberService, "DisplayName");

                    if (regValue != null)
                    {
                        service = new ServiceController();
                        service.ServiceName = "NDDigitaleFormsConnectorService" + controlNumberService;

                        if ((service.Status.Equals(ServiceControllerStatus.Stopped)) ||
                                                        (service.Status.Equals(ServiceControllerStatus.StopPending)))
                        {
                            service.Start();
                        }

                        numberStopedInstances += 1;
                        controlNumberService += 1;
                    }
                    else
                    {
                        controlNumberService += 1;
                    }
                }

            }
        }

        //Iniciando todas as instancias do Cold File Generator services
        private static void StartColdFileGenerator()
        {
            int controlNumberService = 1;
            ServiceController coldFileGenerator;
            int numberStopedInstances = 0;
            int numberExistenInstance = Convert.ToInt32(VerifyInstanceTotal(@"SOFTWARE\NDDigital\eForms\Connector", "ColdFileGeneratorInstanceTotal"));
            string regValue = null;

            while (numberStopedInstances != numberExistenInstance)
            {
                if (controlNumberService == 0)
                {
                    coldFileGenerator = new ServiceController("NDDigitaleFormsColdFileGeneratorService" + controlNumberService);
                    coldFileGenerator.Start();
                    numberStopedInstances += 1;
                    controlNumberService += 1;
                }
                else
                {
                    regValue = VerifyInstanceTotal(@"SYSTEM\CurrentControlSet\Services\NDDigitaleFormsColdFileGeneratorService" + controlNumberService, "DisplayName");

                    if (regValue != null)
                    {
                        coldFileGenerator = new ServiceController();
                        coldFileGenerator.ServiceName = "NDDigitaleFormsColdFileGeneratorService" + controlNumberService;
                        coldFileGenerator.Start();
                        controlNumberService += 1;
                        numberStopedInstances += 1;
                    }
                    else
                    {
                        controlNumberService += 1;
                    }
                }

            }
        }

        //Iniciando todas as instancias do Cold Processor
        private static void StartColdProcessor()
        {
            int controlNumberService = 0;
            ServiceController coldProcessor;
            int numberStopedInstances = 0;
            int numberExistenInstance = Convert.ToInt32(VerifyInstanceTotal(@"SOFTWARE\NDDigital\eForms\Connector", "ColdInstanceTotal"));
            string regValue = null;

            while (numberStopedInstances != numberExistenInstance)
            {
                if (controlNumberService == 0)
                {
                    coldProcessor = new ServiceController("NDDigitaleFormsColdProcessorService");
                    coldProcessor.Start();
                    numberStopedInstances += 1;
                    controlNumberService += 1;
                }
                else
                {
                    regValue = VerifyInstanceTotal(@"SYSTEM\CurrentControlSet\Services\NDDigitaleFormsColdProcessorService" + controlNumberService, "DisplayName");

                    if (regValue != null)
                    {
                        coldProcessor = new ServiceController();
                        coldProcessor.ServiceName = "NDDigitaleFormsColdProcessorService" + controlNumberService;
                        coldProcessor.Start();
                        controlNumberService += 1;
                        numberStopedInstances += 1;
                    }
                    else
                    {
                        controlNumberService += 1;
                    }
                }

            }
        }

        //Cria um serviço novo e registra o mesmo no caminho System\Current\Services
        public static void CreateService(string executablePath, string serviceName, string serviceDescription, string DisplayServiceName)
        {
            string retorno = VerifyInstanceTotal(@"SYSTEM\CurrentControlSet\services\" + serviceName, "DisplayName");

            if (retorno == "")
            {
                ServiceProcessInstaller ProcesServiceInstaller = new ServiceProcessInstaller();
                ProcesServiceInstaller.Account = ServiceAccount.User;

                ServiceInstaller servico = new ServiceInstaller();
                InstallContext Context = new System.Configuration.Install.InstallContext();
                String path = String.Format("/assemblypath={0}", executablePath);
                String[] cmdline = { path };

                Context = new System.Configuration.Install.InstallContext("", cmdline);
                servico.Context = Context;
                servico.DisplayName = DisplayServiceName;
                servico.Description = serviceDescription;
                servico.ServiceName = serviceName;
                servico.StartType = ServiceStartMode.Automatic;
                servico.Parent = ProcesServiceInstaller;

                System.Collections.Specialized.ListDictionary state = new System.Collections.Specialized.ListDictionary();

                ServiceController serviceExists = new ServiceController(serviceName);

                servico.Install(state);

            }

        }

    }
}
