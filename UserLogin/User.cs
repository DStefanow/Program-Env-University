using System;

namespace UserLogin
{
    public class User
    {
        public int UserId { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public string FacNumber { get; set; }
        public int RoleId { get; set; }
        public DateTime Created { get; set; }
        public DateTime? ActiveTo { get; set; }
    }
}
