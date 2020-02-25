using MathWiz.Data;
using MathWiz.Models;
using MathWiz.Models.ViewModels;
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
            List<Assignment> assignments = Factory.assignmentEndpoint.GetAllAssignments();
            List<AssignmentViewModel> viewModels = new List<AssignmentViewModel>();
            foreach(Assignment assn in assignments)
            {
                AssignmentViewModel viewModel = new AssignmentViewModel();
                viewModel.assignment = assn;
                viewModel.ProblemCount = Factory.problemEndpoint.GetProblemsForAssignment(assn.ID).Count;
                viewModels.Add(viewModel);
            }
            return View(viewModels);
        }

        [HttpGet]
        public ActionResult TakeAssignment(int assignmentId)
        {
            Assignment assn = Factory.assignmentEndpoint.GetAssignmentById(assignmentId);
            return View(assn);
        }

        [HttpGet]
        public ActionResult CreateAssignment()
        {
            return View();
        }

        [HttpPost]
        public ActionResult CreateAssignment(string aName, int aType, int numOfProblems, DateTime dueDate)
        {
            Assignment assignment = new Assignment(aName, null, aType, numOfProblems, dueDate);
            Factory.assignmentEndpoint.AddAssignment(assignment);
            //Below is for testing purposes with grabbing values. Seems to work
            //assignment.Name = aName;
            //assignment.Type = Convert.ToInt32(aType);
            //assignment.ProblemCount = Convert.ToInt32(numOfProblems);
            //assignment.DueBy = dueDate;
            return Content($"Assignment name: {aName}<br>Operator: {aType}<br>Number of Problems: {numOfProblems}<br>Due Date: {dueDate}");
        }

        public ActionResult About()
        {
            return View();
        }

        public ActionResult Testimonial()
        {
            return View();
        }

        [HttpGet]
        public ActionResult Registration()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Registration(Registration registration)
        {
            return View(registration);
        }

        [HttpGet]
        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Login(Login login)
        {
            return View(login);
        }

    }
}