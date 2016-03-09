using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TheGreatQuiz.Models
{
    public class QuizzesView
    {
        public List<Quizzes> QuizzesList { get; set; }

        public QuizzesView()
        {
            QuizzesList = new List<Quizzes>();
        }
    }
}