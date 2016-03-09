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

			//TODO:: when database is fixed send to database and redirect to main page.
			if (firstPassword == secondPassword)
			{
				user.Password = firstPassword;
			}

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
            var gregerDtos = new GetQuizName().FetchInfoFromGreger();

            if (gregerDtos.Count != 0)
            {
                foreach (QuizzesDto t in gregerDtos)
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
    }
}