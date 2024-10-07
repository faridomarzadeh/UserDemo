using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace UserDemo
{
    public class SharedResources
    {
        public static class Session
        {
            public const string FULL_NAME = "Full Name";
            public const string USER_ID = "UserId";
            public const string ROLE_ID = "RoleId";
            public const string LOGIN_DATE = "LoginDate";
        }

        public static class Messages
        {
            public const string FAILED_LOGIN = "Email or Password does not match";
            public const string REQUIRED = "Please enter required fields";
            public const string SUCCESSFUL = "Successfully Registered User";
            public const string INVALID_INPUT = "Invalid Input, Please enter correct information";
            public const string USER_EXISTS = "This User is already registered";
        }

        public static class URLs
        {
            public const string HOME = "/";
            public const string LOGIN = "/Login";
        }
    }
}