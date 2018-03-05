﻿using System;

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

            Console.WriteLine("\r\nHello Admin\r\nChoose a option:\r\n1. Change user role.\r\n2.Change user date.");
            Console.Write("\r\nOption: ");
            option = UInt16.Parse(Console.ReadLine());

            switch (option)
            {
                case 1: ChangeUserRole(); break;
                case 2: ChangeUserDate(); break;
                default: Console.WriteLine("No such option in the menu"); break;
            }
        }

        private static void ChangeUserDate()
        {
            string username;
            DateTime newDate;
            Console.Write("Enter username: ");
            username = Console.ReadLine();

            Console.Write("Enter new date: ");
            DateTime.TryParse(Console.ReadLine(), out newDate);

            try
            {
                UserData.SetUserActiveTo(username, newDate);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
            }
        }

        private static void ChangeUserRole()
        {
            string username;
            ushort newRole;
            Console.Write("Enter username: ");
            username = Console.ReadLine();

            Console.Write("Enter new role id: ");
            newRole = Convert.ToUInt16(Console.ReadLine());

            try
            {
                UserData.AssignUserRole(username, newRole);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
            }
        }

        public static void ValidationErrorHandler(string errorMsg)
        {
            Console.WriteLine("Error during registration: {0}", errorMsg);
        }
    }
}
