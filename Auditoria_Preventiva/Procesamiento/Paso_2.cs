using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Auditoria_Preventiva.Procesamiento
{
    public class Paso_2
    {
        public Paso_2() { }

        public string[] ReadFile(string fileName)
        {
            // Leer archivo de texto
            string[] fileLines = System.IO.File.ReadAllLines(fileName);

            string[] fileToSave = new string[fileLines.Length];

            int contador = 0;

            foreach (string line in fileLines)
            {
                string tempLine = line.Replace(",", ";");
                tempLine = tempLine.Replace("|", ",");

                fileToSave[contador] = tempLine;
                contador = contador + 1;
            }

            return fileToSave;
        }
    }
}
