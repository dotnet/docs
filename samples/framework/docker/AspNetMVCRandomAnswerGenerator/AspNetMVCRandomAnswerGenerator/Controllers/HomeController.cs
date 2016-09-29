using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AspNetMVCRandomNumberGenerator.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            // Ask a question.
            // Return with the answer.
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "The Magic 8 Ball on the web";

            return View();
        }
    }
}