using ElCaminoDeCostaRica.Models;
using System.Web.Mvc;
using System.Text.RegularExpressions;
using System;
using System.Collections.Generic;
using System.Threading;

namespace ElCaminoDeCostaRica.Controllers
{
    public class RegisterController : Controller
    {
        private Database database = new Database();

        public ActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Register(User user)
        {
            ViewBag.Success = false;
            try
            {
                if (ModelState.IsValid)
                {
                    database.openConnection();

                    // Check user ID
                    if (database.checkID(user.id))
                    {
                        // Check user email
                        if (database.checkEmail(user.email))
                        {
                            // Check user password
                            int passwordResult = checkPassword(user.password);
                            if (passwordResult == 0)
                            {
                                return View("userHealth", user);

                            }
                            else
                            {
                                switch (passwordResult)
                                {
                                    case 1:
                                        ViewBag.Message = "La clave no tiene el tamano minimo";
                                        break;
                                    case 2:
                                        ViewBag.Message = "La clave no contiene numeros";
                                        break;
                                    case 3:
                                        ViewBag.Message = "La clave no contiene letras mayusculas ni minusculas";
                                        break;
                                    case 4:
                                        ViewBag.Message = "La clave no contiene simbolos especiales";
                                        break;
                                }
                            }
                        }
                        else
                        {
                            ViewBag.Message = "El correo electronico ya esta registrado!";
                        }
                    }
                    else
                    {
                        ViewBag.Message = "La cedula ya se encuetra registada!";
                    }

                    database.closeConnection();
                    if (ViewBag.Success)
                    {
                        ViewBag.Message = "El Usuario" + " " + user.id + " Fue creado con exito (:";
                        ModelState.Clear();
                    }

                }

                return View();
            }
            catch (Exception e)
            {
                System.Diagnostics.Debug.WriteLine(e.Message);
                ViewBag.Message = "Algo salio mal y no fue posible crear el Usuario :(";
                return View();
            }

        }


        public ActionResult userHealth(User user)
        {
            return View(user);
        }

        [HttpPost]
        public ActionResult userHealth(User user, FormCollection form)
        {
            try
            {
                if (user != null)
                {
                    List<Disease> diseases = new List<Disease>();
                    string[] diseasesNames = { "Hipertensión", "Diabetes Mellitus", "Cáncer" };
                    for (int index = 1; index < 5; ++index)
                    {
                        var treatment = form["numero" + index];
                        if (!string.IsNullOrEmpty(treatment))
                        {
                            if (index == 4)
                            {
                                diseases.Add(
                                    new Disease
                                    {
                                        name = treatment,
                                        treatment = form["numero5"],
                                        idUser = user.id
                                    });
                            }
                            else
                            {
                                diseases.Add(
                                    new Disease
                                    {
                                        name = diseasesNames[index - 1],
                                        treatment = treatment,
                                        idUser = user.id
                                    });
                            }
                        }
                    }
                    TempData["diseases"] = diseases;
                    Mail mail = new Mail();
                    CodeGenerator codeGenerator = new CodeGenerator();
                    string code = codeGenerator.generateRegisterCode(10);
                    TempData["Code"] = code;
                    ViewBag.Success = false;
                    TempData["Attemps"] = 1;
                    mail.sendRegisterCode(user.email, code);
                    return View("ConfirmSignUp", user);
                }
            }
            catch (Exception e)
            {
                System.Diagnostics.Debug.WriteLine(e.Message);
                ViewBag.Message = "Algo salio mal y no fue posible completar el registro.";
                return View(user);
            }

            return View(user);
        }

        public ActionResult userList()
        {
            TempData["index"] = 1;
            database.openConnection();
            ViewBag.Users = database.userList();
            database.closeConnection();
            return View();
        }

        [HttpPost]
        public ActionResult ConfirmSignUp(User user, string code, string submitButton)
        {
            switch (submitButton)
            {
                case "Confirmar":
                    ViewBag.Message = "Código incorrecto!";
                    if (String.Equals(TempData.Peek("Code").ToString(), code))
                    {
                        List<Disease> userDiseases = (List<Disease>)TempData.Peek("diseases");
                        database.openConnection();
                        ViewBag.Success = database.addWalker(user);
                        if (userDiseases != null)
                        {
                            for (int index = 0; index < userDiseases.Count; ++index)
                            {
                                database.addDisease(userDiseases[index]);
                            }
                        }
                        database.closeConnection();
                        ViewBag.Message = user.email + " registrado correctamente!";
                        return View("~/Views/Login/Login.cshtml", user);
                    }
                    else
                    {
                        ViewBag.Success = false;
                        if (Convert.ToInt32(TempData.Peek("Attemps").ToString()) != 3)
                        {
                            TempData["Attemps"] = Convert.ToInt32(TempData.Peek("Attemps").ToString()) + 1;
                        }
                        else
                        {
                            // Limpiar modelo
                            ViewBag.Message = "Ha superado los intentos permitidos, debe realizar el registro nuevamente.";
                            return View("Register", user);
                        }
                    }
                    break;

                default:
                    Mail mail = new Mail();
                    mail.sendRegisterCode(user.email, TempData.Peek("Code").ToString());
                    ViewBag.Success = false;
                    ViewBag.Message = "Código enviado correctamente!";
                    break;
            }


            return View();
        }

        [HttpGet]
        public ActionResult showUserHealth(int? id)
        {
            ActionResult vista;
            try
            {
                database.openConnection();
                User userItem = database.userList().Find(smodel => smodel.id == id);
                database.closeConnection();
                if (userItem == null)
                {
                    vista = RedirectToAction("userList");
                }
                else
                {
                    database.openConnection();
                    List<Disease> userDiseases = database.getUserDisease(userItem.id);
                    database.closeConnection();
                    ViewBag.UserDiseases = userDiseases;
                    ViewBag.User = userItem;
                    vista = View(userItem);
                }
            }
            catch
            {
                vista = RedirectToAction("userList");
            }
            return View();
        }

        [HttpPost]
        public ActionResult showUserHealth(User user, List<Disease> userDiseases)
        {
            return View();
        }

        [HttpGet]
        public ActionResult userEdit(int? identificador)
        {
            ActionResult vista;
            try
            {
                database.openConnection();
                User userItem = database.userList().Find(smodel => smodel.id == identificador);
                database.closeConnection();
                if (userItem == null)
                {
                    vista = RedirectToAction("userList");
                }
                else
                {
                    database.openConnection();
                    List<Disease> userDiseases = database.getUserDisease(userItem.id);
                    database.closeConnection();
                    ViewBag.UserDiseases = userDiseases;
                    ViewBag.Disability = userItem.disability;
                    vista = View(userItem);
                }
            }
            catch (Exception e)
            {
                System.Diagnostics.Debug.WriteLine(e.Message);
                vista = RedirectToAction("userList");
            }
            return vista;
        }

        [HttpPost]
        public ActionResult userEdit(User user, FormCollection form)
        {
            try
            {
                database.openConnection();
                database.userEdit(user);
                ViewBag.Users = database.userList();
                database.closeConnection();

                var names = form["enfermedad"];
                var treatments = form["tratamiento"];

                string[] diseasesName = names.Split(',');
                string[] diseasesTreatment = treatments.Split(',');
                database.openConnection();
                database.deleteUserDiseases(user.id);
                database.closeConnection();

                for (int i = 0; i < diseasesName.Length; ++i)
                {
                    Disease disease = new Disease { name = diseasesName[i], treatment = diseasesTreatment[i], idUser = user.id };
                    database.openConnection();
                    database.addDisease(disease);
                    database.closeConnection();
                }
                return RedirectToAction("userList");
            }
            catch
            {
                return View();
            }
        }

        [HttpGet]
        public ActionResult userDelete(int identificador)
        {
            ViewBag.ExitoAlBorrar = false;
            database.openConnection();
            database.userDelete(identificador);
            ViewBag.Users = database.userList();
            database.closeConnection();
            return View("userList");
        }

        private int checkPassword(string password)
        {
            int result = -1;

            // Check min length, 8 characters
            if (password.Length >= 8)
            {
                // Check at least 1 digit
                if (Regex.Match(password, @"\d+", RegexOptions.ECMAScript).Success)
                {
                    // Check at least 1 uppercase & 1 lowercase
                    if (Regex.Match(password, @"[a-z]", RegexOptions.ECMAScript).Success &&
                        Regex.Match(password, @"[A-Z]", RegexOptions.ECMAScript).Success)
                    {
                        if (Regex.Match(password, @"[\[\!\\\@\,\#\$\^\%\&\?\_\-\*\+\.\<\>\=\(\)\/\]]", RegexOptions.ECMAScript).Success)
                        {
                            result = 0; // 0 = Success
                        }
                        else
                        {
                            result = 4; // 4 = NoSpecials
                        }
                    }
                    else
                    {
                        result = 3; // 3 = No Uppers or lowers
                    }
                }
                else
                {
                    result = 2; // 2 = No digits
                }
            }
            else
            {
                result = 1; // 1 = No min length
            }

            return result;
        }
    }
}