using System;

namespace UserLogin
{
    class Program
    {
        static void Main()
        {
            Console.Write("Enter Username: ");
            string username = Console.ReadLine();

            Console.Write("Enter password: ");
            string password = Console.ReadLine();

            LoginValidation validator = new LoginValidation(username, password);

            User user = new User();
            user.username = username;
            user.password = password;

            if (validator.ValidateUserInput(ref user))
            {
                Console.WriteLine("Data for user: Username - {0}, Password - {1}, Fac. Number: {2}, role: {3}",
                    user.username, user.password, user.facNumber, LoginValidation.currentUserRoles);
            }
            else
            {
                Console.WriteLine("ERROR: {0}", validator.errorException);
                Console.WriteLine("User role: {0}", LoginValidation.currentUserRoles);
            }
        }
    }
}
