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

            Paso_1();
            Paso_2();
            Paso_3();
        }

        public static void Paso_1(string path)
        {
            string[] files = Directory.GetFiles(path, "*.txt");
            foreach (var file in files)
            {
                Console.WriteLine(file);
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