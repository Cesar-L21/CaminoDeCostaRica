using System.Web.Mvc;
using ElCaminoDeCostaRica.Models;
using System.Text;

namespace ElCaminoDeCostaRica.Controllers
{
    public class PictureController : Controller
    {
        Database database = new Database();
        public ActionResult addPicture()
        {
            database.openConnection();
            ViewBag.Sites = database.siteList();
            database.closeConnection();
            database.openConnection();
            ViewBag.Stages = database.stageList();
            database.closeConnection();
            return View();
        }

        [HttpPost]
        public ActionResult addPicture(Picture picture)
        {

            database.openConnection();
            ViewBag.Sites = database.siteList();
            database.closeConnection();
            database.openConnection();
            ViewBag.Stages = database.stageList();
            database.closeConnection();
            ViewBag.Success = false;
            var errors = ModelState.Values;
            try
            {
                if (ModelState.IsValid)
                {
                    database.openConnection();
                    ViewBag.Success = database.addPicture(picture);
                    database.closeConnection();
                    if (ViewBag.Success)
                    {
                        ViewBag.Message = "La foto fue agregada con exito.";
                        ModelState.Clear();
                    }

                }

                return View();
            }
            catch
            {
                ViewBag.Message = "Algo salio mal y no fue posible agregar la foto.";
                return View();
            }

        }

        public ActionResult pictureList()
        {
            database.openConnection();
            ViewBag.pictures = database.pictureList();
            database.closeConnection();
            return View();
        }

        [HttpGet]
        public ActionResult pictureDelete(int identificador)
        {
            ViewBag.ExitoAlBorrar = false;
            database.openConnection();
            database.pictureDelete(identificador);
            database.closeConnection();
            return View("pictureList");
        }
        [HttpGet]
        public ActionResult pictureEdit(int? identificador)
        {
            database.openConnection();
            ViewBag.Sites = database.siteList();
            database.closeConnection();
            database.openConnection();
            ViewBag.Stages = database.stageList();
            database.closeConnection();
            ActionResult vista;
            try
            {
                database.openConnection();
                Picture pictureItem = database.pictureList().Find(smodel => smodel.id == identificador);
                database.closeConnection();
                if (pictureItem == null)
                {
                    vista = RedirectToAction("pictureList");
                }
                else
                {
                    vista = View(pictureItem);
                }
            }
            catch
            {
                vista = RedirectToAction("pictureList");
            }
            return vista;
        }

        [HttpPost]
        public ActionResult pictureEdit(Picture picture)
        {
            try
            {
                database.openConnection();
                database.pictureEdit(picture);
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