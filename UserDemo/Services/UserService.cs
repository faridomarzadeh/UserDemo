using Microsoft.Practices.Unity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using UserDemo.App_Data;
using UserDemo.Models;
using UserDemo.Models.DTO;

namespace UserDemo.Services
{
    public class UserService : IUserService
    {
        private readonly UserContext _userContext;
        public UserService(UserContext userContext)
        {
            _userContext = userContext;
        }

        public List<UserReportDto> GetUserReports(int page = 1, int numberofrows = 5)
        {
            return _userContext.GetUserReports(page, numberofrows);
        }

        public int GetUserCount()
        {
            return _userContext.Users.Count();
        }

        public User Login(string email, string password)
        {
            var user = _userContext.Users.FirstOrDefault(x => x.Email == email
            && x.Password==password);
            if (user!=null)
            {
                _userContext.LoginReports.Add(new LoginReport()
                {
                    LoginDate = DateTime.Now,
                    User = user,
                    UserId = user.Id,
                });
            }
            _userContext.SaveChanges();
            return user;
        }

        public bool RegisterUser(User user)
        {
            var role = _userContext.Roles.FirstOrDefault(x => x.RoleName == "User");
            return SaveUser(user, role);
        }

        public bool RegisterManager(User user)
        {
            var role = _userContext.Roles.FirstOrDefault(x => x.RoleName == "Manager");
            return SaveUser(user, role);
        }

        public bool RegisterAdmin(User user)
        {
            var role = _userContext.Roles.FirstOrDefault(x => x.RoleName == "Admin");
            return SaveUser(user, role);
        }
        private bool SaveUser(User user, Role role)
        {
            var userExists = _userContext.Users.FirstOrDefault(x => x.Email==user.Email);
            if (userExists!=null)
            {
                return false;
            }
            user.Role = role;
            user.RoleId = role.Id;
            user.RegistrationDate = DateTime.Now;
            _userContext.Users.Add(user);
            _userContext.SaveChanges();
            return true;
        }

    }
}