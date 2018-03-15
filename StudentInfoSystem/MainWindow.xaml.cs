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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace StudentInfoSystem
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            this.Title = "Студентска информацонна система";
        }

        private void clearBtn_Click(object sender, RoutedEventArgs e)
        {
            // Clear personal info
            firstNameBox.Clear();
            secondNameBox.Clear();
            lastNameBox.Clear();

            // Clear student info
            facilityBox.Clear();
            specializationBox.Clear();
            facNumberBox.Clear();
            streamBox.Clear();
            groupBox.Clear();
        }
    }
}
