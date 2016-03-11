using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TheGreatQuiz.Models;
using DatabaseConnectionQuiz;

namespace TheGreatQuiz.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult AddQuiz()
        {
            return View();
        }
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Register()
        {
           
            return View();
        }

		[HttpPost]
		public ActionResult Register(User user)
		{
			user.Name = Request.Form["txtEmail"];

			var firstPassword = Request.Form["txtFirstPassword"];
			var secondPassword = Request.Form["txtSecondPassword"];

			//TODO:: when database is fixed send to database and redirect to loggin page.
			if (firstPassword == secondPassword)
			{
				user.Password = firstPassword;
			}

			return View();
		}

        public ActionResult Portal()
        {
            List<Test> tests = new List<Models.Test>();
            List<FinishedTest> finishedTests = new List<FinishedTest>();

            tests.Add(new Test());
            tests[0].Name = "Programmering prov 2";

            tests.Add(new Test());
            tests[1].Name = "Webbutveckling prov 2";

            tests.Add(new Test());
            tests[2].Name = "Databashantering prov 2";


            finishedTests.Add(new FinishedTest());
            finishedTests[0].Name = "Programmering prov 1";
            finishedTests[0].FinishedOn = new DateTime(2014, 1, 1);

            finishedTests.Add(new FinishedTest());
            finishedTests[1].Name = "Programmering prov 1";
            finishedTests[1].FinishedOn = new DateTime(2014, 1, 1);

            finishedTests.Add(new FinishedTest());
            finishedTests[2].Name = "Programmering prov 1";
            finishedTests[2].FinishedOn = new DateTime(2014, 1, 1);

            finishedTests.Add(new FinishedTest());
            finishedTests[3].Name = "Webbutveckling prov 1";
            finishedTests[3].FinishedOn = new DateTime(2014, 1, 1);

            finishedTests.Add(new FinishedTest());
            finishedTests[4].Name = "Programmering prov 1";
            finishedTests[4].FinishedOn = new DateTime(2014, 1, 1);

            ViewBag.tests = tests;
            ViewBag.finishedTests = finishedTests;

            return View();
        }
		public ActionResult QuizPage()
        {
            return View();
        }
        public ActionResult Test()
        {
            return View();
        }

		public ActionResult TestHeader()
		{
			return View();
		}

		public ActionResult RegisterPage()
		{
			return View();
		}

        public ActionResult Quizzes()
        {
       
            var model = new QuizzesView();
            var quizzesDtos = new GetQuizName().FetchInfoFromQuizDb();

            if (quizzesDtos.Count != 0)
            {
                foreach (QuizzesDto t in quizzesDtos)
                {
                    var newMod = new Quizzes
                    {
                        Id = t.Id,
                        Name = t.Name,
                        Created = t.Created,
                        Enddate = t.Enddate
                        
                    };
                    model.QuizzesList.Add(newMod);
                }
            }

            return View(model);
        }


        public ActionResult angularTestPage(int Id)
        {
            quizIdHolder.quizId = Id;
            return View();
        }

        [HttpGet]
        public ActionResult QuestionsTest()
        {
            var getQuestions = new GetQuestions();
            List<QuestionsDto> questions = getQuestions.FetchQuestionsFromDb(2);

            return Json(questions, JsonRequestBehavior.AllowGet);

        }



    }
}