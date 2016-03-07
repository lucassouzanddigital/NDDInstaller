using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Threading;
using Installer.Manager;
using Installer.PresentationFolder;
using System.Timers;
using System.Globalization;
using System.Diagnostics;
using Installer.Compression;
using Installer.Instalation.Import;
using Installer.Instalation;
using System.IO;
using Installer.Service;

namespace Installer.Controls.ProgressControls
{
    public partial class Progress : UserControl
    {
        ExtractFileCompacted NSIS = new ExtractFileCompacted();
        ImportService import = new ImportService();
        RemoveFiles removeFiles = new RemoveFiles();

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

            import.CreateFolderImport();

            //Move progress
            ProgressBarUpdate();

            //Se não for Update, cria o serviço
            if (!ControllerClass.isUpdate)
            {
                lblProImport.Text = "Criando chaves de registro...";
                lblProImport.Refresh();

                import.CreateConferencingRegKeys();
                import.CreateNDDigitalRegKeys();

                lblProImport.Text = "Criando Serviço do Cold Import...";
                lblProImport.Refresh();

                //Move progress
                ProgressBarUpdate();

                Services.CreateService(ControllerClass.PathFolder + @"\Connector\Import Service\NDDigital.eForms.ColdImport.Service.exe", "NDDigitaleFormsImportService",
                                                                                            "Serviço responsável pela importação de documentos NF-e e CT-e para armazenamento em Cold.", "NDDigital e-Forms Cold Import Service");

                //Move progress
                ProgressBarUpdate();

                ExtractResources();

                //Move progress
                ProgressBarUpdate();

                MoveDLLs(@"C:\Inst\ImportService");

            }

            //Caso seja Update, para o serviço para atualizar as DLLs
            else
            {
                lblProImport.Text = "Parando Serviço do Cold Import...";
                lblProImport.Refresh();

                //Move progress
                ProgressBarUpdate();

                //Parando os Serviços
                Services.ServiceStop();
                                
                Thread.Sleep(2000);

                lblProImport.Text = "Deletando arquivos antigos...";
                lblProImport.Refresh();

                removeFiles.DeleteFilesFrom(ControllerClass.PathFolder + @"\Connector\Import Service");
               
                //Move progress
                ProgressBarUpdate();

                //Extrai DLLs
                ExtractResources();

                //Move progress
                ProgressBarUpdate();

                lblProImport.Text = "Movendo DLLS para a pasta de destino...";
                lblProImport.Refresh();

                //Move DLLs para o caminho de destino
                MoveDLLs(@"C:\Inst\ImportService");

                lblProImport.Text = "Finalizando...";
                lblProImport.Refresh();

            }

            lblProImport.Text = "Iniciando o Serviço do Cold Import...";
            lblProImport.Refresh();

            //Inicia Serviço
            Services.ServiceStart();

            //Move progress
            ProgressBarUpdate();

            lblProImport.Font = new Font(lblProImport.Font, FontStyle.Bold);
            lblProImport.ForeColor = Color.Green;
            lblProImport.Text = "Concluido";
            PctImport.Visible = true;
            BtnNext.Enabled = true;
            lblCopy.Text = "Todos os arquivos foram copiados";
            lblFile.Text = "";

        }

        //Extrai os arquivos com as DLLs
        private void ExtractResources()
        {            
            lblProImport.Text = "Extraindo DLLs, aguarde...";
            lblProImport.Refresh();

            string pathConnector = @"";

            if (!Directory.Exists(@"C:\Inst"))
            {
                Directory.CreateDirectory(@"C:\Inst");
            }
            else
            {
                System.IO.Directory.Delete(@"c:\Inst\", true);
            }

            byte[] bin = Installer.Properties.Resources.ImportService;
            Directory.CreateDirectory(@"C:\Inst");
            pathConnector = @"C:\Inst\ImportService.exe";
            NSIS.ByteArrayToFile(pathConnector, bin);

            Process processo = new Process();
            processo.StartInfo.FileName = pathConnector;
            processo.StartInfo.WindowStyle = ProcessWindowStyle.Hidden;
            processo.Start();

            processo.WaitForExit();
            processo.Close();
            
        }

        //Calcula a quantidade de arquivos na pastas para definir o tamanho da barra de progresso
        private void CalculateFileQuantity()
        {
            string[] filesImport = System.IO.Directory.GetFiles(@"C:\Inst\importService\");
            string[] pathsImport = System.IO.Directory.GetDirectories(@"C:\Inst\importService\");

            progressStatus.Maximum = filesImport.Length + pathsImport.Length + 5;
            progressStatus.Refresh();
        }

        //Atualiza a barra de progresso
        private void ProgressBarUpdate()
        {
            progressStatus.Value++;
            progressStatus.Refresh();
        }

        //Move as DLLs para a pasta de destino
        private void MoveDLLs(string path)
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
                    File.Move(path + @"\" + fileName, ControllerClass.PathFolder + @"\Connector\Import Service" + @"\" + fileName);

                    lblFile.Text = "";
                    lblFile.Refresh();
                    lblFile.Text = fileName;
                    lblFile.Refresh();

                    ProgressBarUpdate();
                }

                foreach (string p in paths)
                {
                    string directoryName = System.IO.Path.GetFileName(p);
                    Directory.Move(path + @"\" + directoryName, ControllerClass.PathFolder + @"\Connector\Import Service" + @"\" + directoryName);

                    lblFile.Text = "";
                    lblFile.Refresh();
                    lblFile.Text = directoryName;
                    lblFile.Refresh();

                    ProgressBarUpdate();
                }
            }

            ImportService.VersionControlUpdate();
        }
        
    }

}

