using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ElCaminoDeCostaRica.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Home() 
        {
            return View();
        
        }

        public ActionResult LogOut()
        {
            if (Request.Cookies["userLoginInfo"] != null)
            {
                HttpCookie cookie = Request.Cookies["userLoginInfo"];
                cookie["username"] = string.Empty;
                cookie["password"] = string.Empty;
                cookie.Expires = DateTime.Now.AddHours(-1);
                Response.Cookies.Add(cookie);
                TempData["Menu"] = "guest";
            }

            return View("~/Views/Home/Index.cshtml");
        }
    }
}