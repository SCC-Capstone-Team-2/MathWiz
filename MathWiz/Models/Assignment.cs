using MathWiz.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MathWiz.Models
{
    public class Assignment
    {
        public List<Problem> Problems { get; set; }
        public int ID { get; set; }
        public string Name { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }
        public DateTime? DueBy { get; set; }
        public int? Type { get; set; }
        public Boolean Graded { get; set; }
        public decimal Percentage { get; set; }

        public Assignment() { }

        // This constructor is used for pulling an assignment from a database
        public Assignment(int id, string name, int type, DateTime? dueBy)
        {
            this.Name = name;
            this.Type = type;
            this.DueBy = dueBy;
        }


        // This constructor is used for creating a new assignment
        public Assignment(string name, int? id=null, int type = 1, int? problemCount=50, DateTime? dueBy = null)
        {
            this.Name = name;
            this.Type = type;
            this.DueBy = dueBy;
            this.ID = AssignmentEndpoint.AddAssignment(this);
            this.GenerateProblems(problemCount);
            this.Graded = false;
        }

        public void Grade(List<string> userAnswers)
        {
            int problemCount = this.Problems.Count();
            int correctProblems = 0;
            decimal percentage = 0.00m;
            foreach (Problem problem in this.Problems)
            {
                //problem.Grade();
                if (problem.Correct)
                {
                    correctProblems++;
                }
            }
            percentage = ((decimal)correctProblems / (decimal)problemCount);
        }

        private void GenerateProblems(int? problemCount)
        {
            if (problemCount != null)
            {
                if (problemCount > 50)
                {
                    problemCount = 50;

                }
                while (problemCount != 0)
                {
                    this.Problems.Add(new Problem(this.ID, this.Type));
                    problemCount--;
                }
            }
        }

        public void Submit()
        {
            this.EndTime = DateTime.Now;
        }

        public void Start()
        {
            this.StartTime = DateTime.Now;
        }
    }
}