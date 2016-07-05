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
    /// Interaction logic for CreateMedicalPrescription.xaml
    /// </summary>
    public partial class CreateMedicalPrescription : Window
    {
        public CreateMedicalPrescription()
        {
            InitializeComponent();
            DispatcherTimer timer = new DispatcherTimer();
            timer.Interval = TimeSpan.FromSeconds(1);
            timer.Tick += timer_Tick;
            timer.Start();
        }
        void timer_Tick(object sender, EventArgs e)
        {
            createMedicalPrescriptionDate.Text = DateTime.Now.ToLongDateString();
        }
    }
}
