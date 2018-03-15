﻿using System;
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
        public User user;

        public MainWindow()
        {
            InitializeComponent();
            this.Title = "Студентска информацонна система";

            addMarkBtn.Visibility = Visibility.Hidden;
            btnGetStudentInfo.Visibility = Visibility.Hidden;
            disableAllBoxes();
            clearAllTextBoxes();

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

            logoutBtn.IsEnabled = false;
        }

        private void clearBtn_Click(object sender, RoutedEventArgs e)
        {
            clearAllTextBoxes();
        }

        private void clearAllTextBoxes()
        {
            // Clear personal info
            firstNameBox.Clear();
            secondNameBox.Clear();
            lastNameBox.Clear();

            // Clear student info
            educationDegreeBox.SelectedIndex = 0;
            degreeStatusBox.SelectedIndex = 0;
            courseBox.SelectedIndex = 0;
            facilityBox.Clear();
            specializationBox.Clear();
            facNumberBox.Clear();
            streamBox.Clear();
            groupBox.Clear();
        }

        private void btnMakeDisable_Click(object sender, RoutedEventArgs e)
        {
            disableAllBoxes();
        }

        private void disableAllBoxes()
        {
            // Clear personal info
            firstNameBox.IsEnabled = false;
            secondNameBox.IsEnabled = false;
            lastNameBox.IsEnabled = false;

            // Clear student info
            educationDegreeBox.IsEnabled = false;
            degreeStatusBox.IsEnabled = false;
            courseBox.IsEnabled = false;
            facilityBox.IsEnabled = false;
            specializationBox.IsEnabled = false;
            facNumberBox.IsEnabled = false;
            streamBox.IsEnabled = false;
            groupBox.IsEnabled = false;
        }

        private void btnMakeEnable_Click(object sender, RoutedEventArgs e)
        {
            enableAllBoxes();
        }

        private void enableAllBoxes()
        {
            // Clear personal info
            firstNameBox.IsEnabled = true;
            secondNameBox.IsEnabled = true;
            lastNameBox.IsEnabled = true;

            // Clear student info
            educationDegreeBox.IsEnabled = true;
            degreeStatusBox.IsEnabled = true;
            courseBox.IsEnabled = true;
            facilityBox.IsEnabled = true;
            specializationBox.IsEnabled = true;
            facNumberBox.IsEnabled = true;
            streamBox.IsEnabled = true;
            groupBox.IsEnabled = true;
        }

        private void btnGetStudentInfo_Click(object sender, RoutedEventArgs e)
        {
            string facNumber = facNumberBox.Text;
            
            GetStudentInfoByFacNumber(facNumber);
        }

        private void  GetStudentInfoByFacNumber(string facNumber)
        {
            // Add students in the list
            StudentData.AddSomeStudents();
            
            if (facNumber == "")
            {
                MessageBox.Show("Please enter a faculity number");
                return;
            }

            Student student = null;
            try
            {
                student = StudentData.GetStudent(facNumber);
            }
            catch (Exception exp)
            {
                MessageBox.Show(exp.Message);
                return;
            }

            AddStudentInfo(student);
        }

        private void AddStudentInfo(Student student)
        {
            // Clear personal info
            firstNameBox.Text = student.firstName;
            secondNameBox.Text = student.secondName;
            lastNameBox.Text = student.lastName;

            // Clear student info
            educationDegreeBox.SelectedIndex = (int)(EducationDegree)student.educationDegree;
            degreeStatusBox.SelectedIndex = (int)(DegreeStatus)student.status;
            courseBox.SelectedIndex = student.course;
            facilityBox.Text = student.facility;
            specializationBox.Text = student.specialization;
            facNumberBox.Text = student.facNumber;
            streamBox.Text = student.stream.ToString();
            groupBox.Text = student.group.ToString();
        }

        private void loginBtn_Click(object sender, RoutedEventArgs e)
        {
            // Sanitize the box
            clearAllTextBoxes();

            string username = usernameBox.Text;
            string password = passwordBox.Text;

            // Login in the Program.cs of UserLogin
            LoginValidation validation = new LoginValidation(username, password, UserLogin.Program.ValidationErrorHandler);

            user = new User();
            user.username = username;
            user.password = password;

            if (validation.ValidateUserInput(ref user))
            {
                // Student role
                if (user.roleId == 4)
                {
                    enableAllBoxes();
                    GetStudentInfoByFacNumber(user.facNumber);
                    loginBtn.IsEnabled = false;
                    logoutBtn.IsEnabled = true;
                }

                // Professor role
                else if (user.roleId == 1)
                {
                    enableAllBoxes();
                    clearAllTextBoxes();
                    addMarkBtn.Visibility = Visibility.Visible;
                    btnGetStudentInfo.Visibility = Visibility.Visible;
                    loginBtn.IsEnabled = false;
                    logoutBtn.IsEnabled = true;
                }
            }

            else
            {
                MessageBox.Show("Invalid username and/or password");
            }

        }

        private void logoutBtn_Click(object sender, RoutedEventArgs e)
        {
            if(!loginBtn.IsEnabled)
            {
                // Set user role to anonymous id
                this.user.roleId = (int)UserRoles.ANONYMOUS;

                loginBtn.IsEnabled = true;
                logoutBtn.IsEnabled = false;
                
                clearAllTextBoxes();
                disableAllBoxes();
            }
        }

        private void addMarkBtn_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
