using System.ComponentModel.DataAnnotations;
using System;

namespace ElCaminoDeCostaRica.Models
{
    public class Disease
    {
        [Required(ErrorMessage = "Debe ingresar la enfermedad")]
        [MaxLength(150, ErrorMessage = "No puede exceder 150 caracteres")]
        [MinLength(2, ErrorMessage = "Debe ingresar al menos 2 caracteres")]
        [Display(Name = "Enfermedad")]
        public string name { get; set; }

        [Required(ErrorMessage = "Debe ingresar el tratamiento")]
        [MaxLength(500, ErrorMessage = "No puede exceder 500 caracteres")]
        [MinLength(2, ErrorMessage = "Debe ingresar al menos 2 caracteres")]
        [Display(Name = "Tratamiento")]
        public string treatment { get; set; }

        [Required(ErrorMessage = "Debe ingresar el usuario")]
        [Range(int.MinValue, int.MaxValue)]
        [Display(Name = "Usuario")]
        public int idUser { get; set; }
    }
}