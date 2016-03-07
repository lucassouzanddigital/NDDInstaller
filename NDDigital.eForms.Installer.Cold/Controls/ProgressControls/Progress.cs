using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Threading;
using NDDigital.eForms.Installer.Cold.Manager;
using NDDigital.eForms.Installer.Cold.PresentationFolder;
using System.Timers;
using System.Globalization;
using System.Diagnostics;
using NDDigital.eForms.Installer.Cold.Compression;
using NDDigital.eForms.Installer.Cold.Instalation.Entry;
using System.IO;
using NDDigital.eForms.Installer.Cold.Service;
using NDDigital.eForms.Installer.Cold.Instalation;

namespace NDDigital.eForms.Installer.Cold.Controls.ProgressControls
{
    public partial class Progress : UserControl
    {
        ExtractFileCompacted NSIS = new ExtractFileCompacted();
        ColdProcessor entry = new ColdProcessor();
        RemoveFiles removeFiles = new RemoveFiles();

        public Progress()
        {
            InitializeComponent();
            Thread thread = new Thread(ProgressEntryInstalation);
            thread.Start();
        }

        private void BtnNext_Click(object sender, EventArgs e)
        {
            UserControl _panControl;
            this.Controls.Clear();
            _panControl = new EndPresentation();
            this.Controls.Add(_panControl);
        }

        //Instalação do Entry Service
        public void ProgressEntryInstalation()
        {

            if (InvokeRequired)
            {
                this.Invoke(new MethodInvoker(ProgressEntryInstalation));
                return;
            }

            entry.CreateFolderEntry();

            //Move progress
            ProgressBarUpdate();

            //Se não for Update, cria o serviço
            if (!ControllerClass.isUpdate)
            {
                lblProEntry.Text = "Criando chaves de registro...";
                lblProEntry.Refresh();

                entry.CreateNDDigitalRegKeys();

                lblProEntry.Text = "Criando Serviço do Cold Processor...";
                lblProEntry.Refresh();

                //Move progress
                ProgressBarUpdate();

                Services.CreateService(ControllerClass.PathFolder + @"\Cold\Cold Processor Service\NDDigital.eForms$TYPE.ColdService.exe", "NDDigitaleFormsColdProcessorService",
                                                                                            "Serviço responsável por inserir em uma base de dados (guarda eletrônica), os documentos processados pela solução e-Forms.", "NDDigital e-Forms Cold Processor Service");

                //Move progress
                ProgressBarUpdate();

                ExtractResources("ColdProcessor");
                ExtractResources("ColdService");
                ExtractResources("ColdWeb");

                //Move progress
                ProgressBarUpdate();

                //Move DLLs para o caminho de destino
                MoveDLLs(@"C:\Inst\ColdProcessor", ControllerClass.PathFolder + @"\Cold\ColdProcessor");
                MoveDLLs(@"C:\Inst\ColdService", ControllerClass.RootFolder + @"\Webs\ColdService");
                MoveDLLs(@"C:\Inst\ColdWeb", ControllerClass.RootFolder + @"\Webs\ColdWeb");

            }

            //Caso seja Update, para o serviço para atualizar as DLLs
            else
            {
                lblProEntry.Text = "Parando Serviço do Cold Processor...";
                lblProEntry.Refresh();

                //Move progress
                ProgressBarUpdate();

                //Parando os Serviços
                Services.ServiceStop();

                Thread.Sleep(2000);

                lblProEntry.Text = "Deletando arquivos antigos...";
                lblProEntry.Refresh();
                                
                removeFiles.DeleteFilesFrom(ControllerClass.PathFolder + @"\Cold\Cold Processor Service");
                removeFiles.DeleteFilesFrom(ControllerClass.RootFolder + @"\Webs\ColdService");
                removeFiles.DeleteFilesFrom(ControllerClass.RootFolder + @"\Webs\ColdWeb");

                //Move progress
                ProgressBarUpdate();

                //Extrai DLLs
                ExtractResources("ColdProcessor");
                ExtractResources("ColdService");
                ExtractResources("ColdWeb");

                //Move progress
                ProgressBarUpdate();

                lblProEntry.Text = "Movendo DLLS para a pasta de destino...";
                lblProEntry.Refresh();

                //Move DLLs para o caminho de destino
                MoveDLLs(@"C:\Inst\ColdProcessor", ControllerClass.PathFolder + @"\Cold\ColdProcessor");
                MoveDLLs(@"C:\Inst\ColdService", ControllerClass.PathFolder + @"\Cold\ColdService");
                MoveDLLs(@"C:\Inst\ColdWeb", ControllerClass.RootFolder + @"\Webs\ColdWeb");

                lblProEntry.Text = "Finalizando...";
                lblProEntry.Refresh();

            }

            lblProEntry.Text = "Iniciando o Serviço do Cold Processor...";
            lblProEntry.Refresh();

            //Inicia Serviço
            Services.ServiceStart();

            //Move progress
            ProgressBarUpdate();

            lblProEntry.Font = new Font(lblProEntry.Font, FontStyle.Bold);
            lblProEntry.ForeColor = Color.Green;
            lblProEntry.Text = "Concluido";
            PctEntry.Visible = true;
            BtnNext.Enabled = true;
            lblCopy.Text = "Todos os arquivos foram copiados";
            lblFile.Text = "";

        }

        //Extrai os arquivos com as DLLs
        private void ExtractResources(string module)
        {
                        //Se o diretorio inst não existe apenas extrai o .exe
            if (!Directory.Exists(@"C:\Inst"))
            {
                lblProEntry.Text = "Extraindo DLLs, aguarde...";
                lblProEntry.Refresh();

                string pathConnector = @"";

                if (!Directory.Exists(@"C:\Inst"))
                {
                    Directory.CreateDirectory(@"C:\Inst");
                }

                if (module == "ColdProcessor")
                {
                    byte[] bin = Cold.Properties.Resources.ColdProcessor;
                    pathConnector = @"C:\Inst\ColdProcessor.exe";
                    NSIS.ByteArrayToFile(pathConnector, bin);
                }

                else if (module == "ColdService")
                {
                    byte[] bin = Cold.Properties.Resources.ColdService;
                    pathConnector = @"C:\Inst\ColdService.exe";
                    NSIS.ByteArrayToFile(pathConnector, bin);
                }

                else if (module == "ColdWeb")
                {
                    byte[] bin = Cold.Properties.Resources.ColdWeb;
                    pathConnector = @"C:\Inst\ColdWeb.exe";
                    NSIS.ByteArrayToFile(pathConnector, bin);
                }

                Process processo = new Process();
                processo.StartInfo.FileName = pathConnector;
                processo.StartInfo.WindowStyle = ProcessWindowStyle.Hidden;
                processo.Start();

                processo.WaitForExit();
                processo.Close();
            }
                        
            //Caso ele exista, o mesmo é apagado e extraido novamente
            else if (Directory.Exists(@"C:\Inst"))
            {

                lblProEntry.Text = "Extraindo DLLs, aguarde...";
                lblProEntry.Refresh();

                string pathConnector = @"";

                if (!Directory.Exists(@"C:\Inst"))
                {
                    Directory.CreateDirectory(@"C:\Inst");
                }

                if (module == "ColdProcessor")
                {
                    byte[] bin = Cold.Properties.Resources.ColdProcessor;
                    pathConnector = @"C:\Inst\ColdProcessor.exe";
                    NSIS.ByteArrayToFile(pathConnector, bin);
                }

                else if (module == "ColdService")
                {
                    byte[] bin = Cold.Properties.Resources.ColdService;
                    pathConnector = @"C:\Inst\ColdService.exe";
                    NSIS.ByteArrayToFile(pathConnector, bin);
                }

                else if (module == "ColdWeb")
                {
                    byte[] bin = Cold.Properties.Resources.ColdWeb;
                    pathConnector = @"C:\Inst\ColdWeb.exe";
                    NSIS.ByteArrayToFile(pathConnector, bin);
                }

                Process processo = new Process();
                processo.StartInfo.FileName = pathConnector;
                processo.StartInfo.WindowStyle = ProcessWindowStyle.Hidden;
                processo.Start();

                processo.WaitForExit();
                processo.Close();
            
            }

        }

        //Calcula a quantidade de arquivos na pastas para definir o tamanho da barra de progresso
        private void CalculateFileQuantity()
        {
            string[] filesProcessor = System.IO.Directory.GetFiles(@"C:\Inst\ColdProcessor\");
            string[] pathsProcessor = System.IO.Directory.GetDirectories(@"C:\Inst\ColdProcessor\");

            string[] filesService = System.IO.Directory.GetFiles(@"C:\Inst\ColdService\");
            string[] pathsService = System.IO.Directory.GetDirectories(@"C:\Inst\ColdService\");

            string[] filesWeb = System.IO.Directory.GetFiles(@"C:\Inst\ColdWeb\");
            string[] pathsWeb = System.IO.Directory.GetDirectories(@"C:\Inst\Web\");

            progressStatus.Maximum = filesProcessor.Length + pathsProcessor.Length + filesService.Length + pathsService.Length + filesWeb.Length + pathsWeb.Length + 5;
            progressStatus.Refresh();
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

                progressStatus.Maximum = files.Length + paths.Length + 5;

                foreach (string f in files)
                {
                    string fileName = System.IO.Path.GetFileName(f);
                    File.Move(path + @"\" + fileName, destiny + @"\" + fileName);

                    lblFile.Text = "";
                    lblFile.Refresh();
                    lblFile.Text = fileName;
                    lblFile.Refresh();

                    ProgressBarUpdate();
                }

                foreach (string p in paths)
                {
                    string directoryName = System.IO.Path.GetFileName(p);
                    Directory.Move(path + @"\" + directoryName, destiny + @"\" + directoryName);

                    lblFile.Text = "";
                    lblFile.Refresh();
                    lblFile.Text = directoryName;
                    lblFile.Refresh();

                    ProgressBarUpdate();
                }
            }

            ColdProcessor.VersionControlUpdate();
        }

    }

}

