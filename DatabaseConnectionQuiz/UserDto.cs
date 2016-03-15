using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DatabaseConnectionQuiz
{
    public class UserDto
    {
        public int Id { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public bool IsAdmin { get; set; }

        public UserDto(int id, string email, string password, bool isAdmin)
        {
            this.Id = id;
            this.Email = email;
            this.Password = password;
            this.IsAdmin = isAdmin;
        }

        public UserDto()
        {
            //(:
        }
    }
}
