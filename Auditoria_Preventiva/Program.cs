using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Auditoria_Preventiva.Procesamiento;

namespace Auditoria_Preventiva
{
    public class Auditoria_Preventiva
    {
        private static List<string> _FilesFromFolder { get; set; }
        private static List<string[]> _FilesProcesed { get; set; }

        public static void Main(string[] args)
        {
            Paso_1();
            Paso_2();
            Paso_3();
        }

        public static void Paso_1()
        {
            // Leer archivos desde una carpeta
            string path = string.Empty;
            Console.Write("Ingresa la ubicacion de la carpeta a leer: ");
            path = Console.ReadLine();

            Paso_1 paso1 = new Paso_1();
            _FilesFromFolder = paso1.LeerArchivosCarpeta(path);

            foreach (string fileName in _FilesFromFolder)
            {
                Console.WriteLine("Archivo Leido => " + fileName);
            }
        }

        public static void Paso_2()
        {
            // Leer contenido de archivos de texto.
            // Procesar datos leidos
            Paso_2 paso2 = new Paso_2();
            _FilesProcesed = new List<string[]>();
            foreach (string file in _FilesFromFolder)
            {
                _FilesProcesed.Add(paso2.ReadFile(file));
            }
        }

        public static void Paso_3()
        {
            // Guardar datos procesados en excel.
            Paso_3 paso3 = new Paso_3();

            foreach (string file in _FilesFromFolder)
            {
                string[] fileProcesed = _FilesProcesed[_FilesFromFolder.IndexOf(file)];
                paso3.CreateFile(file, fileProcesed);
            }
        }
    }
}