using System.Data.Entity;

namespace UserLogin
{
    public class UserContext : DbContext
    {
        public DbSet<User> Users { get; set; }

        public UserContext() : base(UserLogin.Properties.Settings.Default.DbConnection) { }
    }
}
