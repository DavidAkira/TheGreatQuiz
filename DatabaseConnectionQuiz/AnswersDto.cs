using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DatabaseConnectionQuiz
{
    public class AnswersDto
    {
        public int Id { get; set; }
        public string Text { get; set; }

        public AnswersDto(int Id, string Text)
        {
            this.Id = Id;
            this.Text = Text;

        }

        public AnswersDto()
        {

        }


    }
}
