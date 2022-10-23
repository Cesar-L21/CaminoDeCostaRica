using ElCaminoDeCostaRica.Models;
using System.Web.Mvc;
using System.Collections.Generic;
<<<<<<< HEAD
=======
using System;
>>>>>>> Cesar

namespace ElCaminoDeCostaRica.Controllers
{
    public class SurveyController : Controller
    {
        Database database = new Database();
        public ActionResult addSurvey()
        {
            database.openConnection();
            ViewBag.Categories = database.categoryList();
            database.closeConnection();
            database.openConnection();
            ViewBag.Services = database.serviceList();
            database.closeConnection();
            return View();
        }

        [HttpPost]
        public ActionResult addSurvey(Survey survey, FormCollection form)
        {
            database.openConnection();
            ViewBag.Categories = database.categoryList();
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
                    bool surveyAdded = database.addSurvey(survey);
                    database.closeConnection();
<<<<<<< HEAD
                    
                    if (surveyAdded)
                    {
                        database.openConnection();
                        survey.id = database.getSurveyID(survey.day);
=======

                    if (surveyAdded)
                    {
                        database.openConnection();
                        survey.id = database.getSurveyID(survey);
>>>>>>> Cesar
                        database.closeConnection();
                        for (int index = 1; index < 6; ++index)
                        {
                            var question = form["numero" + index];
                            if (!string.IsNullOrEmpty(question.ToString()))
                            {
                                Question questions = new Question { idSurvey = survey.id, idService = survey.idService, question = question };
                                database.openConnection();
                                ViewBag.Success = database.addQuestion(questions);
                                database.closeConnection();
                            }
                        }
                    }
                }
                if (ViewBag.Success)
                {
                    ViewBag.Message = "La encuesta " + survey.id + " fue creada con exito.";
                    ModelState.Clear();
                }
                return View();
            }
            catch
            {
                ViewBag.Message = "Algo salio mal y no fue posible crear la encuesta.";
                return View();
            }
        }

        public ActionResult surveyList()
        {
            database.openConnection();
            ViewBag.surveys = database.surveyList();
            database.closeConnection();
            database.openConnection();
            ViewBag.cat = database.categoryList();
            database.closeConnection();
            database.openConnection();
            ViewBag.ser = database.serviceList();
            database.closeConnection();
            return View();
        }

        [HttpGet]
        public ActionResult surveyDelete(int identificador)
        {
            ViewBag.ExitoAlBorrar = false;
            database.openConnection();
            database.surveyDelete(identificador);
<<<<<<< HEAD
            ViewBag.surveys = database.surveyList();
            database.closeConnection();
=======
            database.closeConnection();
            database.openConnection();
            ViewBag.surveys = database.surveyList();
            database.closeConnection();
            database.openConnection();
            ViewBag.cat = database.categoryList();
            database.closeConnection();
            database.openConnection();
            ViewBag.ser = database.serviceList();
            database.closeConnection();
>>>>>>> Cesar
            return View("surveyList");
        }

        [HttpGet]
<<<<<<< HEAD
        public ActionResult surveyEdit(int? identificador)
=======
        public ActionResult surveyEdit(int? identificador, FormCollection form)
>>>>>>> Cesar
        {
            database.openConnection();
            ViewBag.Categories = database.categoryList();
            database.closeConnection();
            database.openConnection();
            ViewBag.Services = database.serviceList();
            database.closeConnection();
            ActionResult vista;
            try
            {
                database.openConnection();
                Survey surveyItem = database.surveyList().Find(smodel => smodel.id == identificador);
                database.closeConnection();
<<<<<<< HEAD
                Survey newSurvey = new Survey { version = surveyItem.version + 1, idCategory = surveyItem.idCategory, idService = surveyItem.idService, day = surveyItem.day };
=======
                database.openConnection();
                ViewBag.questions = database.questionList();
                database.closeConnection();
                Question item = new Question();
                List<Question> questions = new List<Question>();
                foreach (var question in ViewBag.questions)
                {
                    if (question.idSurvey == surveyItem.id)
                    {
                        questions.Add(question);
                    }
                }
                //database.openConnection();
                //Question questionItem = database.questionList().Find(smodel => smodel.idSurvey == identificador);
                //database.closeConnection();
                Survey newSurvey = new Survey { version = surveyItem.version + 1, idCategory = surveyItem.idCategory, idService = surveyItem.idService };
   
>>>>>>> Cesar
                database.openConnection();
                database.addSurvey(newSurvey);
                database.closeConnection();
                if (surveyItem == null)
                {

                    vista = RedirectToAction("surveyList");
                }
                else
                {
<<<<<<< HEAD
                    vista = View(surveyItem);
=======
                    var tuple = new Tuple<Survey, List<Question>>(surveyItem, questions);
                    vista = View(tuple);
>>>>>>> Cesar
                }
            }
            catch
            {
                vista = RedirectToAction("surveyList");
            }
            return vista;
        }

        [HttpPost]
<<<<<<< HEAD
        public ActionResult surveyEdit(Survey survey)
        {
            try
            {
                database.openConnection();
                database.surveyEdit(survey);
                database.closeConnection();
=======
        public ActionResult surveyEdit(FormCollection form)
        {
            //System.Diagnostics.Debug.WriteLine(form["Item2[1].question"]);
            Survey newSurvey = new Survey
            {
                id = Convert.ToInt32(form["Item1.id"]),
                version = Convert.ToInt32(form["Item1.version"]),
                idCategory = Convert.ToInt32(form["Item1.idCategory"]),
                idService = Convert.ToInt32(form["Item1.idService"])

            };

            try
            {
                database.openConnection();
                ViewBag.Categories = database.categoryList();
                database.closeConnection();
                database.openConnection();
                ViewBag.Services = database.serviceList();
                database.closeConnection();
                database.openConnection();
                database.surveyEdit(newSurvey);
                database.closeConnection();
                database.openConnection();
                ViewBag.questions = database.questionList();
                database.closeConnection();
                List<Question> questions = new List<Question>();
                for (int i = 0; i < ViewBag.questions.Count; i++)
                {
                    Question question = new Question
                    {
                       id = Convert.ToInt32(form["Item2[" + i + "].id"] +1 ),
                        idSurvey = newSurvey.id,
                        idService = newSurvey.idService,
                        question = form["Item2[" + i + "].question"]
                    };
                    System.Diagnostics.Debug.WriteLine(form["Item2[" + i + "].question"]);
                    database.openConnection();
                    database.questionEdit(question);
                    database.closeConnection();
                }

>>>>>>> Cesar
                return RedirectToAction("Index", "Home");
            }
            catch
            {
                return View();
            }
        }
<<<<<<< HEAD
=======

        [HttpGet]
        public ActionResult Questions(int? identificador)
        {

            /*  database.openConnection();
              ViewBag.cat = database.categoryList();
              database.closeConnection();
              database.openConnection();
              ViewBag.ser = database.serviceList();
              database.closeConnection();*/
            ActionResult vista;
            try
            {
                database.openConnection();
                ViewBag.surveys = database.surveyList().Find(smodel => smodel.id == identificador);
                database.closeConnection();
                database.openConnection();
                Survey surveyItem = database.surveyList().Find(smodel => smodel.id == identificador);
                database.closeConnection();
                database.openConnection();
                ViewBag.questions = database.questionList();
                database.closeConnection();
                if (surveyItem == null)
                {
                    vista = RedirectToAction("surveyList");
                }
                else
                {
                    vista = View(surveyItem);
                }

            }
            catch
            {
                return RedirectToAction("surveyList");
            }
            return View();
        }

        [HttpPost]
        public ActionResult Questions(Survey survey, FormCollection form)
        {
            database.openConnection();
            ViewBag.questions = database.questionList();
            database.closeConnection();
            database.openConnection();
            ViewBag.cat = database.categoryList();
            database.closeConnection();
            database.openConnection();
            ViewBag.ser = database.serviceList();
            database.closeConnection();

            try
            {
                int count = 0;
                foreach (var question in ViewBag.questions)
                {
                    if (question.idSurvey == survey.id)
                    {
                        Feedback feedback = new Feedback { idQuestion = question.id, idSurvey = survey.id, idService=survey.idService, rating = Convert.ToInt32(form["Calificacion" + count]), comments = Convert.ToString(form["Comentarios"]), day = DateTime.Today };
                        database.openConnection();
                        database.addFeedback(feedback);
                        database.closeConnection();
                        count = +1;
                    }

                }
            }
            catch
            {
                return RedirectToAction("surveyList");
            }
            database.openConnection();
            ViewBag.surveys = database.surveyList();
            database.closeConnection();
            return View("surveyList");
        }
>>>>>>> Cesar
    }
}
