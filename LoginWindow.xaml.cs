using MySql.Data.MySqlClient;
using SGS.DB;
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

namespace SGS
{
    /// <summary>
    /// Interaction logic for LoginWindow.xaml
    /// </summary>
    public partial class LoginWindow : Window
    {
        public LoginWindow()
        {
            this.WindowStartupLocation = WindowStartupLocation.CenterScreen;
            InitializeComponent();
            Registration.Visibility = System.Windows.Visibility.Collapsed;

            dbconnector = new DBConnector();
            mysqlconnection = new MySqlConnection(dbconnector.getConnectionString());
        }

        DBConnector dbconnector;

        MySqlConnection mysqlconnection;
        MySqlCommand mysqlcommand;
        MySqlDataReader mysqldatareader;

        private void btn_ConfirmLogin_Click(object sender, RoutedEventArgs e)
        {
            // ONLY FOR TESTING
            MainWindow mainwindow = new MainWindow();
            this.Close();
            mainwindow.Show();
        }

        private void btn_ConfirmRegistration_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                string insertUser = "INSERT INTO `sgs`.`user` (`username`, `password`, `name`, `cpf`, `email`, `address`, `city`, `district`, `state`, `cep`, `accessLevel`) VALUES ('" + Username.Text + "', SHA1('" + Password.Password + "'), '" + Name.Text + "', '" + CPF.Text + "', '" + Email.Text + "', '" + Address.Text + "', '" + City.Text + "', '" + District.Text + "', '" + State.Text + "', '" + CEP.Text + "', '0');";
                mysqlcommand = new MySqlCommand(insertUser, mysqlconnection);
                mysqlconnection.Open();
                mysqldatareader = mysqlcommand.ExecuteReader();
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
            }
            finally
            {
                mysqlconnection.Close();
                MessageBox.Show("Bem-vindo ao SGS, " + Username.Text + "!");
                MainWindow mainwindow = new MainWindow();
                this.Close();
                mainwindow.Show();
            }
        }

        private void btn_UpdateAddress_Click(object sender, RoutedEventArgs e)
        {

        }

        private void btn_Login_Click(object sender, RoutedEventArgs e)
        {
            Login.Visibility = System.Windows.Visibility.Visible;
            Registration.Visibility = System.Windows.Visibility.Collapsed;
        }

        private void btn_Registration_Click(object sender, RoutedEventArgs e)
        {
            Registration.Visibility = System.Windows.Visibility.Visible;
            Login.Visibility = System.Windows.Visibility.Collapsed;
        }
    }
}
