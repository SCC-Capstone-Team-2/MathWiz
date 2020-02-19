using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MathWiz.Models
{
    public class Problem
    {
        public int ID { get; set; }
        public string Answer { get; set; }
        public string Question { get; set; }
        public int Type { get; set; }
        public bool Correct { get; set; }
        public bool Graded { get; set; }

        public Problem() { }

        // This constructor is used for pulling from the database
        public Problem(int id, string text, string answer, int type) {
            this.ID = id;
            this.Question = text;
            this.Answer = answer;
            this.Type = type;
        }

        // This constructor is used to create random questions
        public Problem(int type)
        {
            this.Type = type;
            this.Graded = false;
            this.RandomizeQuestion(type, 10, 10);
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

        public void RandomizeQuestion(int type, int minNum, int maxNum)
        {
            Random rng = new Random();
            int num1 = rng.Next(minNum, maxNum);
            int num2 = rng.Next(minNum, maxNum);
            switch (type)
            {
                case 1: // Addition
                    this.Question = num1.ToString() + " + " + num2.ToString();
                    this.Answer = (num1 + num2).ToString();
                    break;
                case 2: // Subtraction
                    this.Question = num1.ToString() + " - " + num2.ToString();
                    this.Answer = (num1 - num2).ToString();
                    break;
                case 3: // Multiplication
                    this.Question = num1.ToString() + " * " + num2.ToString();
                    this.Answer = (num1 * num2).ToString();
                    break;
                case 4: // Division
                    this.Question = num1.ToString() + " / " + num2.ToString();
                    this.Answer = (num1 / num2).ToString();
                    break;
                default: // Default will be addition
                    this.Question = num1.ToString() + " + " + num2.ToString();
                    this.Answer = (num1 + num2).ToString();
                    break;
            }
        }
    }
}