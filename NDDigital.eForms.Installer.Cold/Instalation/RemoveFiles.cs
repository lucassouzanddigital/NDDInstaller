using NDDigital.eForms.Installer.Cold.Controls.ProgressControls;
using NDDigital.eForms.Installer.Cold.Manager;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;

namespace NDDigital.eForms.Installer.Cold.Instalation
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
    }
}
