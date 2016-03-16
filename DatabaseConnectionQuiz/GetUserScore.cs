using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DatabaseConnectionQuiz
{
    public class GetUserScore
    {
        public List<UserScoreDto> FetchUserQuizScore(int quizId)
        {
            var sqlCon = new SqlConnection("Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\\QuizDBB.mdf;Integrated Security=True");


            SqlCommand cmd = new SqlCommand("SELECT MaxScore, UserScore, Users.Email AS Email, Quizzes.Name AS Name FROM UserQuizScore " +
                "JOIN Users ON Users.Id = UserQuizScore.UQ_userId " +
                "JOIN Quizzes ON Quizzes.Id = UserQuizScore.UQ_quizId " +
                "WHERE UserQuizScore.UQ_quizId =" + quizId, sqlCon);


            sqlCon.Open();
            try
            {
                var listFromDB = new List<UserScoreDto>();
                using (SqlDataReader rdr = cmd.ExecuteReader())
                {
                    while (rdr.Read())
                    {
                        var newUserScore = new UserScoreDto();

                        newUserScore.MaxScore = (int)rdr["MaxScore"];
                        newUserScore.UserScore = (int)rdr["UserScore"];
                        newUserScore.QuizName = (string)rdr["Name"];
                        newUserScore.UserEmail = (string)rdr["Email"];


                        listFromDB.Add(newUserScore);
                    }
                    sqlCon.Close();
                    rdr.Close();
                    return listFromDB;
                }
            }
            finally
            {
                sqlCon.Dispose();
                cmd.Dispose();
            }

        }
    }
}
