using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Auditoria_Preventiva.Procesamiento
{
    public class Paso_1
    {
        private string _Extension { get; set; }

        public Paso_1(string Extension = "*.asc")
        {
            this._Extension = Extension;
        }

        private string[] GetFilesFromDirectory(string path)
        {
            return Directory.GetFiles(path, this._Extension);
        }

        public List<string> LeerArchivosCarpeta(string path)
        {
            string[] files = GetFilesFromDirectory(path);
            List<string> filesFromArray = files.ToList();
            return filesFromArray;
        }

        public void ListarDirectorio(string path)
        {
            string[] files = GetFilesFromDirectory(path);
            foreach (var file in files)
            {
                Console.WriteLine(file);
            }
        }
    }
}
