using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DatabaseConnectionQuiz
{
    public class QuizzesDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime Created { get; set; }
        public DateTime Enddate { get; set; }
        public DateTime StartDate { get; set; }
        public int QuizTimer { get; set; }

        public bool ShowAnswers { get; set; }

        public QuizzesDto(int Id, string Name, DateTime Created, DateTime Enddate, int QuizTimer, DateTime StartDate, bool ShowAnswers)
        {
            this.Id = Id;
            this.Name = Name;
            this.Created = Created;
            this.Enddate = Enddate;
            this.QuizTimer = QuizTimer;
            this.StartDate = StartDate;
            this.ShowAnswers = ShowAnswers;


        }
        public QuizzesDto()
        {

        }
    }
}
