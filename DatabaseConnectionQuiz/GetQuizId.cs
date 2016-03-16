using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DatabaseConnectionQuiz
{
    public class GetQuizId
    {
        public int GetLatestQuizId()
        {
            var sqlCon = new SqlConnection("Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\\QuizDBB.mdf;Integrated Security=True");
            
            SqlCommand cmd = new SqlCommand("SELECT MAX(Id) AS Id from Quizzes", sqlCon);
            
            sqlCon.Open();
            int QuizId = -1;
            try
            {
                using (SqlDataReader rdr = cmd.ExecuteReader())
                {
                    while (rdr.Read())
                    {
                        QuizId = (int)rdr["Id"];
                    }
                    sqlCon.Close();
                    rdr.Close();
                    return QuizId;
                }
            }
            finally
            {
                sqlCon.Dispose();
                cmd.Dispose();
                
            }
        }


        public int GetQuizIdByName(string name)
        {
            var sqlCon = new SqlConnection("Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\\QuizDBB.mdf;Integrated Security=True");

            SqlCommand cmd = new SqlCommand("SELECT MAX(Id) AS Id from Quizzes WHERE Name ='" + name +"'", sqlCon);

            sqlCon.Open();
            int QuizId = -1;
            try
            {
                using (SqlDataReader rdr = cmd.ExecuteReader())
                {
                    while (rdr.Read())
                    {
                        QuizId = (int)rdr["Id"];
                    }
                    sqlCon.Close();
                    rdr.Close();
                    return QuizId;
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
