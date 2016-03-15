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
        public ActionResult AdminHome()
        {
            return View();
        }

        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Index(string email, string password)
        {
            var getUser = new GetUser();
            var user = getUser.FetchUserFromQuizDb(email);
            if (user.Password == password)
            {
                if (user.IsAdmin == true)
                {
                    return RedirectToAction("AdminHome", "Home");
                }else if (user.IsAdmin ==false)
                {
                    return RedirectToAction("Portal", "Home");
                }             
            }
            return View();
        }

        public ActionResult Register()
        {
           
            return View();
        }

		[HttpPost]
		public JsonResult RegisterUser(string[] arr)
		{

            var dbUpdate = new UpdateDatabase();

            dbUpdate.AddUser(arr[0], arr[1]);

            return Json("HEJ!", JsonRequestBehavior.AllowGet);
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
        public JsonResult angularTestData(string[][] quizData)
        {
            var updDB = new UpdateDatabase();
            updDB.CreateQuiz(quizData[0][0]);

            var getQuiz = new GetQuizId();
            int quizID = getQuiz.GetLatestQuizId();

            for (int i = 1; i < quizData.Length; i++)
            {
                updDB.CreateQuestionsForQuiz(quizID, quizData[i][0], quizData[i][1], quizData[i][2], quizData[i][3], quizData[i][4], quizData[i][5], quizData[i][6]);
            }

            return Json("HEJ!", JsonRequestBehavior.AllowGet);
        }

		public ActionResult About()
		{
			return View();
		}
    }
}