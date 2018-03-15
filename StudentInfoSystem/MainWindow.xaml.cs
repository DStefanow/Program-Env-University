using System;
using System.Windows;
using StudentRepository;
using UserLogin;

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

            educationDegreeBox.SelectedIndex = 0;
            foreach (EducationDegree degree in Enum.GetValues(typeof(EducationDegree)))
            {
                educationDegreeBox.Items.Add(degree);
            }

            degreeStatusBox.SelectedIndex = 0;
            foreach (DegreeStatus degreeStatus in Enum.GetValues(typeof(DegreeStatus)))
            {
                degreeStatusBox.Items.Add(degreeStatus);
            }

            courseBox.SelectedIndex = 0;
            for (ushort i = 1; i < 5; i++)
            {
                courseBox.Items.Add(i);
            }
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
