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

        private static List<User> _testUsers;

        private static void ResetTestUserData()
        {
            _testUsers = new List<User>();

            string username = "Dobromir";
            string password = "qwerty";
            string facNumber = "121215019";

            // Create new user
            for (int i = 0; i < 4; i++)
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

        public static Dictionary<string, int> AllUsersUsernames()
        {
            Dictionary<string, int> usernames = new Dictionary<string, int>();

            for (int i = 0; i < TestUsers.Count; i++)
            {
                usernames.Add(TestUsers[i].username, i);
            }

            return usernames;
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

        public static void SetUserActiveTo(int userId, DateTime newDateRegister)
        {
            TestUsers[userId].created = newDateRegister;
            Logger.LogActivity("Change date to: " + TestUsers[userId].username + " new date: " + newDateRegister);
        }

        public static void AssignUserRole(int userId, ushort newRole)
        {
            TestUsers[userId].roleId = newRole;
            Logger.LogActivity("Change role to: " + TestUsers[userId].username + " new role: " + newRole);
        }
    }
}
