using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace StudentRepository
{
    class StudentData
    {
        private static int STUDENT_COUNTS = 5;

        public static List<Student> DefaultStudents = new List<Student>();


        public static void AddSomeStudents()
        {
            string firstName = "Dobromir";
            string secondName = "Stefanov";
            string lastName = "Milenov";
            string[] facility = { "FKST", "MT", "FTT", "Auto", "Engineering" };
            string[] specialization = { "Programmer", "Engineer", "Auto-master", "Sys admin", "Doctor"};
            string facNumber = "121215019";
            DateTime lastCheck = DateTime.Now;
            
            for (int i = 0; i < StudentData.STUDENT_COUNTS; i++)
            {
                Student student = new Student();
                student.firstName = firstName + (char)(97 + i);
                student.secondName = firstName + (char)(97 + i);
                student.lastName = lastName + (char)(97 + i);
                student.facility = facility[i];
                student.specialization = specialization[i];
                student.educationDegree = (EducationDegree)(i % StudentData.STUDENT_COUNTS);
                student.status = (DegreeStatus)(i % StudentData.STUDENT_COUNTS);
                student.facNumber = facNumber + i;
                student.lastCheck = lastCheck.AddDays(i);
                student.course = (ushort)i;
                student.stream = (ushort)i;
                student.group = (char)(i + 65);

                StudentData.DefaultStudents.Add(student);
            }
        }

        public static Student GetStudent(string facNumber)
        {
            Student student = StudentData.DefaultStudents.Find(s => s.facNumber == facNumber);

            if (student != null)
            {
                return student;
            }

            throw new Exception("No such student with that facility number");
        }

        public static string PrepareSertificate(Student student)
        {
            string fullName = student.firstName + " " + student.secondName + " " + student.lastName;

            string certificate = $"The student: {fullName}, with fac.number: {student.facNumber} is checked in {student.specialization}," +
                $" education degree: {student.educationDegree}" +
                $" status:{student.status}, course: {student.course}, stream: {student.stream}" +
                $" in group: {student.group}. Date check: {student.lastCheck}";

            return certificate;
        }

        public static void SaveCertificate(string facNumber)
        {
            Student student = GetStudent(facNumber);

            string certificateText = PrepareSertificate(student);

            string certificatePath = @"C:\Users\mopak\source\repos\UserLogin\Program-Env-University\StudentRepository\" +
                    student.firstName + "-" + student.facNumber + ".txt";

            StreamWriter sw = File.CreateText(certificatePath);

            if (File.Exists(certificatePath))
            {
                sw.Write(certificateText);
                sw.Close();
            }
            else
            {
                throw new Exception("No such file: " + certificatePath);
            }

        }
    }
}
