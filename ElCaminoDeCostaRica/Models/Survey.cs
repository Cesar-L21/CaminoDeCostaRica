using System.ComponentModel.DataAnnotations;
using System;


namespace ElCaminoDeCostaRica.Models
{
    public class Survey
    {
        public int id { get; set; }

        [Required(ErrorMessage = "Debe ingresar la version")]
        [Range(int.MinValue, int.MaxValue)]
        [Display(Name = "Version")]
        public int version { get; set; }

        [Required(ErrorMessage = "Debe ingresar la categoria")]
        [Range(int.MinValue, int.MaxValue)]
        [Display(Name = "Categoria")]
        public int idCategory { get; set; }

        [Required(ErrorMessage = "Debe ingresar el servicio")]
        [Range(int.MinValue, int.MaxValue)]
        [Display(Name = "Servicio")]
        public int idService { get; set; }

    }
}