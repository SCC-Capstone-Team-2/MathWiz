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

        public ActionResult ViewAssignments()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult TakeAssignment()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}