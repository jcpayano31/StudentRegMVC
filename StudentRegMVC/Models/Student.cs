using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace StudentRegMVC.Models
{
    public class Student
    {
        
        public int StudentID { get; set; }
        public String StudentName { get; set; }
        public String StudentEmail { get; set; }
        public String StudentLogin { get; set; }

        public String StudentPassword { get; set; }
    }
}