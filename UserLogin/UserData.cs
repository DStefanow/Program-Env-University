using System;
using System.Collections.Generic;

namespace UserLogin
{
    static class UserData
    {
        public static List<User> TestUsers
        {
            get
            {
                ResetTestUserData();
                return _testUsers;
            }

            set { }
        }

        private static List<User> _testUsers = new List<User>(3);

        private static void ResetTestUserData()
        {
            string username = "Dobromir";
            string password = "qwerty";
            string facNumber = "121215019";

            // Create new user
            for (int i = 0; i < _testUsers.Capacity; i++)
            {
                User currentUser = new User();

                currentUser.username = username + i;
                currentUser.password = password + i;
                currentUser.facNumber = facNumber + i;
                currentUser.created = DateTime.Now;
                // set 1 Administrator
                if (i == 0)
                {
                    currentUser.roleId = 1;
                }
                // set 2 Students
                else
                {
                    currentUser.roleId = 4;
                }

                _testUsers.Add(currentUser);
            }
        }

        public static User IsUserPassCorrect(User user)
        {
            foreach (User givenUser in TestUsers)
            {
                if (user.username == givenUser.username && user.password == givenUser.password)
                {
                    return givenUser;
                }
            }

            return null;
        }

        public static void SetUserActiveTo(string username, DateTime newDateRegister)
        {

            foreach (User givenUser in TestUsers)
            {
                if (givenUser.username.Equals(username))
                {
                    givenUser.created = newDateRegister;
                    Logger.LogActivity("Change date to: " + username + "new date: " + newDateRegister);
                    return;
                }
            }

            throw new Exception("There is no User with that username in the base!");
        }

        public static void AssignUserRole(string username, ushort newRole)
        {
            foreach (User givenUser in TestUsers)
            {
                if (givenUser.username.Equals(username))
                {
                    givenUser.roleId = newRole;
                    Logger.LogActivity("Change role to: " + username + "new role: " + newRole);
                    return;
                }
            }

            throw new Exception("There is no User with that username in the base!");
        }
    }
}
