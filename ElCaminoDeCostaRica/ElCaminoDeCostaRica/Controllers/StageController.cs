using ElCaminoDeCostaRica.Models;
<<<<<<< HEAD
=======
using System;
>>>>>>> Cesar
using System.Web.Mvc;

namespace ElCaminoDeCostaRica.Controllers
{
    public class StageController : Controller
    {
        Database database = new Database();
        public ActionResult addStage()
        {
            database.openConnection();
            ViewBag.Data = database.routeList();
            database.closeConnection();

            return View();
        }

        [HttpPost]
        public ActionResult addStage(Stage stage)
        {
            database.openConnection();
            ViewBag.Data = database.routeList();
            database.closeConnection();

            ViewBag.Success = false;
            try
            {
                if (ModelState.IsValid)
                {
                    database.openConnection();
                    ViewBag.Success = database.addStage(stage);
                    database.closeConnection();
                    if (ViewBag.Success)
                    {
                        ViewBag.Message = "La etapa " + stage.id + " fue creada con exito.";
                        ModelState.Clear();
                    }

                }

                return View();
            }
            catch
            {
                ViewBag.Message = "Algo salio mal y no fue posible crear la etapa.";
                return View();
            }

        }

        public ActionResult stageList()
        {
            database.openConnection();
            ViewBag.stages = database.stageList();
            database.closeConnection();
            return View();
        }

        [HttpGet]
        public ActionResult stageDelete(int identificador)
        {
            ViewBag.ExitoAlBorrar = false;
            database.openConnection();
            database.stageDelete(identificador);
            ViewBag.stages = database.stageList();
            database.closeConnection();
            return View("stageList");
        }

        [HttpGet]
        public ActionResult stageEdit(int? identificador)
        {
            database.openConnection();
            ViewBag.Data = database.routeList();
            database.closeConnection();
            ActionResult vista;
            try
            {
                database.openConnection();
                Stage stageItem = database.stageList().Find(smodel => smodel.id == identificador);
                database.closeConnection();
                if (stageItem == null)
                {
                    vista = RedirectToAction("stageList");
                }
                else
                {
                    vista = View(stageItem);
                }
            }
            catch
            {
                vista = RedirectToAction("stageList");
            }
            return vista;
        }

        [HttpPost]
        public ActionResult stageEdit(Stage stage)
        {
            try
            {
                database.openConnection();
                database.stageEdit(stage);
<<<<<<< HEAD
                database.closeConnection();
                return RedirectToAction("Index", "Home");
=======
                ViewBag.stages = database.stageList();
                database.closeConnection();
                return RedirectToAction("stageList");
>>>>>>> Cesar
            }
            catch
            {
                return View();
            }
        }
<<<<<<< HEAD
=======

        public ActionResult Inscription(int? identificador)
        {
            bool addInscription = true;
            Inscription newInscription = new Inscription { idUser = 123456, idStage = Convert.ToInt32(identificador) };
            database.openConnection();
            ViewBag.inscriptions = database.inscriptionList();
            database.closeConnection();
            foreach (var inscription in ViewBag.inscriptions)
            {
                if (inscription.idUser == newInscription.idUser && inscription.idStage== newInscription.idStage) 
                {
                    ViewBag.Message = "Algo salio mal y no fue posible inscribirse.";
                    
                    addInscription = false;
                }
            }
            if (addInscription)
            {
                database.openConnection();
                ViewBag.Data = database.inscription(newInscription);
                database.closeConnection();
            }   
            database.openConnection();
            ViewBag.stages = database.stageList();
            database.closeConnection();
            return View("stageList");
        }
>>>>>>> Cesar
    }
}