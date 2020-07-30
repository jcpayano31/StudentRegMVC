using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace StudentRegMVC.Models
{
    public class LoginRequest
    {
        
        public int LogingID { get; set; } 
        public String Name { get; set; }
        public String EmailAdress { get; set; }
        public String LoginName { get; set; }
        public String NewOrReactivaterd { get; set; }
        public String ReasonForAccess { get; set; }
        public DateTime DateRequiedBy { get; set; }
    }
}