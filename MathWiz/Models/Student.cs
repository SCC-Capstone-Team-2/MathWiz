using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MathWiz.Models
{
    public class Student : User
    {
        public int StudentID { get; set; }
        public string StudentFirst { get; set; }
        public string StudentLast { get; set; }
        public int studentLevel { get; set; }
    }
}