using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace UserDemo.Models
{
    public class UserManagerRelation
    {
        public int UserId { get; set; }
        public User User { get; set; }
        public int ManagerId {  get; set; }
        public User Manager { get; set; }
    }
}