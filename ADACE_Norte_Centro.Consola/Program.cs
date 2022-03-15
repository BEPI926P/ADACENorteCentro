using MySql.Data.MySqlClient;
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

            try
            {
                // Probar conexion a la base de datos
                DBConnection.DBConnection dBConnection = new DBConnection.DBConnection(connectionString);
                MySqlDataReader mysqlDataReader = dBConnection.Consulta("SELECT idExpediente,NumerodeOrden,TipodeRevision,idContribuyente,FechadeApertura,FechadeCierre FROM auditoria.expediente;");

                /*
                 * filas-rows
                 * */
                while (mysqlDataReader.Read())
                {
                    for (int i = 0; i < mysqlDataReader.FieldCount; i++)
                    {
                        Console.Write(" " + mysqlDataReader.GetValue(i));
                    }
                    Console.WriteLine();
                }
                dBConnection.CloseConnection();

                //Conexion nueva
                /*DBConnection.DBConnection dBConnection1 = new DBConnection.DBConnection(connectionString);
                dBConnection1.Consulta("SELECT * FROM Auditoria.Contribuyente;");*/
            }
            catch (Exception excepcion)
            {
                Console.WriteLine("Error al procesar informacion: " + excepcion.Message);
            }
        }
    }
}