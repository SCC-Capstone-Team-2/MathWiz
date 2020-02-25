using MathWiz.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MathWiz
{
    public class Factory
    {

        private static AssignmentEndpoint _assignmentEndpoint;
        public static AssignmentEndpoint assignmentEndpoint
        {
            get
            {
                if(_assignmentEndpoint == null)
                {
                    _assignmentEndpoint = new AssignmentEndpoint();
                }
                return _assignmentEndpoint;
            }
        }

        private static ProblemEndpoint _problemEndpoint;
        public static  ProblemEndpoint problemEndpoint
        {
            get
            {
                if(_problemEndpoint == null)
                {
                    _problemEndpoint = new ProblemEndpoint();
                }
                return _problemEndpoint;
            }
        }

    }
}