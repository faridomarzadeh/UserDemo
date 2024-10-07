using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace UserDemo.Models.DTO
{
    public class UserReportDto
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime RegistrationDate { get; set; }
        public DateTime LastLogin { get; set;}
        public int TotalLogins { get; set; }
    }
}