using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MathWiz.Models
{
	public class Grade
	{
        public int AssignmentID { get; set; }
        public int StudentID { get; set; }
        public Decimal AssignmentGrade { get; set; }
        public Grade()
        {

        }

	}
}