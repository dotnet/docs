using MVCRandomAnswerGenerator.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVCRandomAnswerGenerator.Controllers
{
    public class HomeController : Controller
    {
        private static List<QuestionAndAnswer> allAnswers = new List<QuestionAndAnswer>();

    public ActionResult Index()
        {
            // Ask a question.
            // Return with the answer.
            return View(allAnswers);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Index(string NextQuestion)
        {
            var latest = new QuestionAndAnswer
            {
                Question = NextQuestion,
                Answer = AnswerGenerator.GenerateAnswer(NextQuestion)
            };

            allAnswers.Insert(0,latest);

            return View(allAnswers);
        }
        public ActionResult About()
        {
            ViewBag.Message = "The ASP.NET MVC Random Answer Generator";

            return View();
        }
    }
}