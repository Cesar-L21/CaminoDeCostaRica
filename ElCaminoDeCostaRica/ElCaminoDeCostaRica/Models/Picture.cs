using System.ComponentModel.DataAnnotations;
using System;

namespace ElCaminoDeCostaRica.Models
{
    public class Picture
    {
        public int id { get; set; }

        [Required(ErrorMessage = "Debe ingresar la foto")]
        [MaxLength(250, ErrorMessage = "No puede exceder 250 caracteres")]
        [MinLength(1, ErrorMessage = "Debe ingresar al menos 1 caracter")]
        [Display(Name = "Foto")]
        public string picture { get; set; }

        [MaxLength(250, ErrorMessage = "No puede exceder 250 caracteres")]
        [MinLength(1, ErrorMessage = "Debe ingresar al menos 1 caracter")]
        [Display(Name = "Descripcion")]
        public string caption { get; set; }

        [Range(int.MinValue, int.MaxValue)]
        [Display(Name = "Sitio")]
        public int idSite { get; set; }

        [Range(int.MinValue, int.MaxValue)]
        [Display(Name = "Etapa")]
        public int idStage { get; set; }
    }
}