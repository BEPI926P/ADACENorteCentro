using System;

namespace ADACE_Norte_Centro.Consola
{
    public class Consola
    {
        public static void Main(string[] args)
        {
            Consola.Paso2();
        }

        public static void Paso2()
        {
            Console.WriteLine("Bienvenido a ADACE Norte-Centro");
            string connectionString = "Server=localhost;Database=auditoria;Uid=adace;Pwd=adaceNC";

            // Probar conexion a la base de datos
            DBConnection.DBConnection dBConnection = new DBConnection.DBConnection(connectionString);
            dBConnection.OpenConnection();
            dBConnection.Consulta("SELECT * FROM auditoria.expediente;");


            //Conexion nueva
            DBConnection.DBConnection dBConnection1 = new DBConnection.DBConnection(connectionString);
            dBConnection1.OpenConnection();
            dBConnection1.Consulta("SELECT * FROM Auditoria.Contribuyente;");
        }
    }
}