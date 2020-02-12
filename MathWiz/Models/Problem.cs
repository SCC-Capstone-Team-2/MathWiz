using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MathWiz.Models
{
    public class Problem
    {
        public double product { get; set; }
        public double firstNumber { get; set; }
        public double secondNumber { get; set; }
        public bool correct { get; set; }
    }
}