using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MathWiz.Models
{
    public class Assignment
    {
        public List<Problem> Problems { get; set; }
        public string ID { get; set; }
        public string Name { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }
        public DateTime? DueBy { get; set; }
        public int Type { get; set; }

        public Assignment() { }

        public Assignment(string name, int type = 1, DateTime? dueBy = null)
        {
            this.Name = name;
            this.Type = type;
            this.DueBy = dueBy;
            // Database.AddAssignment(name,type,dueBy);
        }

        public decimal Grade()
        {
            int problemCount = this.Problems.Count();
            int correctProblems = 0;
            decimal percentage = 0.00m;
            foreach (Problem problem in this.Problems)
            {
                if (problem.Correct)
                {
                    correctProblems++;
                }
            }
            percentage = ((decimal)correctProblems / (decimal)problemCount);
            return percentage;
        }
    }
}