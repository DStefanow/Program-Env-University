using System;

namespace StudentRepository
{
    public class Student
    {
        public string firstName { get; set; }
        public string secondName { get; set; }
        public string lastName { get; set; }

        public string facility { get; set; }
        public SpecializationStatus specialization { get; set; }
        public EducationDegree educationDegree { get; set; }
        public DegreeStatus status { get; set; }
        public string facNumber { get; set; }
        public DateTime lastCheck { get; set; }

        public ushort course { get; set; }
        public ushort stream { get; set; }
        public char group { get; set; }
    }
}
