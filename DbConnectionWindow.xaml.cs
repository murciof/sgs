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
        public DbConnectionWindow()
        {
            InitializeComponent();
            DBConnector dbconnector = new DBConnector();

            MySqlCommand mysqlcommand;
            MySqlDataReader mysqldatareader;
            if (dbconnector.makeDatabaseConnection())
            {
                Status.Text = "Banco de Dados conectado";
                mysqlcommand = new MySqlCommand("SELECT * FROM sgs.user", dbconnector.getMySqlConnection());
                mysqldatareader = mysqlcommand.ExecuteReader();
                if (mysqldatareader.Read())
                {
                    MainWindow mainwindow = new MainWindow();
                    this.Close();
                    mainwindow.Show();
                }
                else
                {
                    FirstTimeWindow firsttimewindow = new FirstTimeWindow();
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
