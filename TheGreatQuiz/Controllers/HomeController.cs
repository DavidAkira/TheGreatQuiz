﻿using System;
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
            if (Session["userId"] == null)
            {
                return RedirectToAction("Index", "Home");
            }
            if (Session["userId"] == null || (bool)Session["admin"] != true)
            {
                return RedirectToAction("Portal", "Home");
            }
            return View();
        }
        public ActionResult AdminHome()
        {
            if (Session["userId"] == null)
            {
                return RedirectToAction("Index", "Home");
            }
            if (Session["userId"] == null || (bool)Session["admin"] != true)
            {
                return RedirectToAction("Portal", "Home");
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
                    Session["admin"] = true;
                    return RedirectToAction("AdminHome", "Home");
                }
                
                else if (currentUser.IsAdmin == false)
                {
                    Session["admin"] = false;
                    Session["userId"] = currentUser.Id;
                    Session["admin"] = false;
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

			var tmp = from f in model.ActiveQuizzes
									 where f.Enddate < DateTime.Now
									 select f;

			var outOfDateQuizzes = tmp.ToList();

			var updateDatabase = new UpdateDatabase();

			foreach (var quiz in outOfDateQuizzes)
			{
				updateDatabase.BlockAllUsersFromQuiz(quiz.Id);
				model.ActiveQuizzes.Remove(quiz);
				model.FinishedQuizzes.Add(quiz);

			}

			tmp = from f in model.ActiveQuizzes
				  where f.StartDate <= DateTime.Now
				  select f;
			model.ActiveQuizzes = tmp.ToList();

			return View(model);
        }

        public ActionResult Test()
        {

            var getScores = new GetUserScore().FetchUserQuizScore(12);


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
        public JsonResult QuizEnded()
        {
            var updateDatabase = new UpdateDatabase();
            updateDatabase.BlockUserFromQuiz((int)Session["userId"], quizIdHolder.quizId);

            return Json("hej", JsonRequestBehavior.AllowGet);
        }
        [HttpPost]
        public JsonResult QuizEndUpdateScore(string[] arr)
        {
            var updateDatabase = new UpdateDatabase();

            int userScore = int.Parse(arr[0]);
            int maxScore = int.Parse(arr[1]);

            updateDatabase.CreateUserScore((int)Session["userId"], quizIdHolder.quizId, maxScore, userScore);

            return Json("hej", JsonRequestBehavior.AllowGet);
        }


        public ActionResult About()
        {
            return View();
        }
        public ActionResult ResultPage()
        {
            if (Session["userId"] == null)
            {
                return RedirectToAction("Index", "Home");
            } if (Session["userId"] == null || (bool)Session["admin"] != true)
            {
                return RedirectToAction("Portal", "Home");
            }
                
            return View();
        }

        public ActionResult ResultPageQuizData()
        {

            var getQuizName = new GetQuizName();

            var users = getQuizName.FetchInfoFromQuizDb();

            return Json(users, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public JsonResult ResultPageOtherData(string[] arr)
        {

            var getUserScore = new GetUserScore();

            var userScores = getUserScore.FetchUserQuizScore(Convert.ToInt32(arr[0]));

            return Json(userScores, JsonRequestBehavior.AllowGet);
        }







    }
}