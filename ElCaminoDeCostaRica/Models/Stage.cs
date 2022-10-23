using System.ComponentModel.DataAnnotations;
using System;

namespace ElCaminoDeCostaRica.Models
{
    public class Stage
    {
        public int id { get; set; }

        [Display(Name = "Nombre")]
        [Required(ErrorMessage = "Debe ingresar el nombre")]
        [MaxLength(250, ErrorMessage = "No puede exceder 250 caracteres")]
        [MinLength(1, ErrorMessage = "Debe ingresar al menos 1 caracter")]
        public string name { get; set; }

        [Required(ErrorMessage = "Debe ingresar el inicio")]
        [MaxLength(250, ErrorMessage = "No puede exceder 250 caracteres")]
        [MinLength(1, ErrorMessage = "Debe ingresar al menos 1 caracter")]
        [Display(Name = "Inicio")]
        public string start { get; set; }

        [Required(ErrorMessage = "Debe ingresar el final")]
        [MaxLength(250, ErrorMessage = "No puede exceder 250 caracteres")]
        [MinLength(1, ErrorMessage = "Debe ingresar al menos 1 caracter")]
        [Display(Name = "Final")]
        public string finish { get; set; }

        [Required(ErrorMessage = "Debe ingresar la distancia")]
        [Range(float.MinValue, float.MaxValue)]
        [Display(Name = "Distancia en KM")]
        public float distance { get; set; }

        [Required(ErrorMessage = "Debe ingresar la altimetria minima")]
        [Range(float.MinValue, float.MaxValue)]
        [Display(Name = "Altimetria minima")]
        public float minAltimetry { get; set; }

        [Required(ErrorMessage = "Debe ingresar la altimetria maxima")]
        [Range(float.MinValue, float.MaxValue)]
        [Display(Name = "Altimetria maxima")]
        public float maxAltimetry { get; set; }

        [Required(ErrorMessage = "Debe ingresar la ruta")]
        [Range(int.MinValue, int.MaxValue)]
        [Display(Name = "Ruta")]
        public int idRoute { get; set; }

        [Required(ErrorMessage = "Debe ingresar la seccion")]
        [Range(int.MinValue, int.MaxValue)]
        [Display(Name = "Seccion")]
        public int idSection { get; set; }
    }
}