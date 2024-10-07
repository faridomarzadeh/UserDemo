using System;
using System.Collections.Generic;
using System.Configuration;
using System.Drawing;
using System.Linq;
using System.Web;
using UserDemo.App_Data;
using UserDemo.Models;

namespace UserDemo.Migrations
{
    public static class DbInitializer
    {
        private static Random random = new Random();
        public static void Initialize(UserContext context)
        {
            if(!context.Roles.Any())
            {
                context.Roles.Add(new Role()
                {
                    RoleName = "Admin"
                });
                context.Roles.Add(new Role()
                {
                    RoleName = "Manager"
                });
                context.Roles.Add(new Role()
                {
                    RoleName = "User"
                });
                context.SaveChanges();


            }
            if (!context.Users.Any())
            {
                var managerRole = context.Roles.FirstOrDefault(i=>i.RoleName=="Manager");
                var userRole = context.Roles.FirstOrDefault(i=>i.RoleName=="User");
                var adminRole = context.Roles.FirstOrDefault(i => i.RoleName == "Admin");
                var john = new User
                {
                    FirstName = "John",
                    LastName = "Smith",
                    RoleId = userRole.Id,
                    Password = "12345678",
                    Email = "john@smith.com",
                    RegistrationDate = GetRandomDate(),
                };
                context.Users.Add(john);

                var leslie = new User
                {
                    FirstName = "Leslie",
                    LastName = "Peterson",
                    RoleId = adminRole.Id,
                    Password = "123456789",
                    Email = "leslie@peterson.com",
                    RegistrationDate = GetRandomDate(),
                };
                context.Users.Add(leslie);

                context.Users.Add(new User()
                {
                    FirstName = "Jessica",
                    LastName = "Johnson",
                    RoleId = managerRole.Id,
                    Password = "12345678AB",
                    Email = "jessica@johnson.com",
                    RegistrationDate = GetRandomDate(),
                });

                for (int i = 0; i< 10; i++)
                {
                    context.Users.Add(new User()
                    {
                        FirstName = "User" + i,
                        LastName = "LastName" + i,
                        RoleId = userRole.Id,
                        RegistrationDate = GetRandomDate(),
                        Email = "User" + i + "@gmail.com",
                        Password = "1234"
                    });
                }
                context.SaveChanges();


            }

            if (!context.UserManagers.Any())
            {
                var john = context.Users.FirstOrDefault(i => i.FirstName=="John" && i.LastName== "Smith");
                var jessica = context.Users.FirstOrDefault(i => i.FirstName == "Jessica" && i.LastName == "Johnson");
                context.UserManagers.Add(new UserManagerRelation()
                {
                    Manager = jessica,
                    User = john,
                    ManagerId = jessica.Id,
                    UserId = john.Id
                });
                context.SaveChanges();


            }

            if (!context.LoginReports.Any()) 
            {
                var users = context.Users.ToList();
                for (int i = 0; i < 53; i++)
                {
                    var randomUser = users[random.Next(users.Count)];
                    context.LoginReports.Add(new LoginReport()
                    {
                        LoginDate = GetRandomDate(),
                        UserId = randomUser.Id,
                        User = randomUser
                    });
                }
                context.SaveChanges();

            }


        }
        private static DateTime GetRandomDate()
        {
            var start = new DateTime(2024, 1, 1);
            int range = (DateTime.Today - start).Days;
            return start.AddDays(random.Next(range)).AddHours(random.Next(0, 24)).AddMinutes(random.Next(0, 60)).AddSeconds(random.Next(0, 60));
        }
    }
}