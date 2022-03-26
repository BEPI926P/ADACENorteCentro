using MySql.Data.MySqlClient;
using System;

namespace ADACE_Norte_Centro.Consola.DBConnection
{
    public class DBConnection
    {
        private string connetionString;
        private MySqlConnection connection;
        private MySqlCommand command;
        private MySqlDataReader dataReader;

        public DBConnection(string connectionString)
        {
            this.connetionString = connectionString;
        }

        private void OpenConnection()
        {
            this.connection = new MySqlConnection();
            this.connection.ConnectionString = this.connetionString;
            this.connection.Open();
            Console.WriteLine("Connection Open  !");
        }

        public void CloseConnection()
        {
            this.connection.Close();
            Console.WriteLine("Conexion cerrada!.");
        }

        public MySqlDataReader Consulta(string query)
        {
            try
            {
                OpenConnection();
                this.command = new MySqlCommand(query, this.connection);
                this.dataReader = this.command.ExecuteReader();
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error en consulta: " + ex.Message);
            }

            return this.dataReader;
        }
    }
}
