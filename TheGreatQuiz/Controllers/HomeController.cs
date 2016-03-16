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
            if (Session["userId"] == null && (int)Session["userId"] != 1)
            {
                return RedirectToAction("Index", "Home");
            }
            return View();
        }
        public ActionResult AdminHome()
        {
            if (Session["userId"] == null)
            {
                return RedirectToAction("Index", "Home");
            }
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
            var currentUser = getUser.FetchUserFromQuizDb(email);
            if (currentUser.Password == password)
            {
                if (currentUser.IsAdmin)
                {
                    Session["userId"] = currentUser.Id;
                    return RedirectToAction("AdminHome", "Home");
                }
                else if (currentUser.IsAdmin == false)
                {
                    Session["userId"] = currentUser.Id;
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
            if (Session["userId"] == null)
            {
                return RedirectToAction("Index", "Home");
            }
            var model = new QuizzesView();
            var quizzesDtos = new GetQuizName().FetchInfoFromQuizDb();
            List<Quizzes> tmpQuizzes = new List<Quizzes>();

			var getQuizStatus = new GetQuizStatus();
			model.FinishedQuizzes = new List<Quizzes>();
			model.ActiveQuizzes = new List<Quizzes>();

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

					if (!getQuizStatus.FetchUserQuizStatus((int)Session["userId"], newMod.Id))
					{
						model.ActiveQuizzes.Add(newMod);
					}
					else
					{
						model.FinishedQuizzes.Add(newMod);
					}
                }
            }



            //var tmpActiveQuizzes = from f in tmpQuizzes
            //                       where f.Enddate > DateTime.Now
            //                       select f;
            //model.ActiveQuizzes = tmpActiveQuizzes.ToList();


            //var tmpFinishedQuizzes = from f in tmpQuizzes
            //                         where f.Enddate < DateTime.Now
            //                         select f;
            //model.FinishedQuizzes = tmpFinishedQuizzes.ToList();

            return View(model);
        }

        public ActionResult Test()
        {

            //var getQuizStatus = new GetQuizStatus();
            //var getUser = new GetUser();
            //var usersIds = getUser.FetchUserIds();
            //var updateDatabase = new UpdateDatabase();

            //updateDatabase.BlockUserFromQuiz(2, 8);

            //foreach (var userId in usersIds)
            //{
            //    updateDatabase.AddUsersToQuiz(userId, 4);
            //}

            return View();
        }

        public ActionResult TestHeader()
        {
            return View();
        }



        public ActionResult QuizPage(int Id)
        {

            var getQuizStatus = new GetQuizStatus();

            bool quizStatus = getQuizStatus.FetchUserQuizStatus((int)Session["userId"], Id);

            if (quizStatus)
            {
                return RedirectToAction("Index", "Home");
            }

            quizIdHolder.quizId = Id;
            return View();
        }

        [HttpGet]
        public ActionResult LoadQuizData()
        {

            int quizId = quizIdHolder.quizId;
            var getQuizData = new GetQuizName();
            var quiz = getQuizData.FetchQuizInfo(quizId);

            return Json(quiz, JsonRequestBehavior.AllowGet);
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

           
            updDB.CreateQuiz(quizData[0][0], quizData[0][1], quizData[0][2], Convert.ToInt32(quizData[0][3]), Convert.ToBoolean(quizData[0][4]));

            var getQuiz = new GetQuizId();
            int quizID = getQuiz.GetLatestQuizId();

            for (int i = 1; i < quizData.Length; i++)
            {
                updDB.CreateQuestionsForQuiz(quizID, quizData[i][0], quizData[i][1], quizData[i][2], quizData[i][3], quizData[i][4], quizData[i][5], quizData[i][6]);
            }


            var getQuizStatus = new GetQuizStatus();
            var getUser = new GetUser();
            var usersIds = getUser.FetchUserIds();
            var updateDatabase = new UpdateDatabase();

            foreach (var userId in usersIds)
            {
                updateDatabase.AddUsersToQuiz(userId, quizID);
            }


            return Json("HEJ!", JsonRequestBehavior.AllowGet);
        }

        [HttpGet]
        public ActionResult QuizEnded()
        {
            var updateDatabase = new UpdateDatabase();

            updateDatabase.BlockUserFromQuiz((int)Session["userId"], quizIdHolder.quizId);

            return Json("hej", JsonRequestBehavior.AllowGet); ;
        }


        public ActionResult About()
        {
            return View();
        }
    }
}