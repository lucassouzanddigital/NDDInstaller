using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Threading;
using NDDigital.eForms.Installer.EntryDocuments.Manager;
using NDDigital.eForms.Installer.EntryDocuments.PresentationFolder;
using System.Timers;
using System.Globalization;
using System.Diagnostics;
using NDDigital.eForms.Installer.EntryDocuments.Compression;
using NDDigital.eForms.Installer.EntryDocuments.Instalation.Entry;
using NDDigital.eForms.Installer.EntryDocuments.Instalation;
using System.IO;
using NDDigital.eForms.Installer.EntryDocuments.Service;

namespace NDDigital.eForms.Installer.EntryDocuments.Controls.ProgressControls
{
    public partial class Progress : UserControl
    {
        ExtractFileCompacted NSIS = new ExtractFileCompacted();
        EntryDocument entry = new EntryDocument();
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

                lblProEntry.Text = "Criando Serviço do Entry Documents...";
                lblProEntry.Refresh();

                //Move progress
                ProgressBarUpdate();

                Services.CreateService(ControllerClass.PathFolder + @"\Connector\Entry Documents Service\NDDigital.eForms.EntryDocumentsService.exe", "NDDigitaleFormsEntryDocumentsService",
                                                                                            "Serviço responsável pela captura e processamento de arquivos de notas de entrada.", "NDDigital e-Forms Entry Document Service");

                //Move progress
                ProgressBarUpdate();

                ExtractResources();

                //Move progress
                ProgressBarUpdate();

                MoveDLLs(@"C:\Inst\EntryDocuments");

            }

            //Caso seja Update, para o serviço para atualizar as DLLs
            else
            {
                lblProEntry.Text = "Parando Serviço do Entry Documents...";
                lblProEntry.Refresh();

                //Move progress
                ProgressBarUpdate();

                //Parando os Serviços
                Services.ServiceStop();
                                
                Thread.Sleep(2000);

                lblProEntry.Text = "Deletando arquivos antigos...";
                lblProEntry.Refresh();

                removeFiles.DeleteSchemasFrom(ControllerClass.PathFolder + @"\Connector\Entry Documents Service\Schemas");
                removeFiles.DeleteFilesFrom(ControllerClass.PathFolder + @"\Connector\Entry Documents Service");
               
                //Move progress
                ProgressBarUpdate();

                //Extrai DLLs
                ExtractResources();

                //Move progress
                ProgressBarUpdate();

                lblProEntry.Text = "Movendo DLLS para a pasta de destino...";
                lblProEntry.Refresh();

                //Move DLLs para o caminho de destino
                MoveDLLs(@"C:\Inst\EntryDocuments");

                lblProEntry.Text = "Finalizando...";
                lblProEntry.Refresh();

            }

            lblProEntry.Text = "Iniciando o Serviço do Entry Documents...";
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
        private void ExtractResources()
        {            
            lblProEntry.Text = "Extraindo DLLs, aguarde...";
            lblProEntry.Refresh();

            string pathConnector = @"";

            if (!Directory.Exists(@"C:\Inst"))
            {
                Directory.CreateDirectory(@"C:\Inst");
            }
            else
            {
                System.IO.Directory.Delete(@"c:\Inst\", true);
            }

            byte[] bin = EntryDocuments.Properties.Resources.EntryDocuments;
            Directory.CreateDirectory(@"C:\Inst");
            pathConnector = @"C:\Inst\EntryDocument.exe";
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
            string[] filesEntry = System.IO.Directory.GetFiles(@"C:\Inst\EntryDocument\");
            string[] pathsEntry = System.IO.Directory.GetDirectories(@"C:\Inst\EntryDocument\");

            progressStatus.Maximum = filesEntry.Length + pathsEntry.Length + 5;
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
                    File.Move(path + @"\" + fileName, ControllerClass.PathFolder + @"\Connector\Entry Documents Service" + @"\" + fileName);

                    lblFile.Text = "";
                    lblFile.Refresh();
                    lblFile.Text = fileName;
                    lblFile.Refresh();

                    ProgressBarUpdate();
                }

                foreach (string p in paths)
                {
                    string directoryName = System.IO.Path.GetFileName(p);
                    Directory.Move(path + @"\" + directoryName, ControllerClass.PathFolder + @"\Connector\Entry Documents Service" + @"\" + directoryName);

                    lblFile.Text = "";
                    lblFile.Refresh();
                    lblFile.Text = directoryName;
                    lblFile.Refresh();

                    ProgressBarUpdate();
                }
            }

            EntryDocument.VersionControlUpdate();
        }
        
    }

}

