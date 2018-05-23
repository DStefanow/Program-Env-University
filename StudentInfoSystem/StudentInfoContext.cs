using StudentRepository;
using System.Data.Entity;
using UserLogin;

namespace StudentInfoSystem
{
    public class StudentInfoContext : DbContext
    {
        public DbSet<Student> Students { get; set; }
        public DbSet<User> Users { get; set; }

        public StudentInfoContext() : base(StudentRepository.Properties.Settings.Default.DbConnect){ }
    }
}
