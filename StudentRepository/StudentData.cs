using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;

namespace StudentRepository
{
    public class StudentData
    {
        private static int STUDENT_COUNTS = 5;

        public static List<Student> DefaultStudents = new List<Student>();
        
        public static void AddSomeStudents()
        {
            // Default students are already added
            if (DefaultStudents.Count != 0)
            {
                return;
            }

            string firstName = "Dobromir";
            string secondName = "Stefanov";
            string lastName = "Milenov";
            string[] facility = { "FKST", "MT", "FTT", "Auto", "Engineering" };
            string facNumber = "121215019";
            DateTime lastCheck = DateTime.Now;
            
            for (int i = 0; i < StudentData.STUDENT_COUNTS; i++)
            {
                Student student = new Student();
                student.FirstName = firstName + (char)(97 + i);
                student.SecondName = secondName + (char)(97 + i);
                student.LastName = lastName + (char)(97 + i);
                student.Facility = facility[i];
                student.SpecializationId = i % StudentData.STUDENT_COUNTS;
                student.EducationDegree = (EducationDegree)(i % StudentData.STUDENT_COUNTS);
                student.Status = (DegreeStatus)(i % StudentData.STUDENT_COUNTS);
                student.FacNumber = facNumber + i;
                student.LastCheck = lastCheck.AddDays(i);
                student.Course = (ushort)(i + 1);
                student.Stream = (ushort)(i + 1);
                student.Group = (char)(i + 65);

                StudentData.DefaultStudents.Add(student);
            }
        }

        public static Student GetStudent(string facNumber)
        {
            Student student = null;
            try
            {
                // Get the student that has this fac. number
                student = (from students in StudentData.DefaultStudents
                                   where students.FacNumber.Equals(facNumber)
                                   select students).Last();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }

            if (student != null)
            {
                return student;
            }

            throw new Exception("No such student with that facility number");
        }

        public static string PrepareSertificate(Student student)
        {
            string fullName = student.FirstName + " " + student.SecondName + " " + student.LastName;

            string certificate = $"The student: {fullName}, with fac.number: {student.FacNumber} is checked in {student.SpecializationId}," +
                $" education degree: {student.EducationDegree}" +
                $" status:{student.Status}, course: {student.Course}, stream: {student.Stream}" +
                $" in group: {student.Group}. Date check: {student.LastCheck}";

            return certificate;
        }

        public static void SaveCertificate(string facNumber)
        {
            Student student = new Student();
            try
            {
                student = GetStudent(facNumber);
            }
            catch (Exception e)
            {
                Console.WriteLine("Exception: {0}", e.Message);
                return;
            }

            string certificateText = PrepareSertificate(student);
            
            string certificatePath = Directory.GetParent(Directory.GetCurrentDirectory()).Parent.FullName + 
                    @"\tmp\" + student.FirstName + "-" + student.FacNumber + ".txt";

            StreamWriter sw = File.CreateText(certificatePath);

            if (File.Exists(certificatePath))
            {
                sw.Write(certificateText);
                sw.Close();
                Console.WriteLine(certificateText);
            }
            else
            {
                throw new Exception("No such file: " + certificatePath);
            }
        }
    }
}
