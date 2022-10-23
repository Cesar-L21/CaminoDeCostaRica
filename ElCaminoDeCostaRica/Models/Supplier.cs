using System.ComponentModel.DataAnnotations;
using System;

namespace ElCaminoDeCostaRica.Models
{
    public class Supplier
    {
        public int id { get; set; }

        [Required(ErrorMessage = "Debe ingresar el nombre")]
        [MaxLength(250, ErrorMessage = "No puede exceder 250 caracteres")]
        [MinLength(1, ErrorMessage = "Debe ingresar al menos 1 caracter")]
        [Display(Name = "Nombre")]
        public string name { get; set; }

        [Required(ErrorMessage = "Debe ingresar la latitud")]
        [Range(-180, 180)]
        [Display(Name = "Longitud")]
        public float longitude { get; set; }

        [Required(ErrorMessage = "Debe ingresar la longitud")]
        [Range(-90, 90)]
        [Display(Name = "Latitud")]
        public float latitude { get; set; }

        [Required(ErrorMessage = "Debe ingresar el correo electrónico")]
        [Display(Name = "Correo Electrónico")]
        [DataType(DataType.EmailAddress)]
        [EmailAddress(ErrorMessage = "Formato inválido de email")]
        public string email { get; set; }

        [Required(ErrorMessage = "Debe digitar el teléfono")]
        [Display(Name = "Teléfono")]
        [DataType(DataType.PhoneNumber)]
        public int phone { get; set; }
    }
}