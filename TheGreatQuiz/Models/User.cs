﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TheGreatQuiz.Models
{
	public class User
	{
		public int Id { get; set; }

        public string Email { get; set; }

		public string Password { get; set; }

        public string IsAdmin { get; set; }


	}
}