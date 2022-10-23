using System.Web.Mvc;
using ElCaminoDeCostaRica.Models;

namespace ElCaminoDeCostaRica.Controllers
{
    public class QuestionController : Controller
    {
        Database database = new Database();
        public ActionResult addQuestion()
        {
            database.openConnection();
            ViewBag.Surveys = database.surveyList();
            database.closeConnection();
            database.openConnection();
            ViewBag.Services = database.serviceList();
            database.closeConnection();
            return View();
        }

        [HttpPost]
        public ActionResult addQuestion(Question question)
        {
            database.openConnection();
            ViewBag.Surveys = database.surveyList();
            database.closeConnection();
            database.openConnection();
            ViewBag.Services = database.serviceList();
            database.closeConnection();
            ViewBag.Success = false;
            try
            {
                if (ModelState.IsValid)
                {
                    database.openConnection();
                    ViewBag.Success = database.addQuestion(question);
                    database.closeConnection();
                    if (ViewBag.Success)
                    {
                        ViewBag.Message = "La pregunta fue creada con exito.";
                        ModelState.Clear();
                    }

                }

                return View();
            }
            catch
            {
                ViewBag.Message = "Algo salio mal y no fue posible crear la pregunta.";
                return View();
            }

        }

        public ActionResult questionList()
        {
            database.openConnection();
            ViewBag.questions = database.questionList();
            database.closeConnection();
            return View();
        }

        [HttpGet]
        public ActionResult questionDelete(int identificador)
        {
            ViewBag.ExitoAlBorrar = false;
            database.openConnection();
            database.questionDelete(identificador);
            database.closeConnection();
            database.openConnection();
            ViewBag.questions=database.questionList();
            database.closeConnection();
            return View("questionList");
        }

        [HttpGet]
        public ActionResult questionEdit(int? identificador)
        {
            database.openConnection();
            ViewBag.Surveys = database.surveyList();
            database.closeConnection();
            database.openConnection();
            ViewBag.Services = database.serviceList();
            database.closeConnection();
            ActionResult vista;
            try
            {
                database.openConnection();
                Question questionItem = database.questionList().Find(smodel => smodel.id == identificador);
                database.closeConnection();
                if (questionItem == null)
                {
                    vista = RedirectToAction("questionList");
                }
                else
                {
                    vista = View(questionItem);
                }
            }
            catch
            {
                vista = RedirectToAction("questionList");
            }
            return vista;
        }

        [HttpPost]
        public ActionResult questionEdit(Question question)
        {
            try
            {
                database.openConnection();
                database.questionEdit(question);
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