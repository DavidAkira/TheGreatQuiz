using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DatabaseConnectionQuiz
{
    class QuestionsDto
    {
        public string Title { get; set; }

        public List<string> Answers { get; set; }
        public int CorrectAnswer { get; set; }


        public QuestionsDto(string Title, List<string> Answers, int CorrectAnswer)
        {
            this.Title = Title;
            this.Answers = Answers;
            this.CorrectAnswer = CorrectAnswer;
        }

        public QuestionsDto()
        {

        }

    }
}
