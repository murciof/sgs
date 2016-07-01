using MySql.Data.MySqlClient;
using System.Windows;

namespace SGS.DB
{
    class DBConnector
    {

        MySqlConnection mysqlconnection;

        string connectionString;

        public DBConnector()
        {
            string server = "localhost";
            string database = "sgs";
            string uid = "root";
            string password = "root";
            connectionString = "SERVER=" + server + ";" + "DATABASE=" + database + ";" + "UID=" + uid + ";" + "PASSWORD=" + password + ";";

            mysqlconnection = new MySqlConnection(connectionString);
        }

        public string getConnectionString()
        {
            return connectionString;
        }

        //open connection to database
        public bool OpenConnection()
        {
            try
            {
                mysqlconnection.Open();
                return true;
            }
            catch (MySqlException ex)
            {
                //When handling errors, you can your application's response based 
                //on the error number.
                //The two most common error numbers when connecting are as follows:
                //0: Cannot connect to server.
                //1045: Invalid user name and/or password.
                switch (ex.Number)
                {
                    case 0:
                        MessageBox.Show("ERRO 0 - Não foi possível conectar-se ao banco de dados.");
                        break;

                    case 1045:
                        MessageBox.Show("ERRO 1045 - Usuário/Senha inválidos. Tente novamente.");
                        break;
                }
                return false;
            }
        }

        //Close connection
        public bool CloseConnection()
        {
            try
            {
                mysqlconnection.Close();
                return true;
            }
            catch (MySqlException ex)
            {
                MessageBox.Show(ex.Message);
                return false;
            }
        }

    }

}
