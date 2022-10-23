using System.Web.Mvc;
using ElCaminoDeCostaRica.Models;

namespace ElCaminoDeCostaRica.Controllers
{
    public class FeedbackController : Controller
    {
        Database database = new Database();
        public ActionResult addFeedback()
        {
            database.openConnection();
            ViewBag.Services = database.serviceList();
            database.closeConnection();
            database.openConnection();
            ViewBag.Surveys = database.surveyList();
            database.closeConnection();
            return View();
        }

        [HttpPost]
        public ActionResult addFeedback(Feedback feedback)
        {
            database.openConnection();
            ViewBag.Services = database.serviceList();
            database.closeConnection();
            database.openConnection();
            ViewBag.Surveys = database.surveyList();
            database.closeConnection();
            ViewBag.Success = false;
            try
            {
                if (ModelState.IsValid)
                {
                    database.openConnection();
                    ViewBag.Success = database.addFeedback(feedback);
                    database.closeConnection();
                    if (ViewBag.Success)
                    {
                        ViewBag.Message = "El feedback fue creada con exito.";
                        ModelState.Clear();
                    }

                }

                return View();
            }
            catch
            {
                ViewBag.Message = "Algo salio mal y no fue posible crear el feedback.";
                return View();
            }

        }

        public ActionResult feedbackList()
        {
            database.openConnection();
            ViewBag.feedbacks = database.feedbackList();
            database.closeConnection();
            return View();
        }

        [HttpGet]
        public ActionResult feedbackDelete(int identificador)
        {
<<<<<<< HEAD
=======
            // Que reciba el objeto de tipo feedback
>>>>>>> Cesar
            ViewBag.ExitoAlBorrar = false;
            database.openConnection();
            database.feedbackDelete(identificador);
            database.closeConnection();
            return View("feedbackList");
        }

        [HttpGet]
        public ActionResult feedbackEdit(int? identificador)
        {
            database.openConnection();
            ViewBag.Services = database.serviceList();
            database.closeConnection();
            database.openConnection();
            ViewBag.Surveys = database.surveyList();
            database.closeConnection();
            ActionResult vista;
            try
            {
                database.openConnection();
                Feedback feedbackItem = database.feedbackList().Find(smodel => smodel.idSurvey == identificador);
                database.closeConnection();
                if (feedbackItem == null)
                {
                    vista = RedirectToAction("feedbackList");
                }
                else
                {
                    vista = View(feedbackItem);
                }
            }
            catch
            {
                vista = RedirectToAction("feedbackList");
            }
            return vista;
        }

        [HttpPost]
        public ActionResult feedbackEdit(Feedback feedback)
        {
            try
            {
                database.openConnection();
                database.feedbackEdit(feedback);
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