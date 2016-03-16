using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DatabaseConnectionQuiz
{
    public class UpdateDatabase
    {
        public void CreateQuiz(string Quizname)
        {
            SqlConnection sqlcon = new SqlConnection("Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\\QuizDBB.mdf;Integrated Security=True");
            string sqlInsert = "INSERT INTO Quizzes(Name,Created,Enddate) VALUES(@param1,@param2,@param3)";
            SqlCommand sqlCom = new SqlCommand(sqlInsert, sqlcon);

            try
            {
                sqlCom.Parameters.AddWithValue("@param1", Quizname);
                sqlCom.Parameters.AddWithValue("@param2", DateTime.Now);
                sqlCom.Parameters.AddWithValue("@param3", new DateTime(2018,12,12,12,12,12,12));

                sqlcon.Open();
                sqlCom.ExecuteNonQuery();
                sqlcon.Close();
            }
            catch (Exception)
            {
                
            }

            finally
            {
                sqlCom.Dispose();
                sqlcon.Dispose();
            }
        }

        public void CreateQuestionsForQuiz(int quizId,string question, string correctanswer,string ans1, string ans2, string ans3, string ans4, string ans5)
        {
            SqlConnection sqlcon = new SqlConnection("Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\\QuizDBB.mdf;Integrated Security=True");
            string sqlInsert = "INSERT INTO Questions(Title,Answer_1,Answer_2,Answer_3,Answer_4,Answer_5,CorrectAnswer,Quiz_Id) VALUES(@param1,@param2,@param3,@param4,@param5,@param6,@param7,@param8)";
            SqlCommand sqlCom = new SqlCommand(sqlInsert, sqlcon);

            try
            {
                int coransInt = int.Parse(correctanswer);

                sqlCom.Parameters.AddWithValue("@param1", question);
                sqlCom.Parameters.AddWithValue("@param2", ans1);
                sqlCom.Parameters.AddWithValue("@param3", ans2);
                sqlCom.Parameters.AddWithValue("@param4", ans3);
                sqlCom.Parameters.AddWithValue("@param5", ans4);
                sqlCom.Parameters.AddWithValue("@param6", ans5);
                sqlCom.Parameters.AddWithValue("@param7", coransInt);
                sqlCom.Parameters.AddWithValue("@param8", quizId);


                sqlcon.Open();
                sqlCom.ExecuteNonQuery();
                sqlcon.Close();
            }
            catch (Exception)
            {

            }

            finally
            {
                sqlCom.Dispose();
                sqlcon.Dispose();
            }
        }

        public void AddUser(string email, string password)
        {
            SqlConnection sqlcon = new SqlConnection("Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\\QuizDBB.mdf;Integrated Security=True");
            string sqlInsert = "INSERT INTO Users(Email, Password) VALUES(@param1,@param2)";
            SqlCommand sqlCom = new SqlCommand(sqlInsert, sqlcon);

            try
            {
                sqlCom.Parameters.AddWithValue("@param1", email);
                sqlCom.Parameters.AddWithValue("@param2", password);

                sqlcon.Open();
                sqlCom.ExecuteNonQuery();
                sqlcon.Close();
            }
            catch (Exception)
            {

            }

            finally
            {
                sqlCom.Dispose();
                sqlcon.Dispose();
            }
        }

		public void BlockAllUsersFromQuiz(int quizId)
		{
			GetUser getUser = new GetUser();
			var userIds = getUser.FetchUserIds();

			foreach (var userId in userIds)
			{
				BlockUserFromQuiz(userId, quizId);
			}
		}

		public void AddUsersToQuiz(int userId, int quizId)
        {
            SqlConnection sqlcon = new SqlConnection("Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\\QuizDBB.mdf;Integrated Security=True");
            string sqlInsert = "INSERT INTO UsersQuizzes(UQ_userId, UQ_quizId) VALUES(@param1,@param2)";
            SqlCommand sqlCom = new SqlCommand(sqlInsert, sqlcon);

            try
            {
                sqlCom.Parameters.AddWithValue("@param1", userId);
                sqlCom.Parameters.AddWithValue("@param2", quizId);

                sqlcon.Open();
                sqlCom.ExecuteNonQuery();
                sqlcon.Close();
            }
            catch (Exception)
            {

            }

            finally
            {
                sqlCom.Dispose();
                sqlcon.Dispose();
            }
        }


        public void BlockUserFromQuiz(int userId, int quizId)
        {
            SqlConnection sqlcon = new SqlConnection("Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\\QuizDBB.mdf;Integrated Security=True");
            string sqlInsert = "UPDATE UsersQuizzes SET Finished=1 WHERE UQ_userId=" + userId + "AND UQ_quizId=" + quizId;
            SqlCommand sqlCom = new SqlCommand(sqlInsert, sqlcon);

            try
            {
                sqlcon.Open();
                sqlCom.ExecuteNonQuery();
                sqlcon.Close();
            }
            catch (Exception)
            {

            }

            finally
            {
                sqlCom.Dispose();
                sqlcon.Dispose();
            }
        }



    }
}
