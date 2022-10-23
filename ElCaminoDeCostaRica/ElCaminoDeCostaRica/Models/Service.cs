using System.ComponentModel.DataAnnotations;
using System;

namespace ElCaminoDeCostaRica.Models
{
    public class Service
    {
        public int id { get; set; }

        [Required(ErrorMessage = "Debe ingresar el nombre")]
        [MaxLength(250, ErrorMessage = "No puede exceder 250 caracteres")]
        [MinLength(1, ErrorMessage = "Debe ingresar al menos 1 caracter")]
        [Display(Name = "Nombre")]
        public string name { get; set; }

        [Required(ErrorMessage = "Debe ingresar la descripcion")]
        [MaxLength(500, ErrorMessage = "No puede exceder 500 caracteres")]
        [MinLength(1, ErrorMessage = "Debe ingresar al menos 1 caracter")]
        [Display(Name = "Descripcion")]
        public string description { get; set; }


        [Required(ErrorMessage = "Debe ingresar la categoria")]
        [Range(int.MinValue, int.MaxValue)]
        [Display(Name = "Categoria")]
        public int idCategory { get; set; }

        [Required(ErrorMessage = "Debe ingresar el proveedor")]
        [Range(int.MinValue, int.MaxValue)]
        [Display(Name = "Proveedor")]
        public int idSupplier { get; set; }

        [Required(ErrorMessage = "Debe ingresar la etapa")]
        [Range(int.MinValue, int.MaxValue)]
        [Display(Name = "Etapa")]
        public int idStage { get; set; }
    }
}