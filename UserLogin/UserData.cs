using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace UserLogin
{
    public static class UserData
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
                
                currentUser.Username = username + i;
                currentUser.Password = password + i;
                currentUser.FacNumber = facNumber + i;
                currentUser.Created = DateTime.Now;
                // set 1 Administrator
                if (i == 0)
                {
                    currentUser.RoleId = 1;
                }
                // set 2 Students
                else
                {
                    currentUser.RoleId = 4;
                }

                _testUsers.Add(currentUser);
            }
        }

        public static Dictionary<string, int> AllUsersUsernames()
        {
            Dictionary<string, int> usernames = new Dictionary<string, int>();

            for (int i = 0; i < TestUsers.Count; i++)
            {
                usernames.Add(TestUsers[i].Username, i);
            }

            return usernames;
        }

        public static User IsUserPassCorrect(User user)
        {
            // Het the user with the same username and password
            User searchedUser = (from users in TestUsers
                                  where (users.Username.Equals(user.Username) && 
                                  users.Password.Equals(user.Password))
                                  select users).FirstOrDefault();
            
            if (searchedUser != null)
            {
                return searchedUser;
            }
            
            return null;
        }

        public static void SetUserActiveTo(int userId, DateTime newDateRegister)
        {
            TestUsers[userId].Created = newDateRegister;
            Logger.LogActivity((Activities)1, "Change date to: " + TestUsers[userId].Username + " new date: " + newDateRegister);
        }

        public static void AssignUserRole(int userId, ushort newRoleId)
        {
            if (Enum.IsDefined(typeof(UserRoles), (int)newRoleId))
            {
                TestUsers[userId].RoleId = newRoleId;
                Logger.LogActivity((Activities)2, "Change role to: " + TestUsers[userId].Username + " new role: " + (UserRoles)newRoleId);
                return;
            }

            throw new Exception("Invalid user role id!!");    
        }

        public static void ShowUserActivity()
        {
            string filePath = @"..\..\..\activity.txt";
            StreamReader sr = new StreamReader(filePath);
            
            int lineCount = 1;
            while (!sr.EndOfStream)
            {
                string line = lineCount + "| " + sr.ReadLine();
                Console.WriteLine(line);

                lineCount++;
            }
        }
    }
}
