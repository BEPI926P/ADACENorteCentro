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
        private static List<string> _ColumnsName { get; set; }
        private static List<string> _ColumnsNameFile { get; set; }


        public static void Main(string[] args)
        {
            Paso1();
            Paso2();
            //Paso3();
        }

        public static void Paso1()
        {
            // Leer archivos desde una carpeta
            string path;
            Console.Write("Ingresa la ubicacion de la carpeta a leer: ");
            path = Console.ReadLine();

            Paso_1 paso1 = new Paso_1();
            _FilesFromFolder = paso1.LeerArchivosCarpeta(path);

            /*foreach (string fileName in _FilesFromFolder)
            {
                Console.WriteLine("Archivo Leido => " + fileName);
            }*/
        }

        public static void Paso2()
        {
            Paso_2 paso2 = new Paso_2();
            _FilesProcesed = new List<string[]>();

            foreach (string fileName in _FilesFromFolder)
            {
                _FilesProcesed.Add(paso2.ReadDataInFile(fileName));
                Console.WriteLine("File name => " + fileName);
                paso2.PrintFileData(fileName);
                Console.WriteLine("*******************************************************************************");
            }
        }

        public static void Paso2Deprecated()
        {
            // Leer contenido de archivos de texto.
            // Procesar datos leidos
            Paso_2 paso2 = new Paso_2();
            _FilesProcesed = new List<string[]>();
            // Archivo de columnas
            _ColumnsName = new List<string>();
            // Archivo de datos(archivos *.asc)
            _ColumnsNameFile = new List<string>();
            bool columnsFileSufferChanges = false;
            foreach (string file in _FilesFromFolder)
            {
                // Leer archivo con columnas almacenadas
                _ColumnsName.AddRange(paso2.ReadColumnsInDatabase());

                // Saber primero columans del archivo
                _ColumnsNameFile.AddRange(paso2.ReadColumns(file));

                // Procesamiento de columnas
                foreach (string column in _ColumnsNameFile)
                {
                    if (!_ColumnsName.Contains(column))
                    {
                        // columna no existe
                        _ColumnsName.Add(column);
                        columnsFileSufferChanges = true;
                    }
                }

                if (columnsFileSufferChanges)
                {
                    // Guardar columnas nuevas
                    if (paso2.SaveColumnsInFile(_ColumnsName))
                    {
                        Console.WriteLine("Se Guardaron las columnas!.");
                    }
                    else
                    {
                        Console.WriteLine("Error Guardando las columnas!.");
                    }
                }

                // Procesar el archivo segun relacion de columnas
                _FilesProcesed.Add(paso2.ReadFile(file).ToArray());
            }

            //paso2.PrintColumnsNames(_ColumnsName);
        }

        public static void Paso3()
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