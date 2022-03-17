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

                // Solucion factible
                List<Models.Expediente> listaExpedientes = new List<Models.Expediente>();

                while (mysqlDataReader.Read())
                {
                    Models.Expediente expediente = new Models.Expediente();
                    expediente.idExpediente = mysqlDataReader.GetString("idExpediente");
                    expediente.NumeroOrden = mysqlDataReader.GetString(1);
                    expediente.TipoRevision = mysqlDataReader.GetString(2);
                    expediente.idContribuyente = mysqlDataReader.GetString(3);
                    expediente.FechadeApertura = mysqlDataReader.GetDateTime(4);
                    expediente.FechadeCierre = ConvertFromDBVal<DateTime>(mysqlDataReader.GetValue(5));

                    listaExpedientes.Add(expediente);
                }

                dBConnection.CloseConnection();

                foreach (Models.Expediente expedienteInterno in listaExpedientes)
                {
                    Console.WriteLine(expedienteInterno.ToString());
                }
            }
            catch (Exception excepcion)
            {
                Console.WriteLine("Error al procesar informacion: " + excepcion.Message);
            }
        }

        public static T ConvertFromDBVal<T>(object obj)
        {
            if (obj == null || obj == DBNull.Value)
            {
                return default(T); // returns the default value for the type
            }
            else
            {
                return (T)obj;
            }
        }
    }
}