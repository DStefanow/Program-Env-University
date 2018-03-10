using System;
using System.Collections.Generic;
using System.Globalization;

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
                Console.WriteLine("Data for user: Username - {0}, Password - {1}, Fac. Number: {2}, date register: {3}, role: {4}",
                    user.username, user.password, user.facNumber, user.created, LoginValidation.currentUserRole);

                if (LoginValidation.currentUserRole.ToString() == "ADMIN")
                {
                    AdminOptions();
                }
            }
            else
            {
                Console.WriteLine("User role: {0}", LoginValidation.currentUserRole);
            }
        }

        private static void AdminOptions()
        {
            ushort option;

            Console.WriteLine("\r\nHello Admin\r\nChoose a option:" +
                "\r\n1. Show all usernames.\r\n2. Change user date." +
                "\r\n3. Change user role." +
                "\r\n4. Show users activity(no filter)." +
                "\r\n5. Show users activity(with filter - contains ).");
            Console.Write("\r\nOption: ");
            option = UInt16.Parse(Console.ReadLine());

            Dictionary<string, int> allUsers = UserData.AllUsersUsernames();

            switch (option)
            {
                case 1: ShowAllUsernames(); break;
                case 2: ChangeUserDate(ref allUsers); break;
                case 3: ChangeUserRole(ref allUsers); break;
                case 4: UserData.ShowUserActivity(); break;
                case 5: GetUserActivitiesWithFilter(); break;
                default: Console.WriteLine("No such option in the menu"); break;
            }
        }

        private static void ShowAllUsernames()
        {
            Dictionary<string, int> usernames = UserData.AllUsersUsernames();

            foreach (KeyValuePair<string, int> username in usernames)
            {
                Console.WriteLine("Username: {0} with id: {1}", username.Key, username.Value);
            }
        }

        private static void ChangeUserDate(ref Dictionary<string, int> allUsers)
        {
            string username;
            DateTime newDate;
            Console.Write("Enter username: ");
            username = Console.ReadLine();

            Console.Write("Enter new date(dd-MM-yyyy): ");
            
            try
            {
                newDate = DateTime.ParseExact(Console.ReadLine(), "dd-MM-yyyy", CultureInfo.InvariantCulture);
                UserData.SetUserActiveTo(allUsers[username], newDate);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
            }
        }

        private static void ChangeUserRole(ref Dictionary<string, int> allUsers)
        {
            string username;
            ushort newRole;
            Console.Write("Enter username: ");
            username = Console.ReadLine();

            Console.Write("Enter new role id: ");
            newRole = Convert.ToUInt16(Console.ReadLine());

            try
            {
                UserData.AssignUserRole(allUsers[username], newRole);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
            }
        }

        private static void GetUserActivitiesWithFilter()
        {
            Console.Write("Enter filter word: ");
            string filter = Console.ReadLine();

            Logger.GetCurrentSessionActivies(filter);
        }

        public static void ValidationErrorHandler(string errorMsg)
        {
            Console.WriteLine("Error during registration: {0}", errorMsg);
        }
    }
}
