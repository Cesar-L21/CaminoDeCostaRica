using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ElCaminoDeCostaRica.Models;

namespace ElCaminoDeCostaRica.Controllers
{
    public class LoginController : Controller
    {
        public ActionResult Login()
        {

            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Login(User user)
        {
            ViewBag.LoginSuccess = false;
            Database database = new Database();
            database.openConnection();
            if (!database.checkEmail(user.email))
            {                
                if (database.checkPassword(user.email, user.password))
                {
                    ViewBag.LoginSuccess = true;
                    //ViewBag.Message = "Login Success: " + user.email;
                    ModelState.Clear();

                    int userType = database.getUserType(user.email);
                    switch(userType)
                    {
                        case 0:
                            TempData["Menu"] = "user";
                            break;

                        case 1:
                            TempData["Menu"] = "admin";
                            break;
                    }

                    //Save cookie with user login information
                    HttpCookie userLoginInfo = new HttpCookie("userLoginInfo");
                    userLoginInfo["username"] = user.email;
                    userLoginInfo["password"] = user.password;
                    userLoginInfo.Expires.Add(new TimeSpan(0, 1, 0));
                    Response.Cookies.Add(userLoginInfo);

                    return View("~/Views/Home/Index.cshtml");
                }
                else
                {
                    ViewBag.Message = "Credenciales incorrectas!";
                }
            }
            else
            {
                ViewBag.Message = "El correo electrónico no se encuentra registrado!";
            }
            database.closeConnection();
            ModelState.Clear();
            return View();
        }

        public ActionResult Close()
        {
            HttpContext.Response.Cookies.Remove("UserInfo");
            return View("Login");
        }

        public ActionResult UserDashBoard()
        {
            if (Session["id"] != null)
            {
                return View();
            }
            else
            {
                return RedirectToAction("Login");
            }
        }
    }
}