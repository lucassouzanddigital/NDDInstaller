using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Threading;
using System.Timers;
using System.Globalization;
using System.Diagnostics;
using System.IO.Compression;
using NDDigital.eForms.Installer.Connector.PresentationFolder;
using NDDigital.eForms.Installer.Connector.Controls.Manager;
using NDDigital.eForms.Installer.Connector.Instalation.Connector;
using NDDigital.eForms.Installer.Connector.Compression;
using NDDigital.eForms.Installer.Connector.Instalation;
using NDDigital.eForms.Installer.Connector.Service;
using System.IO;
using NDDigital.eForms.Installer.Connector.Components;
using Microsoft.Win32;
using NDDigital.eForms.Installer.Connector.Verification;
using IWshRuntimeLibrary;

namespace NDDigital.eForms.Installer.Connector.Controls
{
    public partial class Progress : UserControl
    {
        ExtractFileCompacted NSIS = new ExtractFileCompacted();
        RemoveFiles removeFiles = new RemoveFiles();
        CreateDataBase DBMGR;

        public Progress()
        {
            InitializeComponent();            
            Thread thread = new Thread(ProgressImportInstalation);
            thread.Start();
        }

        private void BtnNext_Click(object sender, EventArgs e)
        {
            UserControl _panControl;
            this.Controls.Clear();
            _panControl = new EndPresentation();
            this.Controls.Add(_panControl);
        }

        //Instalação do Import Service
        public void ProgressImportInstalation()
        {
            if (InvokeRequired)
            {
                this.Invoke(new MethodInvoker(ProgressImportInstalation));
                return;
            }

            //Se não for Update, cria o serviço
            if (!ControllerClass.isUpdate)
            {
                lblProConnector.Text = "Copiando Componentes...";
                lblProConnector.Refresh();

                //Copia DBMGR
                Components();

                //Copia o SQLCMD para a ferramenta DBMGR
                CopySQLCMD();

                lblProConnector.Text = "Criando chaves de registro...";
                lblProConnector.Refresh();

                //Move progress
                ProgressBarUpdate();

                //Cria Chaves de registro NDDigital
                eConnector.CreateNDDigitalRegKeys();

                lblProConnector.Text = "Criando Banco de Dados...";
                lblProConnector.Refresh();

                //Move progress
                ProgressBarUpdate();

                /*if (!ControllerClass.Oracle && !ControllerClass.Informix)
                {
                    DBMGR = new CreateDataBase();

                    if (!ControllerClass.SGBDCreated || !ControllerClass.SGBDCreatedCold)
                    {
                        if (!eConnector.VerifyDBMGRResult())
                        {
                            MessageBox.Show("Não foi possível acessar o banco de dados, verifique os eventos do Windows para maiores informações!", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            StartPage.ActiveForm.Close();
                        }
                    }
                }*/

                //Move progress
                ProgressBarUpdate();

                lblProConnector.Text = "Criando Pastas de destino...";
                lblProConnector.Refresh();

                //Cria as pastas de destino para as DLLS
                eConnector.CreateFolderConnector();

                //Move progress
                ProgressBarUpdate();

                lblProConnector.Text = "Criando Serviços...";
                lblProConnector.Refresh();

                //Move progress
                ProgressBarUpdate();

                //Cria serviço Connector Service                                                            
                Services.CreateService(ControllerClass.PathFolder + @"\Connector\Connector Service\NDDigital.eForms.ConnectorService.exe", "NDDigitaleFormsConnectorService",
                                                "Serviço responsável pela captura e processamento de documentos enviados à solução e-Forms.", "NDDigital e-Forms Connector Service");

                //Move progress
                ProgressBarUpdate();

                //Estraindo DLLs
                ExtractResources("Settings");
                ExtractResources("Service");
                ExtractResources("Services");
                ExtractResources("B2B");
                ExtractResources("DPEC");

                CalculateFileQuantity();

                //Movendo as DLLs para o caminho de destino
                MoveDLLs(@"C:\Inst\ConnectorSettings", "Connector Settings");
                Thread.Sleep(500);

                MoveDLLs(@"C:\Inst\ConnectorService", "Connector Service");
                Thread.Sleep(500);

                MoveDLLs(@"C:\Inst\ConnectorServices", "Connector Services");
                Thread.Sleep(500);

                MoveDLLs(@"C:\Inst\B2B", "B2B Service");
                Thread.Sleep(500);

                MoveDLLs(@"C:\Inst\DPEC", "DPEC Server");
                Thread.Sleep(500);

            }

            //Caso seja Update, para o serviço para atualizar as DLLs
            else
            {
                lblProConnector.Text = "Verificando update...";
                lblProConnector.Refresh();

                ControllerClass.VerifyRegKeysIFUpdate();

                //Move progress
                ProgressBarUpdate();

                lblProConnector.Text = "Verificando pastas existentes...";
                lblProConnector.Refresh();

                eConnector.CreateFolderConnector();

                //Move progress
                ProgressBarUpdate();


                lblProConnector.Text = "Parando os Serviços...";
                lblProConnector.Refresh();

                Services.ConnectorServiceStop();
                Thread.Sleep(3500);

                //Move progress
                ProgressBarUpdate();


                lblProConnector.Text = "Deletando arquivo antigos...";
                lblProConnector.Refresh();

                removeFiles.DeleteSchemasFrom(ControllerClass.PathFolder + @"\Connector\Connector Service\Schemas");
                removeFiles.DeleteFilesFrom(ControllerClass.PathFolder + @"\Connector\Connector Settings");        
                removeFiles.DeleteFilesFrom(ControllerClass.PathFolder + @"\Connector\Connector Service");
                removeFiles.DeleteFilesFrom(ControllerClass.PathFolder + @"\Connector\Connector Services");
                removeFiles.DeleteFilesFrom(ControllerClass.PathFolder + @"\Connector\B2B Service");
                removeFiles.DeleteFilesFrom(ControllerClass.PathFolder + @"\Connector\DPEC Server");
 
                //Move progress
                ProgressBarUpdate();
                
                //Estraindo DLLs
                ExtractResources("Settings");
                ExtractResources("Service");
                ExtractResources("Services");
                ExtractResources("B2B");
                ExtractResources("DPEC");

                //Move progress
                ProgressBarUpdate();

                //Calcula a quantidade de arquivos para definir o tamanho da barra de progresso
                CalculateFileQuantity();

                MoveDLLs(@"C:\Inst\ConnectorSettings", "Connector Settings");
                Thread.Sleep(500);

                MoveDLLs(@"C:\Inst\ConnectorService", "Connector Service");
                Thread.Sleep(500);

                MoveDLLs(@"C:\Inst\ConnectorServices", "Connector Services");
                Thread.Sleep(500);

                MoveDLLs(@"C:\Inst\B2B", "B2B Service");
                Thread.Sleep(500);

                MoveDLLs(@"C:\Inst\DPEC", "DPEC Server");
                Thread.Sleep(500);

                //Move progress
                ProgressBarUpdate();

                lblProConnector.Text = "Finalizando...";
                lblProConnector.Refresh();

            }


            lblProConnector.Text = "Atualizando atalhos...";
            lblProConnector.Refresh();

            ShortcutConnector(ControllerClass.PathFolder);
            //ShortcutMonitor(ControllerClass.RootFolder);

            lblProConnector.Text = "Iniciando os Serviços...";
            lblProConnector.Refresh();

            //Inicia Serviço
            Services.ConnectorServiceStart();

            //Move progress
            ProgressBarUpdate();

            lblProConnector.Font = new Font(lblProConnector.Font, FontStyle.Bold);
            lblProConnector.ForeColor = Color.Green;
            lblProConnector.Text = "Concluido";
            PctImport.Visible = true;
            BtnNext.Enabled = true;
            lblCopy.Text = "Todos os arquivos foram copiados";
            lblFile.Text = "";
            groupGeneral.Refresh();

        }

        private void ExtractResources(string module)
        {
            //Se o diretorio inst não existe apenas extrai o .exe
            if (!Directory.Exists(@"C:\Inst"))
            {
                lblProConnector.Text = "Extraindo DLLs, aguarde...";
                lblProConnector.Refresh();

                string pathConnector = @"";

                if (!Directory.Exists(@"C:\Inst"))
                {
                    Directory.CreateDirectory(@"C:\Inst");
                }

                if (module == "Settings")
                {
                    //Settings
                    byte[] bin = Properties.Resources.ConnectorSettings;
                    pathConnector = @"C:\Inst\ConnectorSettings.exe";
                    NSIS.ByteArrayToFile(pathConnector, bin);

                }
                else if (module == "Service")
                {
                    //Service
                    byte[] bin = Properties.Resources.ConnectorService;
                    pathConnector = @"C:\Inst\ConnectorService.exe";
                    NSIS.ByteArrayToFile(pathConnector, bin);
                }

                else if (module == "Services")
                {
                    //Service
                    byte[] bin = Properties.Resources.ConnectorServices;
                    pathConnector = @"C:\Inst\ConnectorServices.exe";
                    NSIS.ByteArrayToFile(pathConnector, bin);
                }

                else if (module == "B2B")
                {
                    //Service
                    byte[] bin = Properties.Resources.B2B;
                    pathConnector = @"C:\Inst\B2B.exe";
                    NSIS.ByteArrayToFile(pathConnector, bin);
                }

                else if (module == "DPEC")
                {
                    //Service
                    byte[] bin = Properties.Resources.DPEC;
                    pathConnector = @"C:\Inst\DPEC.exe";
                    NSIS.ByteArrayToFile(pathConnector, bin);
                }

                Process processo = new Process();
                processo.StartInfo.FileName = pathConnector;
                processo.StartInfo.WindowStyle = ProcessWindowStyle.Hidden;
                processo.Start();
                processo.WaitForExit();
                processo.Close();

                //Move progress
                ProgressBarUpdate();

            }

            //Caso ele exista, o mesmo é apagado e extraido novamente
            else if (Directory.Exists(@"C:\Inst"))
            {
                lblProConnector.Text = "Extraindo DLLs, aguarde...";
                lblProConnector.Refresh();

                string pathConnector = @"";

                if (!Directory.Exists(@"C:\Inst"))
                {
                    Directory.CreateDirectory(@"C:\Inst");
                }

                if (module == "Settings")
                {
                    //Settings
                    byte[] bin = Properties.Resources.ConnectorSettings;
                    pathConnector = @"C:\Inst\ConnectorSettings.exe";
                    NSIS.ByteArrayToFile(pathConnector, bin);

                }

                else if (module == "Service")
                {
                    //Service
                    byte[] bin = Properties.Resources.ConnectorService;
                    pathConnector = @"C:\Inst\ConnectorService.exe";
                    NSIS.ByteArrayToFile(pathConnector, bin);
                }

                else if (module == "Services")
                {
                    //Service
                    byte[] bin = Properties.Resources.ConnectorServices;
                    pathConnector = @"C:\Inst\ConnectorServices.exe";
                    NSIS.ByteArrayToFile(pathConnector, bin);
                }

                else if (module == "B2B")
                {
                    //Service
                    byte[] bin = Properties.Resources.B2B;
                    pathConnector = @"C:\Inst\B2B.exe";
                    NSIS.ByteArrayToFile(pathConnector, bin);
                }

                else if (module == "DPEC")
                {
                    //Service
                    byte[] bin = Properties.Resources.DPEC;
                    pathConnector = @"C:\Inst\DPEC.exe";
                    NSIS.ByteArrayToFile(pathConnector, bin);
                }

                Process processo = new Process();
                processo.StartInfo.FileName = pathConnector;
                processo.StartInfo.WindowStyle = ProcessWindowStyle.Hidden;
                processo.Start();
                processo.WaitForExit();
                processo.Close();

                //Move progress
                ProgressBarUpdate();

            }
        }

        //Atualiza a barra de progresso
        private void ProgressBarUpdate()
        {
            progressStatus.Value++;
            progressStatus.Refresh();
        }

        //Move as DLLs para a pasta de destino
        private void MoveDLLs(string path, string destiny)
        {
            lblCopy.Text = "Copiando:";
            lblCopy.Refresh();

            if (System.IO.Directory.Exists(path))
            {
                string[] files = System.IO.Directory.GetFiles(path);
                string[] paths = System.IO.Directory.GetDirectories(path);


                foreach (string f in files)
                {
                    string fileName = System.IO.Path.GetFileName(f);
                    System.IO.File.Move(path + @"\" + fileName, ControllerClass.PathFolder + @"\Connector\" + destiny + @"\" + fileName);

                    lblFile.Text = "";
                    lblFile.Refresh();
                    lblFile.Text = fileName;
                    lblFile.Refresh();

                    ProgressBarUpdate();
                }

                foreach (string p in paths)
                {
                    string directoryName = System.IO.Path.GetFileName(p);
                    Directory.Move(path + @"\" + directoryName, ControllerClass.PathFolder + @"\Connector\" + destiny + @"\" + directoryName);

                    lblFile.Text = "";
                    lblFile.Refresh();
                    lblFile.Text = directoryName;
                    lblFile.Refresh();

                    //ProgressBarUpdate();
                }

            }

            eConnector.VersionControlUpdate();
        }

        //Calcula a quantidade de arquivos na pastas para definir o tamanho da barra de progresso
        private void CalculateFileQuantity()
        {
            string[] filesService = System.IO.Directory.GetFiles(@"C:\Inst\ConnectorService\");
            string[] pathsService = System.IO.Directory.GetDirectories(@"C:\Inst\ConnectorService\");

            string[] filesSettings = System.IO.Directory.GetFiles(@"C:\Inst\ConnectorSettings\");
            string[] pathsSettings = System.IO.Directory.GetDirectories(@"C:\Inst\ConnectorSettings\");

            string[] filesServices = System.IO.Directory.GetFiles(@"C:\Inst\ConnectorServices\");
            string[] pathsServices = System.IO.Directory.GetDirectories(@"C:\Inst\ConnectorServices\");

            string[] filesB2B = System.IO.Directory.GetFiles(@"C:\Inst\B2B\");
            string[] pathsB2B = System.IO.Directory.GetDirectories(@"C:\Inst\B2B\");

            string[] filesDPEC = System.IO.Directory.GetFiles(@"C:\Inst\DPEC\");
            string[] pathsDPEC = System.IO.Directory.GetDirectories(@"C:\Inst\DPEC\");

            progressStatus.Maximum = filesService.Length + pathsService.Length + filesSettings.Length + pathsSettings.Length + filesServices.Length + pathsServices.Length +
                                                                                                                                    filesB2B.Length + pathsB2B.Length + filesDPEC.Length + pathsDPEC.Length + 10;
            progressStatus.Refresh();
        }

        //Somente instalação do zero -- Extrai os componentes para criação de banco
        public void Components()

        {
            if (!ControllerClass.isUpdate)
            {
                byte[] bin = Properties.Resources.DBMGR;
                Directory.CreateDirectory(@"c:\delete");
                string pathdbmgr = @"c:\delete\DBMGR.exe";
                NSIS.ByteArrayToFile(pathdbmgr, bin);

                Process process = Process.Start(@"c:\delete\DBMGR.exe");
                process.WaitForExit();
                process.Close();

            }

        }

        //Move os componentes após a utilização dos mesmos para a criação do banco
        public void MoveComponentes()
        {

            if (System.IO.Directory.Exists(@"c:\delete"))
            {
                string[] files = System.IO.Directory.GetFiles(@"c:\delete");
                string[] paths = System.IO.Directory.GetDirectories(@"c:\delete");


                foreach (string f in files)
                {
                    string fileName = System.IO.Path.GetFileName(f);
                    System.IO.File.Move(@"c:\delete" + @"\" + fileName, ControllerClass.PathFolder + @"\Componentes" + @"\" + fileName);

                }
            }

        }

        //verifica e busca de acordo com o windows o SQLCMD para execução do DBMGR
        public string GetSQLCMD(string windows)
        {

            string SQLCMD;
            RegistryKey registryKey = null;

            var HKLM = RegistryKey.OpenBaseKey(RegistryHive.LocalMachine, RegistryView.Registry64);

            if (windows.Contains("2012"))
            {
                if (windows.Contains("R2"))
                {
                    registryKey = HKLM.OpenSubKey(@"SOFTWARE\Microsoft\Microsoft SQL Server\120\Tools\ClientSetup");

                    if (registryKey == null)
                    {
                        var HKLMX86 = RegistryKey.OpenBaseKey(RegistryHive.LocalMachine, RegistryView.Registry64);
                        registryKey = HKLMX86.OpenSubKey(@"SOFTWARE\Microsoft\Microsoft SQL Server\120\Tools\ClientSetup");
                    }
                }
                else
                {
                    registryKey = HKLM.OpenSubKey(@"SOFTWARE\Microsoft\Microsoft SQL Server\110\Tools\ClientSetup");

                    if (registryKey == null)
                    {
                        var HKLMX86 = RegistryKey.OpenBaseKey(RegistryHive.LocalMachine, RegistryView.Registry64);
                        registryKey = HKLMX86.OpenSubKey(@"SOFTWARE\Microsoft\Microsoft SQL Server\110\Tools\ClientSetup");

                    }
                }

            }

            if (windows.Contains("2003"))
            {
                registryKey = HKLM.OpenSubKey(@"SOFTWARE\Microsoft\Microsoft SQL Server\90\Tools\ClientSetup");

                if (registryKey == null)
                {
                    var HKLMX86 = RegistryKey.OpenBaseKey(RegistryHive.LocalMachine, RegistryView.Registry32);
                    registryKey = HKLMX86.OpenSubKey(@"SOFTWARE\Microsoft\Microsoft SQL Server\90\Tools\ClientSetup");
                }

            }

            if (windows.Contains("2008"))
            {
                registryKey = HKLM.OpenSubKey(@"SOFTWARE\Microsoft\Microsoft SQL Server\100\Tools\ClientSetup");

                if (registryKey == null)
                {
                    var HKLMX86 = RegistryKey.OpenBaseKey(RegistryHive.LocalMachine, RegistryView.Registry32);
                    registryKey = HKLMX86.OpenSubKey(@"SOFTWARE\Microsoft\Microsoft SQL Server\100\Tools\ClientSetup");
                }

            }


            if (windows.Contains("7"))
            {
                registryKey = HKLM.OpenSubKey(@"SOFTWARE\Microsoft\Microsoft SQL Server\110\Tools\ClientSetup");

                if (registryKey == null)
                {
                    var HKLMX86 = RegistryKey.OpenBaseKey(RegistryHive.LocalMachine, RegistryView.Registry32);
                    registryKey = HKLMX86.OpenSubKey(@"SOFTWARE\Microsoft\Microsoft SQL Server\110\Tools\ClientSetup");
                }

            }

            SQLCMD = registryKey.GetValue("Path").ToString();

            //Exceção de caminho para 2012 R2
            if (windows.Contains("2012 R2"))
            {
                SQLCMD = registryKey.GetValue("ODBCToolsPath").ToString();
            }

            return SQLCMD;

        }

        //Cria os diretorios e move as DLLs dos COMPONENTES
        public void CopySQLCMD()
        {

            string cmdPath = GetSQLCMD(Verifications.ProductName);


            if (System.IO.Directory.Exists(cmdPath))
            {
                string[] files = System.IO.Directory.GetFiles(cmdPath);

                foreach (string s in files)
                {
                    string fileName = System.IO.Path.GetFileName(s);
                    string destFile = ControllerClass.PathFolder.Substring(0, 2) + @"\delete\" + fileName;
                    System.IO.File.Copy(s, destFile, true);
                }

            }

        }


        //Atalhos
        private void ShortcutConnector(string PathEXE)
        {
            var startupFolderPath = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
            var shell = new WshShell();
            var shortCutLinkFilePath = startupFolderPath + @"\e-Forms e-Connector Settings.lnk";
            var windowsApplicationShortcut = (IWshShortcut)shell.CreateShortcut(shortCutLinkFilePath);
            windowsApplicationShortcut.Description = "eConnector";
            windowsApplicationShortcut.TargetPath = PathEXE + @"\Connector\Connector Settings\NDDigital.eForms.Connector.Settings.exe";
            //windowsApplicationShortcut.IconLocation = @"C:\Users\filipe.santos\Pictures\ico\ndd.ico";            
            windowsApplicationShortcut.Save();
        }

        private void ShortcutMonitor(string PathEXE)
        {
            var startupFolderPath = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
            var shell = new WshShell();
            var shortCutLinkFilePath = startupFolderPath + @"\eMonitor.lnk";
            var windowsApplicationShortcut = (IWshShortcut)shell.CreateShortcut(shortCutLinkFilePath);
            windowsApplicationShortcut.Description = "Acompanhe o processamento dos documentos no e-Forms";
            windowsApplicationShortcut.TargetPath = PathEXE + @"\Webs\eMonitor\";
            //windowsApplicationShortcut.IconLocation = @"C:\Users\filipe.santos\Pictures\ico\ndd.ico";
            windowsApplicationShortcut.Save();
        }
    }
}

