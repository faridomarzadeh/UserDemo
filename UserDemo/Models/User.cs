using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace UserDemo.Models
{
    public class User
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string ProfilePicture {  get; set; }
        public DateTime RegistrationDate {  get; set; }

        //navigation properties
        public int RoleId {  get; set; }
        public Role Role { get; set; }

        public List<UserManagerRelation> Managers { get; set; }
        public List<UserManagerRelation> Users {  get; set; }
        public List<LoginReport> LoginReports { get; set; }
    }
}