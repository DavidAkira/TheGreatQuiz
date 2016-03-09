using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace DatabaseConnectionQuiz
{
    class GetQuestions
    {
        public List<QuestionsDto> FetchQuestionsFromDb(int quizId)
        {
            var sqlCon = new SqlConnection("Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\\QuizDB.mdf;Integrated Security=True");


            SqlCommand cmd = new SqlCommand("SELECT * FROM questions WHERE quiz_id =" + quizId, sqlCon);


            sqlCon.Open();
            try
            {
                var listFromDB = new List<QuestionsDto>();
                using (SqlDataReader rdr = cmd.ExecuteReader())
                {
                    while (rdr.Read())
                    {
                        var NewQuiz = new QuestionsDto();

                       


                        listFromDB.Add(NewQuiz);
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
