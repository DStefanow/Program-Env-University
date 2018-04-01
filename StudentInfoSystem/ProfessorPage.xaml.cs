using System;
using System.Collections.Generic;
using System.Windows.Controls;
using StudentRepository;

namespace StudentInfoSystem
{
    /// <summary>
    /// Interaction logic for ProfessorPage.xaml
    /// </summary>
    public partial class ProfessorPage : Page
    {
        public ProfessorPage()
        {
            InitializeComponent();

            addAllStudents();
        }

        public void addAllStudents()
        {
            StudentData.AddSomeStudents();
            List<Student> students = StudentData.DefaultStudents;

            foreach (Student student in students)
            {
                string fullName = student.firstName + " " + student.secondName + " " + student.lastName;

                this.studentsList.Items.Add(fullName);
            }
        }

        public void clearListBox()
        {
            this.studentsList.Items.Clear();
        }

        private void getStudent_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            string facNumber = this.studentFacNumber.Text;
            
            clearListBox();

            if (facNumber == "")
            {
                addAllStudents();
                return;
            }

            Student student = null;
                student = StudentData.GetStudent(facNumber);
           

            string fullName = student.firstName + " " + student.secondName + " " + student.lastName;

            this.studentsList.Items.Add(fullName);
        }
    }
}
