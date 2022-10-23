using ElCaminoDeCostaRica.Models;
using System.Web.Mvc;
using System.Collections.Generic;
using System;

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

                    if (surveyAdded)
                    {
                        database.openConnection();
                        survey.id = database.getSurveyID(survey);
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
            return View("surveyList");
        }

        [HttpGet]
        public ActionResult surveyEdit(int? identificador)
        {
            database.openConnection();
            ViewBag.Categories = database.categoryList();
            database.closeConnection();
            database.openConnection();
            ViewBag.Services = database.serviceList();
            database.closeConnection();
            database.openConnection();
            ViewBag.questions = database.questionList();
            database.closeConnection();
            ActionResult vista;
            try
            {
                database.openConnection();
                Survey surveyItem = database.surveyList().Find(smodel => smodel.id == identificador);
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
                ViewBag.quest = questions;
               // Survey newSurvey = new Survey { version = surveyItem.version + 1, idCategory = surveyItem.idCategory, idService = surveyItem.idService };
   
                //database.openConnection();
                //database.addSurvey(newSurvey);
               // database.closeConnection();
                if (surveyItem == null)
                {

                    vista = RedirectToAction("surveyList");
                }
                else
                {
                    var tuple = new Tuple<Survey, List<Question>>(surveyItem, questions);
                    vista = View(tuple);
                }
            }
            catch
            {
                vista = RedirectToAction("surveyList");
            }
            return vista;
        }

        [HttpPost]
        public ActionResult surveyEdit(FormCollection form)
        {
            database.openConnection();
            ViewBag.Categories = database.categoryList();
            database.closeConnection();
            database.openConnection();
            ViewBag.Services = database.serviceList();
            database.closeConnection();
            //System.Diagnostics.Debug.WriteLine(form["item1.id"]);
            try
            {
               
                database.openConnection();
                ViewBag.questions = database.questionList();
                database.closeConnection();
                Survey newSurvey = new Survey
                {
                    
                    version = Convert.ToInt32(form["item1.version"]) + 1,
                    idCategory = Convert.ToInt32(form["item1.idCategory"]),
                    idService = Convert.ToInt32(form["item1.idService"])
                };
                database.openConnection();
                database.addSurvey(newSurvey);
                database.closeConnection();
                int nuevoId= 0;
                database.openConnection();
                ViewBag.surveys = database.surveyList();
                database.closeConnection();
                foreach (var survey in ViewBag.surveys)
                {
                    nuevoId = survey.id;
                }
                for (int i = 0; i < ViewBag.questions.Count; i++)
                {
                    Question question = new Question
                    {
                        idSurvey = nuevoId,
                        idService = newSurvey.idService,
                        question = form["Item2[" + i + "].question"]
                    };
                    database.openConnection();
                   database.addQuestion(question);
                    database.closeConnection();
                }
                return RedirectToAction("surveyList","Survey");
            }
            catch
            {
                return View();
            }
        }

        [HttpGet]
        public ActionResult Questions(int? identificador)
        {
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
    }
}
