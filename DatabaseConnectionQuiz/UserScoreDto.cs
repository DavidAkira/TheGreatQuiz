using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DatabaseConnectionQuiz
{
    public class UserScoreDto
    {
        public string UserEmail { get; set; }
        public string QuizName { get; set; }
        public int MaxScore { get; set; }
        public int UserScore { get; set; }

        public UserScoreDto(string UserEmail, string QuizName, int MaxScore, int UserScore)
        {
            this.UserEmail = UserEmail;
            this.QuizName = QuizName;
            this.MaxScore = MaxScore;
            this.UserScore = UserScore;
        }


        public UserScoreDto()
        {

        }



    }
}
