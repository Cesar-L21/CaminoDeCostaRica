using ElCaminoDeCostaRica.Models;
using System.Web.Mvc;

namespace ElCaminoDeCostaRica.Controllers
{
    public class SiteController : Controller
    {
        Database database = new Database();
        public ActionResult addSite()
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
        public ActionResult addSite(Site site)
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
                    ViewBag.Success = database.addSite(site);
                    database.closeConnection();
                    if (ViewBag.Success)
                    {
                        ViewBag.Message = "El sitio " + site.id + " fue creada con exito.";
                        ModelState.Clear();
                    }

                }

                return View();
            }
            catch
            {
                ViewBag.Message = "Algo salio mal y no fue posible crear el sitio.";
                return View();
            }

        }

        public ActionResult siteList()
        {
            database.openConnection();
            ViewBag.sites = database.siteList();
            database.closeConnection();
            return View();
        }

        [HttpGet]
        public ActionResult siteDelete(int identificador)
        {
            ViewBag.ExitoAlBorrar = false;
            database.openConnection();
            database.siteDelete(identificador);
            database.closeConnection();
            return View("siteList");
        }

        [HttpGet]
        public ActionResult siteEdit(int? identificador)
        {
            database.openConnection();
            ViewBag.Users = database.userList();
            database.closeConnection();
            database.openConnection();
            ViewBag.Stages = database.stageList();
            database.closeConnection();
            ActionResult vista;
            try
            {
                database.openConnection();
                Site siteItem = database.siteList().Find(smodel => smodel.id == identificador);
                database.closeConnection();
                if (siteItem == null)
                {
                    vista = RedirectToAction("siteList");
                }
                else
                {
                    vista = View(siteItem);
                }
            }
            catch
            {
                vista = RedirectToAction("siteList");
            }
            return vista;
        }

        [HttpPost]
        public ActionResult siteEdit(Site site)
        {
            try
            {
                database.openConnection();
                database.siteEdit(site);
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