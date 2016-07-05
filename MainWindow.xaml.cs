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
using System.Windows.Threading;

namespace SGS
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        
        public MainWindow()
        {
            this.WindowStartupLocation = WindowStartupLocation.CenterScreen;
            this.WindowState = WindowState.Maximized;
            InitializeComponent();
            DispatcherTimer timer = new DispatcherTimer();
            timer.Interval = TimeSpan.FromSeconds(1);
            timer.Tick += timer_Tick;
            timer.Start();
        }

        public void selectPanel(Grid panelSelected)
        {
            MainPanel_About.Visibility = System.Windows.Visibility.Collapsed;
            MainPanel_Attendance.Visibility = System.Windows.Visibility.Collapsed;
            MainPanel_ClientCatalog.Visibility = System.Windows.Visibility.Collapsed;
            MainPanel_Dashboard.Visibility = System.Windows.Visibility.Collapsed;
            MainPanel_EmployeeCatalog.Visibility = System.Windows.Visibility.Collapsed;
            MainPanel_EmployeeRegistration.Visibility = System.Windows.Visibility.Collapsed;
            MainPanel_ScheduleAppointment.Visibility = System.Windows.Visibility.Collapsed;

            panelSelected.Visibility = System.Windows.Visibility.Visible;
        }

        void timer_Tick(object sender, EventArgs e)
        {
            rightsidebar_hour.Text = DateTime.Now.ToShortTimeString();
            rightsidebar_date.Text = DateTime.Now.ToShortDateString();
        }

        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            e.Cancel = true;
            this.Hide();
        }

        public void Close()
        {
            this.Closing -= Window_Closing;
            //Add closing logic here.
            base.Close();
        }

        private void btn_ShowClientData_Click(object sender, RoutedEventArgs e)
        {
            ClientData clientdata = new ClientData();
            if (clientdata.IsActive)
            {
                clientdata.Close();
            }
            else
            {
                clientdata.Show();
                clientdata.Focus();
            }
        }

        private void btn_UpdateClinicalHistory_Click(object sender, RoutedEventArgs e)
        {
            UpdateClinicalHistory updateclinicalhistory = new UpdateClinicalHistory();
            if (updateclinicalhistory.IsActive)
            {
                updateclinicalhistory.Close();
            }
            else
            {
                updateclinicalhistory.Show();
                updateclinicalhistory.Focus();
            }
        }

        private void btn_CreateMedicalPrescription_Click(object sender, RoutedEventArgs e)
        {
            CreateMedicalPrescription createmedicalprescription = new CreateMedicalPrescription();
            if (createmedicalprescription.IsActive)
            {
                createmedicalprescription.Close();
            }
            else
            {
                createmedicalprescription.Show();
                createmedicalprescription.Focus();
            }
        }

        private void btn_CreateDeclaration_Click(object sender, RoutedEventArgs e)
        {
            CreateDeclaration createdeclaration = new CreateDeclaration();
            if (createdeclaration.IsActive)
            {
                createdeclaration.Close();
            }
            else
            {
                createdeclaration.Show();
                createdeclaration.Focus();
            }
        }

        private void btn_MainPanel_Dashboard_Click(object sender, RoutedEventArgs e)
        {
            selectPanel(MainPanel_Dashboard);
        }

        private void btn_MainPanel_Attendance_Click(object sender, RoutedEventArgs e)
        {
            selectPanel(MainPanel_Attendance);
        }

        private void btn_MainPanel_ClientCatalog_Click(object sender, RoutedEventArgs e)
        {
            selectPanel(MainPanel_ClientCatalog);
        }

        private void btn_MainPanel_EmployeeCatalog_Click(object sender, RoutedEventArgs e)
        {
            selectPanel(MainPanel_EmployeeCatalog);
        }

        private void btn_MainPanel_ScheduleAppointment_Click(object sender, RoutedEventArgs e)
        {
            selectPanel(MainPanel_ScheduleAppointment);
        }

        private void btn_MainPanel_RegisterEmployee_Click(object sender, RoutedEventArgs e)
        {
            selectPanel(MainPanel_EmployeeRegistration);
        }

        private void btn_MainPanel_About_Click(object sender, RoutedEventArgs e)
        {
            selectPanel(MainPanel_About);
        }
    }
}
