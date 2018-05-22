using System;

namespace StudentRepository
{
    public class Student
    {
        public int StudentId { get; set; }
        public string FirstName { get; set; }
        public string SecondName { get; set; }
        public string LastName { get; set; }

        public string Facility { get; set; }
        public SpecializationStatus Specialization { get; set; }
        public EducationDegree EducationDegree { get; set; }
        public DegreeStatus Status { get; set; }
        public string FacNumber { get; set; }
        public DateTime LastCheck { get; set; }

        public ushort Course { get; set; }
        public ushort Stream { get; set; }
        public char Group { get; set; }
    }
}
