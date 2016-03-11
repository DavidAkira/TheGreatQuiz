using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TheGreatQuiz.Models;

namespace TheGreatQuiz.Controllers
{
    public class LoginController : Controller
    {
        // GET: Login
        public ActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Login(string email, string password)
        {
            if ("admin@admin.com".Equals(email) && "123".Equals(password))
            {
                Session["user"] = new User() {Email = email};
                return RedirectToAction("Index", "Home");
            }
            return View();                
        }
    }
}