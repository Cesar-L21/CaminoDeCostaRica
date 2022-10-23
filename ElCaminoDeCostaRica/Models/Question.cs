using System.ComponentModel.DataAnnotations;
using System;


namespace ElCaminoDeCostaRica.Models
{
    public class Question
    {
        public int id { get; set; }

        [Required(ErrorMessage = "Debe ingresar la encuesta")]
        [Range(int.MinValue, int.MaxValue)]
        [Display(Name = "Encuesta")]
        public int idSurvey { get; set; }

        [Required(ErrorMessage = "Debe ingresar el servicio")]
        [Range(int.MinValue, int.MaxValue)]
        [Display(Name = "Servicio")]
        public int idService { get; set; }

        [Required(ErrorMessage = "Debe ingresar la pregunta")]
        [MaxLength(1000, ErrorMessage = "No puede exceder 1000 caracteres")]
        [MinLength(1, ErrorMessage = "Debe ingresar al menos 1 caracter")]
        [Display(Name = "Pregunta")]
        public string question { get; set; }
    }
}