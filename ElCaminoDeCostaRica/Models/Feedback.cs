using System.ComponentModel.DataAnnotations;
using System;

namespace ElCaminoDeCostaRica.Models
{
    public class Feedback
    {
        [Required(ErrorMessage = "Debe ingresar la pregunta")]
        [Range(int.MinValue, int.MaxValue)]
        [Display(Name = "Pregunta")]
        public int idQuestion { get; set; }

        [Required(ErrorMessage = "Debe ingresar la encuesta")]
        [Range(int.MinValue, int.MaxValue)]
        [Display(Name = "Encuesta")]
        public int idSurvey { get; set; }

        [Required(ErrorMessage = "Debe ingresar el servicio")]
        [Range(int.MinValue, int.MaxValue)]
        [Display(Name = "Servicio")]
        public int idService { get; set; }

        [Required(ErrorMessage = "Debe ingresar la calificacion")]
        [Range(int.MinValue, int.MaxValue)]
        [Display(Name = "Calificacion")]
        public int rating { get; set; }

        [MaxLength(1000, ErrorMessage = "No puede exceder 1000 caracteres")]
        [MinLength(1, ErrorMessage = "Debe ingresar al menos 1 caracter")]
        [Display(Name = "Comentario")]
        public string comments { get; set; }

        [Required(ErrorMessage = "Debe ingresar fecha y formato de fecha valida: yyyy-mm-dd")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]

        public DateTime day { get; set; }
    }
}