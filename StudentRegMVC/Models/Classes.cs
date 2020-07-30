using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace StudentRegMVC.Models
{
    public class Classes
    {
        public int ClassId { get; set; }
        public String ClassName { get; set; }
        public DateTime ClassDate { get; set; }
        public String ClassDescription { get; set; }
    }
}