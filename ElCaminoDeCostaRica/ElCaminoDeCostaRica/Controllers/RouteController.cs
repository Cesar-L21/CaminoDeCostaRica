using ElCaminoDeCostaRica.Models;
<<<<<<< HEAD
=======
using System;
>>>>>>> Cesar
using System.Web.Mvc;

namespace ElCaminoDeCostaRica.Controllers
{
    public class RouteController : Controller
    {
        Database database = new Database();
        public ActionResult addRoute()
        {
            return View();
        }

        [HttpPost]
        public ActionResult addRoute(Route route)
        {
            ViewBag.Success = false;
            try
            {
                if (ModelState.IsValid)
                {
                    database.openConnection();
                    ViewBag.Success = database.addRoute(route);
                    database.closeConnection();
                    if (ViewBag.Success)
                    {
                        ViewBag.Message = "La ruta " + route.id + " fue creada con exito.";
                        ModelState.Clear();
                    }
                }
                ViewBag.Message = "La ruta " + route.id + " fue creada con exito.";
                return View();
            }
            catch
            {
                ViewBag.Message = "Algo salio mal y no fue posible crear la ruta.";
                return View();
            }

        }

        public ActionResult routeList()
        {
            database.openConnection();
            ViewBag.routes = database.routeList();
            database.closeConnection();
            return View();
        }

        [HttpGet]
        public ActionResult routeDelete(int identificador)
        {
            ViewBag.ExitoAlBorrar = false;
            database.openConnection();
            database.routeDelete(identificador);
            ViewBag.routes = database.routeList();
            database.closeConnection();
            return View("routeList");
        }

        [HttpGet]
        public ActionResult routeEdit(int? identificador)
        {

            ActionResult vista;
            try
            {
                database.openConnection();
                Route routeItem = database.routeList().Find(smodel => smodel.id == identificador);
                database.closeConnection();
                if (routeItem == null)
                {
                    vista = RedirectToAction("routeList");
                }
                else
                {
                    vista = View(routeItem);
                }
            }
            catch
            {
                vista = RedirectToAction("routeList");
            }
            return vista;
        }

        [HttpPost]
        public ActionResult routeEdit(Route route)
        {
            try
            {
                database.openConnection();
                database.routeEdit(route);
                ViewBag.routes = database.routeList();
                database.closeConnection();
                return RedirectToAction("routeList");
            }
            catch
            {
                return View();
            }
        }

        // GET: /Route/ 
        public ActionResult Index()
        {
            database.openConnection();
            ViewBag.routeInfo = database.routeList();
<<<<<<< HEAD
            ViewBag.pathInfo = database.getPathInfo();
            ViewBag.placeInfo = database.getPlaceInfo();
            database.closeConnection();
            return View();
        }
=======
            database.closeConnection();
            database.openConnection();
            ViewBag.pathInfo = database.getPathInfo();
            database.closeConnection();
            database.openConnection();
            ViewBag.placeInfo = database.getPlaceInfo();
            database.closeConnection();
            database.openConnection();
            ViewBag.stageInfo = database.stageList();
            database.closeConnection();
            return View();
        }
        [HttpGet]
        public ActionResult Inscription(string identificador)
        {
            bool addInscription = true;
            System.Diagnostics.Debug.WriteLine(identificador);
            Inscription newInscription = new Inscription { idUser = 123456, idStage = Convert.ToInt32(form["stageSelector"]) };
            database.openConnection();
            ViewBag.inscriptions = database.inscriptionList();
            database.closeConnection();
            foreach (var inscription in ViewBag.inscriptions)
            {
                if (inscription.idUser == newInscription.idUser && inscription.idStage == newInscription.idStage)
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