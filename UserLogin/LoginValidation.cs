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

        public static UserRoles currentUserRole
        {
            get; private set;
        }

        public static string currentUserUsername
        {
            get; private set;
        }

        // Delegate example
        public delegate void ActionOnError(string errorMsg);

        private ActionOnError error;

        public LoginValidation(string username, string password, ActionOnError error)
        {
            this.username = username;
            this.password = password;
            this.error = error;
        }

        public bool ValidateUserInput(ref User user)
        {
            currentUserRole = (UserRoles)user.roleId;

            bool isEmptyUsername = this.username.Equals(String.Empty);
            if (isEmptyUsername || this.username.Length < 5)
            {
                this.error("The username must be at least 5 symbols long");
                currentUserRole = UserRoles.ANONYMOUS;
                return false;
            }

            bool isEmptyPassword = this.password.Equals(String.Empty);
            if (isEmptyPassword || this.password.Length < 5)
            {
                this.error( "The password must be at least 5 symbols long");
                currentUserRole = UserRoles.ANONYMOUS;
                return false;
            }

            user = UserData.IsUserPassCorrect(user);

            if (user == null)
            {
                this.error("The username and the password are different");
                currentUserRole = UserRoles.ANONYMOUS;
                return false;
            }

            currentUserRole = (UserRoles)user.roleId;
            LoginValidation.currentUserUsername = user.username;

            // Set activity in the Logger
            Logger.LogActivity((Activities)0, "logged");

            return true;
        }
    }
}
