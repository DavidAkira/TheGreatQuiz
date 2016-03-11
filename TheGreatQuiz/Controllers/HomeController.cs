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
            var model = new QuizzesView();
            var quizzesDtos = new GetQuizName().FetchInfoFromQuizDb();
            List<Quizzes> tmpQuizzes = new List<Quizzes>();

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
                    tmpQuizzes.Add(newMod);
                }
            }


            var tmpActiveQuizzes = from f in tmpQuizzes
                                   where f.Enddate > DateTime.Now
                                   select f;
            model.ActiveQuizzes = tmpActiveQuizzes.ToList();


            var tmpFinishedQuizzes = from f in tmpQuizzes
                                     where f.Enddate < DateTime.Now
                                     select f;
            model.FinishedQuizzes = tmpFinishedQuizzes.ToList();

            return View(model);
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


        public ActionResult QuizPage(int Id)
                    {
            quizIdHolder.quizId = Id;
            return View();
        }

        [HttpGet]
        public ActionResult QuestionsTest()
        {
            var getQuestions = new GetQuestions();
            List<QuestionsDto> questions = getQuestions.FetchQuestionsFromDb(quizIdHolder.quizId);

            return Json(questions, JsonRequestBehavior.AllowGet);

        }

        public ActionResult angularTestPage()
        {
            return View();
        }

        [HttpPost]
        public JsonResult angularTestData(List<string> arr)
        {
            string str1 = arr[0];
            string str2 = arr[1];

            return Json(arr, JsonRequestBehavior.AllowGet);
        }


    }
}