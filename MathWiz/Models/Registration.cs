using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MathWiz.Models
{
    public class Registration
    {

        public string Username { get; set; }
        public string Password { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string RegistrationType { get; set; }

        public string[] RegistrationOptions
        {
            get
            {
                return new string[]{ "Student", "Teacher"};
            }
        }

    }
}