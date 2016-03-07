using NDDigital.eForms.Installer.EntryDocuments.Controls.ProgressControls;
using NDDigital.eForms.Installer.EntryDocuments.Manager;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;

namespace NDDigital.eForms.Installer.EntryDocuments.Instalation
{
    public class RemoveFiles
    {
        //Deleta apenas arquivos de dentro de uma pasta
        public void DeleteFilesFrom(string path)
        {
            if (System.IO.Directory.Exists(path))
            {
                string[] files = System.IO.Directory.GetFiles(path);                

                foreach (string s in files)
                {
                    string fileName = System.IO.Path.GetFileName(s);
                    File.SetAttributes(path + @"\" + fileName, FileAttributes.Normal);
                    
                    File.Delete(path + @"\" + fileName);
                   
                }
                                        
            }
        }

        //Apaga os Schemas
        public void DeleteSchemasFrom(string path)
        {
            File.SetAttributes(path, FileAttributes.Normal);

            string[] files = Directory.GetFiles(path);
            string[] dirs = Directory.GetDirectories(path);

            foreach (string file in files)
            {
                File.SetAttributes(file, FileAttributes.Normal);
                File.Delete(file);
            }

            foreach (string dir in dirs)
            {
                DeleteSchemasFrom(dir);
            }

            Directory.Delete(path, false);
        }
    }
}
