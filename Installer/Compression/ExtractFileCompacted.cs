using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Installer.Compression
{
    public class ExtractFileCompacted
    {
        
        //Extrai o arquivo compactado que se encontra no resource (DLLs)
        public bool ByteArrayToFile(string _FileName, byte[] _ByteArray)
        {
            try
            {              
                System.IO.FileStream _FileStream =
                   new System.IO.FileStream(_FileName, System.IO.FileMode.Create,
                                            System.IO.FileAccess.Write);

                _FileStream.Write(_ByteArray, 0, _ByteArray.Length);
                           
                _FileStream.Close();

                return true;
            }
            catch (Exception _Exception)
            {
                
                Console.WriteLine("Ocorreu um erro no processo: {0}",
                                  _Exception.ToString());
            }
           
            return false;
        }


    }
}
