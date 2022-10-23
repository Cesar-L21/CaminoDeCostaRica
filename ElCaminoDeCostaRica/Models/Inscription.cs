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

        [Required(ErrorMessage = "Debe ingresar la fecha")]
        [Range(int.MinValue, int.MaxValue)]
        [Display(Name = "Fecha")]
        public int idDates { get; set; }
    }
}