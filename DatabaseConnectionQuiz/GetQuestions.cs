using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace DatabaseConnectionQuiz
{
   public class GetQuestions
    {
        public List<QuestionsDto> FetchQuestionsFromDb(int quizId)
        {
            var sqlCon = new SqlConnection("Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\\QuizDBB.mdf;Integrated Security=True");


            SqlCommand cmd = new SqlCommand("SELECT * FROM questions WHERE quiz_id =" + quizId, sqlCon);


            sqlCon.Open();
            try
            {
                var listFromDB = new List<QuestionsDto>();
                using (SqlDataReader rdr = cmd.ExecuteReader())
                {
                    while (rdr.Read())
                    {
                        var NewQuestion = new QuestionsDto();

                        NewQuestion.Title = (string)rdr["Title"];
                        NewQuestion.Answers.Add(new AnswersDto(0, rdr["Answer_1"].ToString()));
                        NewQuestion.Answers.Add(new AnswersDto(1, rdr["Answer_2"].ToString()));
                        NewQuestion.Answers.Add(new AnswersDto(2, rdr["Answer_3"].ToString()));

                        if ((string)rdr["Answer_4"] != "")
                        {
                            NewQuestion.Answers.Add(new AnswersDto(3, rdr["Answer_4"].ToString()));
                        }
                        var some = rdr["Answer_5"];
                        if ((string)rdr["Answer_5"] != "")
                        {
                            NewQuestion.Answers.Add(new AnswersDto(4, rdr["Answer_5"].ToString()));
                        }

                        NewQuestion.CorrectAnswer = (int)rdr["CorrectAnswer"];


                        listFromDB.Add(NewQuestion);
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
