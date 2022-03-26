using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Auditoria_Preventiva
{
    public class Auditoria_Preventiva
    {
        public static void Main(string[] args)
        {
            // pasos para procesar nuestro archivo txt en excel
            // * agregar log
            // - Leer archivo .asc (leemos como txt normal) y cargamos la informacion.
            // - Procesamos los datos leidos y convertimos a datos requeridos.
            // - Vacias a excel nuestros datos procesados.
            string path = string.Empty;
            Console.Write("Ingresa la ubicacion de la carpeta a leer: ");
            path = Console.ReadLine();            

            Paso_1(path);
            Paso_2();
            Paso_3();
        }

        public static void ListarDirectorio(string path, string fileExtension)
        {
            string[] files = Directory.GetFiles(path, fileExtension);
            foreach (var file in files)
            {
                Console.WriteLine(file);
            }
        }

        public static void Paso_1_REF(string path)
        {
            // Listar un directorio
            ListarDirectorio(path, "*.*");

            // Leer archivo de texto
            string file = System.IO.File.ReadAllText(path + "/SWH.usp_Reports_GetPackaginSlip.sql");

            // Modificamos archivo de texto
            string file2 = file.Replace("/* rptPackaginSlip */", "/* rpt */");

            // Imprimimos en pantalla el archivo modificado
            System.Console.WriteLine(file2);

            // Creamos un nuevo archivo
            File.WriteAllText(path + "/SWH.usp_Reports_GetPackaginSlip_MODIFICADO.sql", file2);
        }

        /// <summary>
        /// Lee archivo especificado
        /// </summary>
        /// <param name="fileName"></param>
        public static void LeerArchivo(string fileName)
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

            // Creamos un nuevo archivo
            File.WriteAllLines(fileName.Replace(".asc", ".csv"), fileToSave);
        }

        public static void Paso_1(string path)
        {
            string[] files = Directory.GetFiles(path, "*.asc");
            foreach (string fileName in files)
            {
                Console.WriteLine("Modificando el archivo: " + fileName);
                LeerArchivo(fileName);
            }
        }

        public static void Paso_2()
        {

        }

        public static void Paso_3()
        {

        }
    }
}