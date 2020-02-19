using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MathWiz.Models
{
    public class Problem
    {
        public string Answer { get; set; }
        public string Question { get; set; }
        public int Type { get; set; }
        public bool Correct { get; set; }
        public bool Graded { get; set; }

        public Problem(string question, string answer, int type)
        {
            this.Question = question;
            this.Answer = answer;
            this.Type = type;
            this.Graded = false;
        }

        public void Grade(string userAnswer)
        {
            if (this.Answer.CompareTo(userAnswer) == 0)
            {
                this.Correct = true;
            }
            else
            {
                this.Correct = false;
            }
            this.Graded = true;
        }
    }
}