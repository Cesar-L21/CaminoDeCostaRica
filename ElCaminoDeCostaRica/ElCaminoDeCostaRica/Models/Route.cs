using System.ComponentModel.DataAnnotations;
using System;
namespace ElCaminoDeCostaRica.Models
{
    public class Route
    {
        public int id { get; set; }

<<<<<<< HEAD
=======
        [MaxLength(250, ErrorMessage = "No puede exceder 250 caracteres")]
        [MinLength(1, ErrorMessage = "Debe ingresar al menos 1 caracter")]
        [Display(Name = "Nombre")]
        public string name { get; set; }

>>>>>>> Cesar
        [Required(ErrorMessage = "Debe ingresar el inicio")]
        [MaxLength(250, ErrorMessage = "No puede exceder 250 caracteres")]
        [MinLength(1, ErrorMessage = "Debe ingresar al menos 1 caracter")]
        [Display(Name = "Punto de inicio")]
        public string start { get; set; }

        [Required(ErrorMessage = "Debe ingresar el final")]
        [MaxLength(250, ErrorMessage = "No puede exceder 250 caracteres")]
        [MinLength(1, ErrorMessage = "Debe ingresar al menos 1 caracter")]
        [Display(Name = "Punto final")]
        public string finish { get; set; }

        [Required(ErrorMessage = "Debe ingresar la distancia")]
        [Range(float.MinValue, float.MaxValue)]
        [Display(Name = "Distancia en KM")]
        public float distance { get; set; }
    }
}