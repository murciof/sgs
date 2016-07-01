using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using MySql.Data.MySqlClient;

namespace SGS.DB
{
    class DBConnector
    {
        MySqlConnection connection;

        public bool makeDatabaseConnection()
        {
            string server = "localhost";
            string database = "sgs";
            string uid = "root";
            string password = "root";

            string connectionString = "SERVER=" + server + ";" + "DATABASE=" + database + ";" + "UID=" + uid + ";" + "PASSWORD=" + password + ";";

            connection = new MySqlConnection(connectionString);

            if (OpenConnection())
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public MySqlConnection getMySqlConnection()
        {
            return connection;
        }

        private bool OpenConnection()
        {
            try
            {
                connection.Open();
                return true;
            }
            catch
            {
                return false;
            }
        }

        private bool CloseConnection()
        {
            try
            {
                connection.Close();
                return true;
            }
            catch
            {
                return false;
            }
        }

    }
}

