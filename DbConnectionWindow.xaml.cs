using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using SGS.DB;

using MySql.Data.MySqlClient;

namespace SGS
{
    /// <summary>
    /// Interaction logic for DbConnectionWindow.xaml
    /// </summary>
    public partial class DbConnectionWindow : Window
    {

        MySqlConnection mysqlconnection;

        public DbConnectionWindow()
        {
            InitializeComponent();
            DBConnector dbconnector = new DBConnector();

            mysqlconnection = new MySqlConnection(dbconnector.getConnectionString());
            MySqlCommand mysqlcommand;

            if (dbconnector.OpenConnection())
            {
                Status.Text = "Banco de Dados conectado";
                mysqlcommand = new MySqlCommand("SELECT COUNT(*) FROM sgs.user WHERE idUser IS NOT NULL;", mysqlconnection);
                mysqlconnection.Open();
                int result = int.Parse(mysqlcommand.ExecuteScalar().ToString());
                if (result==1)
                {
                    MainWindow mainwindow = new MainWindow();
                    mysqlconnection.Close();
                    this.Close();
                    mainwindow.Show();
                }
                else
                {
                    FirstTimeWindow firsttimewindow = new FirstTimeWindow();
                    mysqlconnection.Close();
                    this.Close();
                    firsttimewindow.Show();
                }
            }
            else
            {
                Status.Text = "Não foi possível realizar a conexão";
            }
        }
    }
}
