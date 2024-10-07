using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace UserDemo.Models
{
    public class LoginReport
    {
        public int Id { get; set; }
        public DateTime LoginDate { get; set; }

        //navigation properties
        public int UserId {  get; set; }
        public User User { get; set; }
    }
}