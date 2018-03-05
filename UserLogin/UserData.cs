using System;

namespace UserLogin
{
    static class UserData
    {
        public static User[] TestUsers
        {
            get
            {
                ResetTestUserData();
                return _testUsers;
            }

            set { }
        }

        private static User[] _testUsers;

        private static void ResetTestUserData()
        {
            string username = "Dobromir";
            string password = "qwerty";
            string facNumber = "121215019";

            // Create new user
            _testUsers = new User[3];
            for (int i = 0; i < _testUsers.Length; i++)
            {
                _testUsers[i] = new User();

                _testUsers[i].username = username + i;
                _testUsers[i].password = password + i;
                _testUsers[i].facNumber = facNumber + i;

                // set 1 Administrator
                if (i == 0)
                {
                    _testUsers[i].roleId = 1;
                }
                // set 2 Students
                else
                {
                    _testUsers[i].roleId = 4;
                }
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
    }
}
