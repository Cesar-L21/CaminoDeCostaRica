using ElCaminoDeCostaRica.Models;
using System;
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
        public ActionResult postAddSite(Site site)
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
                        ViewBag.Message = "El sitio " + site.id + " fue creado con exito.";
                        ModelState.Clear();
                    }
                }
                return RedirectToAction("addSite", "Site");
            }
            catch
            {
                ViewBag.Message = "Algo salio mal y no fue posible crear el sitio.";
                return RedirectToAction("addSite", "Site");
            }
        }

        [HttpPost]
        public ActionResult postUserAddSite(Site site)
        {
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
                        ViewBag.Message = "El sitio " + site.id + " fue creado con exito.";
                        ModelState.Clear();
                    }
                }
            }
            catch
            {
                ViewBag.Message = "Algo salio mal y no fue posible crear el sitio.";
            }
            return RedirectToAction("userAddSite", "Site");
        }

        public ActionResult userAddSite()
        {
            database.openConnection();
            ViewBag.Users = database.userList();
            database.closeConnection();
            database.openConnection();
            ViewBag.Stages = database.stageList();
            database.closeConnection();
            ViewBag.cookie = HttpContext.Request.Cookies["userLoginInfo"];
            return View();
        }

        public ActionResult siteList()
        {
            database.openConnection();
            ViewBag.sites = database.siteList();
            database.closeConnection();
            return View();
        }

        public ActionResult userSiteList()
        {
            database.openConnection();
            ViewBag.sites = database.userSiteList();
            database.closeConnection();
            return View();
        }

        [HttpGet]
        public ActionResult siteDelete(int identificador)
        {
            ViewBag.ExitoAlBorrar = false;
            database.openConnection();
            database.siteDelete(identificador);
            ViewBag.sites = database.userSiteList();
            database.closeConnection();
            return View("userSiteList");
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

        [HttpPost]
        public String addSiteToFaves(string site)
        {
            String message;
            if (Request.Cookies["userLoginInfo"] != null)
            {
                try
                {
                    dynamic cookie = HttpContext.Request.Cookies["userLoginInfo"];
                    int userID = 0;
                    int siteID = 0;
                    Int32.TryParse(cookie["id"], out userID);
                    Int32.TryParse(site, out siteID);
                    database.openConnection();
                    if (!database.checkSiteOwner(siteID, userID))
                    {
                        if (database.addPublicSite(userID, siteID))
                        {
                            message = "El sitio fue agregado a Mis Sitios";
                        }
                        else
                        {
                            message = "El sitio no pudo ser agregado";   
                        }
                    }
                    else
                    {
                        message = "Este sitio ya está en su repositorio";
                    }
                    database.closeConnection();
                    return message;
                }
                catch
                {
                    message = "No fue posible añadir el sitio a su repositorio";
                    return message;
                }
            }
            else
            {
                message = "Ingrese a su cuenta para agregar este sitio";
                return message;
            }
        }
    }
}
