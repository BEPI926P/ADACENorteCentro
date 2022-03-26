using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Auditoria_Preventiva.Procesamiento
{
    public class Paso_3
    {
        public Paso_3() { }

        public void CreateFile(string path, string[] fileData)
        {
            // Creamos un nuevo archivo
            File.WriteAllLines(path.Replace(".asc", ".csv"), fileData);
        }
    }
}
