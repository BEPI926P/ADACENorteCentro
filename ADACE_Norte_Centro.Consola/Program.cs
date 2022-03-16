using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;

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
                 * 
                 * 
                 * int fecha = null;
                 * int fecha = 0;
                 * */
                //List<Models.Expediente> listaExpedientes = new List<Models.Expediente>();
                int conteoFilasSQL = 0;

                while (mysqlDataReader.Read())
                {
                    conteoFilasSQL = conteoFilasSQL + 1;
                }

                object[] listaExpedientes = new object[conteoFilasSQL];

                int conteoFilasSQL2 = 0;
                while (mysqlDataReader.Read())
                {
                    Models.Expediente expediente = new Models.Expediente();
                    expediente.idExpediente = mysqlDataReader.GetString(0);
                    expediente.NumeroOrden = mysqlDataReader.GetString(1);
                    expediente.TipoRevision = mysqlDataReader.GetString(2);
                    expediente.idContribuyente = mysqlDataReader.GetString(3);
                    expediente.FechadeApertura = mysqlDataReader.GetDateTime(4);
                    expediente.FechadeCierre = mysqlDataReader.GetDateTime(5);

                    listaExpedientes[conteoFilasSQL2] = expediente;

                    conteoFilasSQL2 = conteoFilasSQL2 + 1;

                    /*for (int i = 0; i < mysqlDataReader.FieldCount; i++)
                    {
                        Console.Write(" " + mysqlDataReader.GetValue(i));
                    }
                    Console.WriteLine();*/
                }
                dBConnection.CloseConnection();

                for (int i = 0; i < listaExpedientes.Length; i++)
                {
                    Models.Expediente expediente = (Models.Expediente)listaExpedientes[i];
                    Console.WriteLine(expediente.idExpediente + " " + expediente.NumeroOrden + " " + expediente.TipoRevision + " " + expediente.idContribuyente + " " + expediente.FechadeApertura + " " + expediente.FechadeCierre);
                }

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