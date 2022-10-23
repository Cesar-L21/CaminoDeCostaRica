using ElCaminoDeCostaRica.Models;
using System.Web.Mvc;

namespace ElCaminoDeCostaRica.Controllers
{
    public class ServiceController : Controller
    {
        Database database = new Database();
        public ActionResult addService()
        {
            database.openConnection();
            ViewBag.Suppliers = database.supplierList();
            database.closeConnection();
            database.openConnection();
            ViewBag.Categories = database.categoryList();
            database.closeConnection();
            database.openConnection();
            ViewBag.Stages = database.stageList();
            database.closeConnection();
            return View();
        }

        [HttpPost]
        public ActionResult addService(Service service)
        {
            database.openConnection();
            ViewBag.Suppliers = database.supplierList();
            database.closeConnection();
            database.openConnection();
            ViewBag.Categories = database.categoryList();
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
                    ViewBag.Success = database.addService(service);
                    database.closeConnection();
                    if (ViewBag.Success)
                    {
                        ViewBag.Message = "El servicio " + service.name + " fue creada con exito.";
                        ModelState.Clear();
                    }
                }
                ViewBag.Message = "El servicio " + service.name + " fue creada con exito.";
                return View();
            }
            catch
            {
                ViewBag.Message = "Algo salio mal y no fue posible crear el servicio.";
                return View();
            }
        }

        public ActionResult serviceList()
        {
            database.openConnection();
            ViewBag.services = database.serviceList();
            database.closeConnection();
            database.openConnection();
            ViewBag.cat = database.categoryList();
            database.closeConnection();
            database.openConnection();
            ViewBag.sup = database.supplierList();
            database.closeConnection();
            return View();
        }

        [HttpGet]
        public ActionResult serviceDelete(int identificador)
        {
            ViewBag.ExitoAlBorrar = false;
            database.openConnection();
            database.serviceDelete(identificador);
            ViewBag.services = database.serviceList();
            database.closeConnection();
            return View("serviceList");
        }

        [HttpGet]
        public ActionResult serviceEdit(int? identificador)
        {
            database.openConnection();
            ViewBag.Suppliers = database.supplierList();
            database.closeConnection();
            database.openConnection();
            ViewBag.Categories = database.categoryList();
            database.closeConnection();
            database.openConnection();
            ViewBag.Stages = database.stageList();
            database.closeConnection();
            ActionResult vista;
            try
            {
                database.openConnection();
                Service serviceItem = database.serviceList().Find(smodel => smodel.id == identificador);
                database.closeConnection();
                if (serviceItem == null)
                {
                    vista = RedirectToAction("serviceList");
                }
                else
                {
                    vista = View(serviceItem);
                }
            }
            catch
            {
                vista = RedirectToAction("serviceList");
            }
            return vista;
        }

        [HttpPost]
        public ActionResult serviceEdit(Service service)
        {
            try
            {
                database.openConnection();
                database.serviceEdit(service);
                database.closeConnection();
                database.openConnection();
                ViewBag.Suppliers = database.supplierList();
                database.closeConnection();
                database.openConnection();
                ViewBag.Categories = database.categoryList();
                database.closeConnection();
                database.openConnection();
                ViewBag.Stages = database.stageList();
                database.closeConnection();
                return RedirectToAction("serviceList");
            }
            catch
            {
                return View();
            }
        }
    }
}