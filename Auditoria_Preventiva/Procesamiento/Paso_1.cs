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
        private string _Extension;
        public string Extension
        {
            get { return this._Extension; }
            set { this._Extension = value; }
        }

        public Paso_1(string Extension = "*.asc")
        {
            this.Extension = Extension;
        }

        private string[] GetFilesFromDirectory(string path)
        {
            return Directory.GetFiles(path, this._Extension);
        }

        public List<string> LeerArchivosCarpeta(string path)
        {
            string[] files = GetFilesFromDirectory(path);
            List<string> filesFromArray = FilterFilesDataStage(files.ToList());
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

        public List<string> FilterFilesDataStage(List<string> files)
        {
            List<string> newFiles = new List<string>();
            foreach (string file in files)
            {
                string[] fileName = file.Split("\\");
                string[] codeExtention = fileName[fileName.Length - 1].Split('_');

                int outResult = 0;

                if (int.TryParse(codeExtention[1].Split('.')[0], out outResult))
                {
                    newFiles.Add(file);
                }

            }
            return newFiles;
        }
    }
}
