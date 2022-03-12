using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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

        public void OpenConnection()
        {
            this.connection = new MySqlConnection(this.connetionString);
            this.connection.Open();
            Console.WriteLine("Connection Open  !");
        }

        public void CloseConnection()
        {
            this.connection.Close();
        }

        public void Consulta(string query)
        {
            this.command = new MySqlCommand(query, this.connection);
            this.dataReader = this.command.ExecuteReader();

            while (this.dataReader.Read())
            {
                for (int i = 0; i < this.dataReader.FieldCount; i++)
                {
                    Console.Write(this.dataReader.GetValue(i));
                    Console.Write(" ");
                }
                Console.WriteLine();
            }
        }
    }
}
