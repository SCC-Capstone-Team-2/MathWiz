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

        public double AddNumbers(double number1, double number2)
        {
            double result = number1 + number2;
            return result;
        }
  
        public double SubtractNumbers(double number1, double number2)
        {
            double result = number1 - number2;
            return result;
        }

        public double MultiplyNumbers(double number1, double number2)
        {
            double result = number1 * number2;
            return result;
        }

        public double DivideNumbers(double number1, double number2)
        {
            double result = number1 / number2;
            return result;
        }
    }
}