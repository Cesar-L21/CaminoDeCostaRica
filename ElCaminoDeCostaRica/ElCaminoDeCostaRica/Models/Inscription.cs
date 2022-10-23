using System.ComponentModel.DataAnnotations;
using System;


namespace ElCaminoDeCostaRica.Models
{
    public class Inscription
    {
        [Required(ErrorMessage = "Debe ingresar el usuario")]
        [Range(int.MinValue, int.MaxValue)]
        [Display(Name = "Usuario")]
        public int idUser { get; set; }

        [Required(ErrorMessage = "Debe ingresar la etapa")]
        [Range(int.MinValue, int.MaxValue)]
        [Display(Name = "Etapa")]
        public int idStage { get; set; }

<<<<<<< HEAD
        [Required(ErrorMessage = "Debe ingresar fecha y formato de fecha valida: yyyy-mm-dd")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime date { get; set; }

        [Required(ErrorMessage = "Debe ingresar el codigo")]
        [MaxLength(10, ErrorMessage = "No puede exceder 10 caracteres")]
        [MinLength(1, ErrorMessage = "Debe ingresar al menos 1 caracter")]
        [Display(Name = "Codigo")]
        public string code { get; set; }
=======
        [Required(ErrorMessage = "Debe ingresar la fecha")]
        [Range(int.MinValue, int.MaxValue)]
        [Display(Name = "Fecha")]
        public int idDates { get; set; }
>>>>>>> Cesar
    }
}