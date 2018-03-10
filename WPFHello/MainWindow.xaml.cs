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

namespace WPFHello
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void btnHello_Click(object sender, RoutedEventArgs e)
        {
            if (usernameBox.Text.Length < 2)
            {
                MessageBox.Show("The username must be 2 symbols");
            }
            else
            { 
                MessageBox.Show("Hello!! Username: " + usernameBox.Text);
            }
        }

        private void calculate_Click(object sender, RoutedEventArgs e)
        {
            uint number = uint.Parse(nBox.Text);
            int power = int.Parse(powerBox.Text);

            uint maskNumber = number;
            ulong fac = 1;

            while (maskNumber > 1)
            {
                fac *= maskNumber;
                maskNumber--;
            }

            ulong powerRes = 1;
            for (int i = 0; i < power; i++)
            {
                powerRes *= number;
            }

            MessageBox.Show("Results ready:\r\nFactorial: " + fac + " \r\nPower result: " + powerRes);
        }
    }
}
