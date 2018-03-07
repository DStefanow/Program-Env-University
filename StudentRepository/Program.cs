using System;

namespace StudentRepository
{
    class Program
    {
        static void Main(string[] args)
        {  
            Console.Write("Enter fac number: ");
            string facNumber = Console.ReadLine();

            StudentData.AddSomeStudents();
            StudentData.SaveCertificate(facNumber);
        }
    }
}
