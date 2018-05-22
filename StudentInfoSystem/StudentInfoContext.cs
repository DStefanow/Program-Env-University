using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.SqlClient;
using System.Linq;

namespace StudentInfoSystem
{
    class StudentInfoContext : DbContext
    {
        public DbSet<StudentInternships> Internships { get; set; }

        public StudentInfoContext() : base("StudentInfo")
        {
            Properties.Settings.Default.DbSettings =
                "Data Source=(local);Initial Catalog=StudentInfo;Integrated Security=SSPI";

            SqlConnection conn = new SqlConnection(Properties.Settings.Default.DbSettings);
           
            conn.Open();

        }


        public IQueryable<StudentInternships> getAllStudents()
        {
            return Set<StudentInternships>();
        }
    }
}
