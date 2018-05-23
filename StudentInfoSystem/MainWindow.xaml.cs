using System.Windows;
using System.Windows.Navigation;
using System;
using StudentRepository;
using UserLogin;
using System.Data;
using System.Data.SqlClient;
using System.Collections.Generic;

namespace StudentInfoSystem
{
    public partial class MainWindow : Window
    {
        public User user;

        public Student student { get; set; }

        public List<string> StudStatusChoices { get; set; }

        public MainWindow()
        {
            InitializeComponent();
            this.Title = "Студентска информацонна система";

            addMarkBtn.Visibility = Visibility.Hidden;
            btnGetStudentInfo.Visibility = Visibility.Hidden;
            ChangeAccessToAllBoxes(false);
            clearAllTextBoxes();

            // Get information for student degree from database
            FillStudStatusChoices();
            
            educationDegreeBox.SelectedIndex = 0;
            foreach (EducationDegree degree in Enum.GetValues(typeof(EducationDegree)))
            {
               educationDegreeBox.Items.Add(degree);
            }

            TestStudentsIfEmpty();

            // Add test data
            //InsertSpecializationExamples();

            //degreeStatusBox.SelectedIndex = 0;
            //foreach (DegreeStatus degreeStatus in Enum.GetValues(typeof(DegreeStatus)))
            //{
            //    degreeStatusBox.Items.Add(degreeStatus);
            //}

            courseBox.SelectedIndex = 0;
            for (ushort i = 1; i < 5; i++)
            {
                courseBox.Items.Add(i);
            }
            
            logoutBtn.IsEnabled = false;
        }

        private bool TestStudentsIfEmpty()
        {
            StudentInfoContext context = new StudentInfoContext();

            IEnumerable<Student> queryStudents = context.Students;
            return false;
        }

        private void InsertSpecializationExamples()
        {
            string[] specializations = { "Computer science", "Engineering", "Driver", "Chef", "Manager" };
            
            StudentInfoContext context = new StudentInfoContext();

            int i = 1;
            foreach (string specialization in specializations)
            {
                context.Specializations.Add(new Specialization(i, specialization));

                i++;
            }

            context.SaveChanges();
        }

        private void FillStudStatusChoices()
        {
            StudStatusChoices = new List<string>();

            using (IDbConnection connection = new SqlConnection(Properties.Settings.Default.DbConnection))
            {
                string sql = @"SELECT status_description FROM student_status";
                IDbCommand cmd = new SqlCommand();
                cmd.Connection = connection;
                connection.Open();

                cmd.CommandText = sql;
                IDataReader reader = cmd.ExecuteReader();

                bool notEndOfResult;
                notEndOfResult = reader.Read();

                while (notEndOfResult)
                {
                    string str = reader.GetString(0);
                    StudStatusChoices.Add(str);

                    notEndOfResult = reader.Read();
                }
            }
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
            facNumberBox.Clear();
            streamBox.Clear();
            groupBox.Clear();
        }

        private void btnMakeDisable_Click(object sender, RoutedEventArgs e)
        {
            ChangeAccessToAllBoxes(false);
        }

        private void btnMakeEnable_Click(object sender, RoutedEventArgs e)
        {
            ChangeAccessToAllBoxes(true);
        }

        private void btnGetStudentInfo_Click(object sender, RoutedEventArgs e)
        {
            string facNumber = facNumberBox.Text;
            
            this.student = GetStudentInfoByFacNumber(facNumber);
            this.DataContext = this.student;
        }

        private Student GetStudentInfoByFacNumber(string facNumber)
        {
            // Add students in the list
            StudentData.AddSomeStudents();
            
            if (facNumber == "")
            {
                MessageBox.Show("Please enter a faculity number");
                return null;
            }

            Student student = null;
            try
            {
                student = StudentData.GetStudent(facNumber);
            }
            catch (Exception exp)
            {
                MessageBox.Show(exp.Message);
            }

            return student;
        }

        private void AddStudentInfo(Student student)
        {   
            // Add personal info
            firstNameBox.Text = student.FirstName;
            secondNameBox.Text = student.SecondName;
            lastNameBox.Text = student.LastName;
            
            // Add student info
            educationDegreeBox.SelectedIndex = (int)(EducationDegree)student.EducationDegree;
            degreeStatusBox.SelectedIndex = (int)(DegreeStatus)student.Status;
            courseBox.SelectedIndex = student.Course;
            facilityBox.Text = student.Facility;
            specializationBox.SelectedIndex = (int)(SpecializationStatus)student.SpecializationId;
            facNumberBox.Text = student.FacNumber;
            streamBox.Text = student.Stream.ToString();
            groupBox.Text = student.Group.ToString();
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
            user.Username = username;
            user.Password = password;

            if (validation.ValidateUserInput(ref user))
            {
                // Student role
                if (user.RoleId == 4)
                {
                    ChangeAccessToAllBoxes(true);
                    GetStudentInfoByFacNumber(user.FacNumber);
                    loginBtn.IsEnabled = false;
                    logoutBtn.IsEnabled = true;

                    this.student = GetStudentInfoByFacNumber(user.FacNumber);
                    this.DataContext = this.student;
                }

                // Professor role
                else if (user.RoleId == 1)
                {
                    ChangeAccessToAllBoxes(true);
                    clearAllTextBoxes();
                    addMarkBtn.Visibility = Visibility.Visible;
                    btnGetStudentInfo.Visibility = Visibility.Visible;
                    loginBtn.IsEnabled = false;
                    logoutBtn.IsEnabled = true;
                    NavigationWindow profWindow = new NavigationWindow();
                    profWindow.Content = new ProfessorPage();
                    profWindow.Show();
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
                this.user.RoleId = (int)UserRoles.ANONYMOUS;

                loginBtn.IsEnabled = true;
                logoutBtn.IsEnabled = false;
                
                clearAllTextBoxes();
                ChangeAccessToAllBoxes(false);

                addMarkBtn.Visibility = Visibility.Hidden;
                btnGetStudentInfo.Visibility = Visibility.Hidden;
            }
        }

        private void ChangeAccessToAllBoxes(bool option)
        {
            // Clear personal info
            firstNameBox.IsEnabled = option;
            secondNameBox.IsEnabled = option;
            lastNameBox.IsEnabled = option;

            // Clear student info
            educationDegreeBox.IsEnabled = option;
            degreeStatusBox.IsEnabled = option;
            courseBox.IsEnabled = option;
            facilityBox.IsEnabled = option;
            specializationBox.IsEnabled = option;
            facNumberBox.IsEnabled = option;
            streamBox.IsEnabled = option;
            groupBox.IsEnabled = option;
        }
    }
}
