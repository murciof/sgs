using Correios.Net;
using MySql.Data.MySqlClient;
using SGS.DB;
using System.Net;
using System.Windows;


namespace SGS
{
    /// <summary>
    /// Interaction logic for FirstTimeWindow.xaml
    /// </summary>
    public partial class FirstTimeWindow : Window
    {
        public FirstTimeWindow()
        {
            this.WindowStartupLocation = WindowStartupLocation.CenterScreen;
            InitializeComponent();
            dbconnector = new DBConnector();
            mysqlconnection = new MySqlConnection(dbconnector.getConnectionString());
        }

        DBConnector dbconnector;

        MySqlConnection mysqlconnection;
        MySqlCommand mysqlcommand;
        MySqlDataReader mysqldatareader;

        private void btn_UpdateAddress_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                using (var client = new WebClient())
                using (var stream = client.OpenRead("http://correios.com.br"))
                {
                    Address address = SearchZip.GetAddress(CEP.Text);

                    Address.Text = address.Street;
                    District.Text = address.District;
                    City.Text = address.City;
                    State.Text = address.State;
                }
            }
            catch
            {
                MessageBox.Show("Não foi possível conectar-se ao banco de dados dos Correios");
            }
        }

        private void btn_ConfirmData_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                string insertUser = "INSERT INTO `sgs`.`user` (`username`, `password`, `name`, `cpf`, `email`, `address`, `city`, `district`, `state`, `cep`, `accessLevel`) VALUES ('"+Username.Text+ "', SHA1('"+Password.Password+"'), '"+Name.Text+"', '"+CPF.Text+"', '"+Email.Text+"', '"+Address.Text+"', '"+City.Text+"', '"+District.Text+"', '"+State.Text+"', '"+CEP.Text+"', '3');";
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
                MessageBox.Show("Bem-vindo ao SGS, "+Username.Text+"!");
                MainWindow mainwindow = new MainWindow();
                this.Close();
                mainwindow.Show();
            }
        }
    }
}
