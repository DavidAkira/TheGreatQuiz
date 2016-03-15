using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DatabaseConnectionQuiz
{
    public class GetQuizStatus
    {
        public bool FetchUserQuizStatus(int userId, int quizId)
        {
            var sqlCon = new SqlConnection("Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\\QuizDBB.mdf;Integrated Security=True");

            SqlCommand cmd = new SqlCommand("SELECT Finished FROM UsersQuizzes WHERE UQ_userId =" + userId + "and UQ_quizId =" + quizId, sqlCon);

            sqlCon.Open();
            bool quizStatus = false;
            try
            {
                using (SqlDataReader rdr = cmd.ExecuteReader())
                {
                    while (rdr.Read())
                    {

                        quizStatus = (bool)rdr["Finished"];

                    }
                    sqlCon.Close();
                    rdr.Close();
                    return quizStatus;
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
