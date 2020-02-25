using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MathWiz.Models.ViewModels
{
    public class AssignmentViewModel
    {

        public Assignment assignment { get; set; }
        public int ProblemCount { get; set; }

        public AssignmentViewModel()
        {

        }

    }
}