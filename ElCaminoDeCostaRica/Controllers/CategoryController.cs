
using System.Web.Mvc;
using ElCaminoDeCostaRica.Models;

namespace ElCaminoDeCostaRica.Controllers
{
    public class CategoryController : Controller
    {
        Database database = new Database();
        public ActionResult addCategory()
        {
            return View();
        }

        [HttpPost]
        public ActionResult addCategory(Category category)
        {
            ViewBag.Success = false;
            try
            {
                if (ModelState.IsValid)
                {
                    database.openConnection();
                    ViewBag.Success = database.addCategory(category);
                    database.closeConnection();
                    if (ViewBag.Success)
                    {
                        ViewBag.Message = "La categoria " + category.id + " fue creada con exito.";
                        ModelState.Clear();
                    }

                }
                ViewBag.Message = "La categoria " + category.name + " fue creada con exito.";
                return View();
            }
            catch
            {
                ViewBag.Message = "Algo salio mal y no fue posible crear la categoria.";
                return View();
            }

        }

        public ActionResult categoryList()
        {
            database.openConnection();
            ViewBag.categories = database.categoryList();
            database.closeConnection();
            return View();
        }

        [HttpGet]
        public ActionResult categoryEdit(int? identificador)
        {
            ActionResult vista;
            try
            {
                database.openConnection();
                Category categoryItem = database.categoryList().Find(smodel => smodel.id == identificador);
                database.closeConnection();
                if (categoryItem == null)
                {
                    vista = RedirectToAction("categoryList");
                }
                else
                {
                    vista = View(categoryItem);
                }
            }
            catch
            {
                vista = RedirectToAction("categoryList");
            }
            return vista;
        }

        [HttpPost]
        public ActionResult categoryEdit(Category category)
        {
            try
            {
                database.openConnection();
                database.categoryEdit(category);
                ViewBag.categories = database.categoryList();
                database.closeConnection();
                return RedirectToAction("categoryList");
            }
            catch
            {
                return View();
            }
        }

        [HttpGet]
        public ActionResult categoryDelete(int identificador)
        {
            ViewBag.ExitoAlBorrar = false;
            database.openConnection();
            database.categoryDelete(identificador);
            database.closeConnection();
            database.openConnection();
            ViewBag.categories = database.categoryList();
            database.closeConnection();
            return View("categoryList");
        }
    }
}
