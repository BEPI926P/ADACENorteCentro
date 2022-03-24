using System;
using System.IO;

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

        public static void Paso_1(string path)
        {
            // Leer archivo de texto
            string[] fileLines = File.ReadAllLines(path + "/SWH.usp_Reports_GetPackaginSlip.sql");

            // Modificamos archivo de texto
            fileLines[0] = "He modificado la linea";

            // Imprimimos en pantalla el archivo modificado
            foreach (string line in fileLines)
            {
                Console.WriteLine(line);
            }

            // Creamos un nuevo archivo
            File.WriteAllLines(path + "/SWH.usp_Reports_GetPackaginSlip_MODIFICADO.sql", fileLines);
        }

        public static void Paso_2()
        {

        }

        public static void Paso_3()
        {

        }
    }
}