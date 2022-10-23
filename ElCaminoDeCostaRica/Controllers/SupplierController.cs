using ElCaminoDeCostaRica.Models;
using System.Web.Mvc;

namespace ElCaminoDeCostaRica.Controllers
{
    public class SupplierController : Controller
    {
        Database database = new Database();
        public ActionResult addSupplier()
        {
            return View();
        }

        [HttpPost]
        public ActionResult addSupplier(Supplier supplier)
        {
            ViewBag.Success = false;
            try
            {
                if (ModelState.IsValid)
                {
                    database.openConnection();
                    ViewBag.Success = database.addSupplier(supplier);
                    database.closeConnection();
                    if (ViewBag.Success)
                    {
                        ViewBag.Message = "El proveedor " + supplier.name + " fue creada con exito.";
                        ModelState.Clear();
                    }

                }
                ViewBag.Message = "El proveedor " + supplier.name + " fue creada con exito.";
                return View();
            }
            catch
            {
                ViewBag.Message = "Algo salio mal y no fue posible crear el proveedor.";
                return View();
            }

        }

        public ActionResult supplierList()
        {
            database.openConnection();
            ViewBag.suppliers = database.supplierList();
            database.closeConnection();
            return View();
        }

        [HttpGet]
        public ActionResult supplierDelete(int identificador)
        {
            ViewBag.ExitoAlBorrar = false;
            database.openConnection();
            database.supplierDelete(identificador);
            ViewBag.suppliers = database.supplierList();
            database.closeConnection();
            return View("supplierList");
        }

        [HttpGet]
        public ActionResult supplierEdit(int? identificador)
        {
            ActionResult vista;
            try
            {
                database.openConnection();
                Supplier supplierItem = database.supplierList().Find(smodel => smodel.id == identificador);
                database.closeConnection();
                if (supplierItem == null)
                {
                    vista = RedirectToAction("supplierList");
                }
                else
                {
                    vista = View(supplierItem);
                }
            }
            catch
            {
                vista = RedirectToAction("supplierList");
            }
            return vista;
        }

        [HttpPost]
        public ActionResult supplierEdit(Supplier supplier)
        {
            try
            {
                database.openConnection();
                database.supplierEdit(supplier);
                ViewBag.suppliers = database.supplierList();
                database.closeConnection();
                return RedirectToAction("supplierList");
            }
            catch
            {
                return View();
            }
        }
    }
}