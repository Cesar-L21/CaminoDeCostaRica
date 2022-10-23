using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace ElCaminoDeCostaRica.Models
{
    public class Section
    {
        public int id { get; set; }

        [Display(Name = "Nombre")]
        [Required(ErrorMessage = "Debe ingresar el nombre")]
        [MaxLength(250, ErrorMessage = "No puede exceder 250 caracteres")]
        [MinLength(1, ErrorMessage = "Debe ingresar al menos 1 caracter")]
        public string name { get; set; }

        [Required(ErrorMessage = "Debe ingresar la ruta")]
        [Range(int.MinValue, int.MaxValue)]
        [Display(Name = "Ruta")]
        public int idRoute { get; set; }
    }
}