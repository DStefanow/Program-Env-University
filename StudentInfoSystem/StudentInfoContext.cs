using StudentRepository;
using System.Data.Entity;
using UserLogin;

namespace StudentInfoSystem
{
    public class StudentInfoContext : DbContext
    {
        public DbSet<Student> Students { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Specialization> Specializations { get; set; }
        public DbSet<Subject> Subjects { get; set; }
        //public DbSet<SpecializationSubject> SpecializationToSubject { get; set; }
        
        public StudentInfoContext() : base(Properties.Settings.Default.DbConnection){ }
        
    }
}
