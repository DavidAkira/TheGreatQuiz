using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DatabaseConnectionQuiz
{
   public class QuestionsDto
    {
        public string Title { get; set; }

        public List<AnswersDto> Answers { get; set; }
        public int CorrectAnswer { get; set; }


        public QuestionsDto(string Title, int CorrectAnswer)
        {
            this.Title = Title;
            this.CorrectAnswer = CorrectAnswer;
            Answers = new List<AnswersDto>();
        }

        public QuestionsDto()
        {
            Answers = new List<AnswersDto>();
        }

    }
}
