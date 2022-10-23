using System.ComponentModel.DataAnnotations;
using System;

namespace ElCaminoDeCostaRica.Models
{
    public class Category
    {
        public int id { get; set; }

        [Required(ErrorMessage = "Debe ingresar el nombre")]
        [MaxLength(50, ErrorMessage = "No puede exceder 50 caracteres")]
        [MinLength(1, ErrorMessage = "Debe ingresar al menos 1 caracter")]
        [Display(Name = "Nombre")]
        public string name { get; set; }
    }
}