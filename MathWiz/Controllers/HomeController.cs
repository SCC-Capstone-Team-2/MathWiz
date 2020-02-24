using MathWiz.Data;
using MathWiz.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MathWiz.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public ActionResult ViewAssignments()
        {
            List<Assignment> assignments = AssignmentEndpoint.GetAllAssignments();
            return View(assignments);
        }

        [HttpGet]
        public ActionResult TakeAssignment(int assignmentId)
        {
            Assignment assn = AssignmentEndpoint.GetAssignmentById(assignmentId);
            return View(assn);
        }

        public ActionResult About()
        {
            return View();
        }

        public ActionResult Testimonial()
        {
            return View();
        }
    }
}