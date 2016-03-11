using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace DatabaseConnectionQuiz
{
    public class GetQuizName
    {

        public List<QuizzesDto> FetchInfoFromQuizDb()
        {
            var sqlCon = new SqlConnection("Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\\QuizDBB.mdf;Integrated Security=True");


            SqlCommand cmd = new SqlCommand("SELECT * FROM Quizzes", sqlCon);

            
            sqlCon.Open();
            try
            {
                var listFromDB = new List<QuizzesDto>();
                using (SqlDataReader rdr = cmd.ExecuteReader())
                {
                    while (rdr.Read())
                    {
                        var NewQuiz = new QuizzesDto();

                        NewQuiz.Id = (int)rdr["Id"];
                        NewQuiz.Name = rdr["Name"].ToString();
                        NewQuiz.Created = (DateTime)rdr["Created"];
                        NewQuiz.Enddate = (DateTime)rdr["Enddate"];


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
