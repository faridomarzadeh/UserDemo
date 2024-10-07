using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using UserDemo.Models;

namespace UserDemo.Pages.Validators
{
    public  static class RegisterUserValidator
    {
        public static bool IsImage(HttpPostedFile file)
        {
            if (file == null)
                return false;

            if (file.ContentLength > 0 && file.ContentType.Contains("image"))
            {
                return true;
            }
            return false;
        }

        public static bool IsValidImage(HttpPostedFile file)
        {
            if(file !=null && file.FileName != string.Empty)
            {
                return true;
            }
            return false;
        }

        public static bool IsUserValid(User user)
        {
            if (user == null) return false;
            if(string.IsNullOrEmpty(user.FirstName)) return false;
            if(string.IsNullOrEmpty(user.LastName)) return false;
            if(string.IsNullOrEmpty(user.Email)) return false;
            if(string.IsNullOrEmpty(user.Password)) return false;
            return true;
        }
    }
}