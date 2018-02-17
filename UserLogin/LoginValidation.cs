using System;

namespace UserLogin
{
    class LoginValidation
    {
        private string username;
        private string password;
        public string errorException
        {
            get; private set;
        }

        public static UserRoles currentUserRoles
        {
            get; private set;
        }

        public LoginValidation(string username, string password)
        {
            this.username = username;
            this.password = password;
        }

        public bool ValidateUserInput(ref User user)
        {
            currentUserRoles = (UserRoles)user.roleId;

            bool isEmptyUsername = this.username.Equals(String.Empty);
            if (isEmptyUsername || this.username.Length < 5)
            {
                this.errorException = "The username must be at least 5 symbols long";
                currentUserRoles = UserRoles.ANONYMOUS;
                return false;
            }

            bool isEmptyPassword = this.password.Equals(String.Empty);
            if (isEmptyPassword || this.password.Length < 5)
            {
                this.errorException = "The password must be at least 5 symbols long";
                currentUserRoles = UserRoles.ANONYMOUS;
                return false;
            }

            user = UserData.IsUserPassCorrect(user);

            if (user == null)
            {
                this.errorException = "The username and the password are different";
                currentUserRoles = UserRoles.ANONYMOUS;
                return false;
            }

            currentUserRoles = (UserRoles)user.roleId;
            return true;
        }
    }
}
