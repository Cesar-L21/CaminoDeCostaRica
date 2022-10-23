using ElCaminoDeCostaRica.Models;
using System.Web.Mvc;
using System.Text.RegularExpressions;

namespace ElCaminoDeCostaRica.Controllers
{
    public class InscriptionController : Controller
    {
        Database database = new Database();
        public ActionResult Inscription()
        {
            database.openConnection();
            ViewBag.Users = database.userList();
            database.closeConnection();
            database.openConnection();
            ViewBag.Stages = database.stageList();
            database.closeConnection();
            return View();
        }

        [HttpPost]
        public ActionResult Inscription(Inscription inscription)
        {
            database.openConnection();
            ViewBag.Users = database.userList();
            database.closeConnection();
            database.openConnection();
            ViewBag.Stages = database.stageList();
            database.closeConnection();
            ViewBag.Success = false;
            try
            {
                if (ModelState.IsValid)
                {
                    database.openConnection();

                    // Check user ID
                    if (database.checkID(inscription.idUser))
                    {

                        ViewBag.Success = database.inscription(inscription);
                    }
                    else
                    {
                        ViewBag.Message = "La cedula NO se encuetra registrada!";
                    }

                    database.closeConnection();
                    if (ViewBag.Success)
                    {
                        ViewBag.Message = "El Usuario" + " " + inscription.idUser + " Fue inscrito con exito (:";
                        ModelState.Clear();
                    }

                }

                return View();
            }
            catch
            {
                ViewBag.Message = "Algo salio mal y no fue posible inscribir el Usuario :(";
                return View();
            }

        }

        public ActionResult inscriptionList()
        {
            database.openConnection();
            ViewBag.inscriptions = database.inscriptionList();
            database.closeConnection();
            return View();
        }

        [HttpGet]
        public ActionResult desincription(Inscription inscription)
        {
            ViewBag.ExitoAlBorrar = false;
            database.openConnection();
            database.desinscription(inscription);
            database.closeConnection();
            return View("incriptionList");
        }

        [HttpGet]
        public ActionResult inscriptionEdit(int? identificador)
        {
            database.openConnection();
            ViewBag.Users = database.userList();
            database.closeConnection();
            database.openConnection();
            ViewBag.Stage = database.stageList();
            database.closeConnection();
            ActionResult vista;
            try
            {
                database.openConnection();
                Inscription inscriptionItem = database.inscriptionList().Find(smodel => smodel.idUser == identificador);
                database.closeConnection();
                if (inscriptionItem == null)
                {
                    vista = RedirectToAction("inscriptionList");
                }
                else
                {
                    vista = View(inscriptionItem);
                }
            }
            catch
            {
                vista = RedirectToAction("inscriptionList");
            }
            return vista;
        }

        [HttpPost]
        public ActionResult inscriptionEdit(Inscription inscription)
        {
            try
            {
                database.openConnection();
                database.inscriptionEdit(inscription);
                database.closeConnection();
                return RedirectToAction("Index", "Home");
            }
            catch
            {
                return View();
            }
        }
    }
}