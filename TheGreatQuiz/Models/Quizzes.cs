using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace TheGreatQuiz.Models
{
    public class Quizzes
    {
        
        public int Id { get; set; }

        public string Name { get; set; }

        public DateTime Created { get; set; }

        public DateTime Enddate { get; set; }

        public DateTime StartDate { get; set; }

        public int QuizTimer { get; set; }

    }
}