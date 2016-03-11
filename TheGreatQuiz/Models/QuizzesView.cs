using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TheGreatQuiz.Models
{
    public class QuizzesView
    {
        public List<Quizzes> ActiveQuizzes { get; set; }

        public List<Quizzes> FinishedQuizzes { get; set; }

        public QuizzesView()
        {
            ActiveQuizzes = new List<Quizzes>();
        }
    }
}