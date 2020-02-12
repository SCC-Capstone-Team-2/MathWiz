using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MathWiz.Models
{
    public class Student : User
    {
        public int studentID { get; set; }
        public string studentName { get; set; }
        public int studentLevel { get; set; }
    }
}