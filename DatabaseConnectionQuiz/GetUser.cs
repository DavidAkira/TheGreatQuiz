using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DatabaseConnectionQuiz
{
    public class GetUser
    {
        public UserDto FetchUserFromQuizDb(string email)
        {
            var sqlCon = new SqlConnection("Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\\QuizDBB.mdf;Integrated Security=True");

            SqlCommand cmd = new SqlCommand("SELECT * FROM Users WHERE Email ='" +email+"'", sqlCon); 

            sqlCon.Open();
            var user = new UserDto();
            try
            {
                using (SqlDataReader rdr = cmd.ExecuteReader())
                {
                    while (rdr.Read())
                    {
                        user.Id = (int)rdr["Id"];
                        user.Email = (string)rdr["Email"];
                        user.Password = (string)rdr["Password"];
                        user.IsAdmin = (bool)rdr["IsAdmin"];

                    }
                    sqlCon.Close();
                    rdr.Close();
                    return user;
                }
            }
            finally
            {
                sqlCon.Dispose();
                cmd.Dispose();
            }
        }

        public List<int> FetchUserIds()
        {
            var sqlCon = new SqlConnection("Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\\QuizDBB.mdf;Integrated Security=True");

            SqlCommand cmd = new SqlCommand("SELECT id FROM Users", sqlCon);

            sqlCon.Open();
            List<int> userIds = new List<int>();
            try
            {
                using (SqlDataReader rdr = cmd.ExecuteReader())
                {
                    while (rdr.Read())
                    {
                        userIds.Add((int)rdr["Id"]);

                    }
                    sqlCon.Close();
                    rdr.Close();
                    return userIds;
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