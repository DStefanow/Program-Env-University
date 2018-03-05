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

            LoginValidation validator = new LoginValidation(username, password, ValidationErrorHandler);

            User user = new User();
            user.username = username;
            user.password = password;

            if (validator.ValidateUserInput(ref user))
            {
                Console.WriteLine("Data for user: Username - {0}, Password - {1}, Fac. Number: {2}, role: {3}",
                    user.username, user.password, user.facNumber, LoginValidation.currentUserRole);
            }
            else
            {
                Console.WriteLine("User role: {0}", LoginValidation.currentUserRole);
            }
        }

        public static void ValidationErrorHandler(string errorMsg)
        {
            Console.WriteLine("Error during registration: {0}", errorMsg);
        }
    }
}
