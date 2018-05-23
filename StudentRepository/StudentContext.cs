using System.Data.Entity;
using UserLogin;

namespace StudentRepository
{
    public class StudentContext : DbContext
    {
        public DbSet<Student> Students { get; set; }
        public DbSet<User> Users { get; set; }

        public StudentContext() : base(Properties.Settings.Default.DbConnection) { }
    }
}
