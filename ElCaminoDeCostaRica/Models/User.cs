
using System.ComponentModel.DataAnnotations;

namespace ElCaminoDeCostaRica.Models
{
    public class User
    {
        [Required(ErrorMessage = "Debe ingresar la identificación")]
        [Display(Name = "Identificación")]
        public int id { get; set; }

        [Required(ErrorMessage = "Debe ingresar el nombre")]
        [MaxLength(50, ErrorMessage = "No puede exceder 50 caracteres")]
        [MinLength(3, ErrorMessage = "Debe ingresar al menos 3 caracteres")]
        [Display(Name = "Nombre")]
        public string firstName { get; set; }

        [Required(ErrorMessage = "Debe ingresar el apellido")]
        [MaxLength(50, ErrorMessage = "No puede exceder 50 caracteres")]
        [MinLength(2, ErrorMessage = "Debe ingresar al menos 2 caracteres")]
        [Display(Name = "Apellido")]
        public string lastName { get; set; }

        [Required(ErrorMessage = "Debe ingresar el correo electrónico")]
        [Display(Name = "Correo Electrónico")]
        [DataType(DataType.EmailAddress)]
        [EmailAddress(ErrorMessage = "Formato inválido de email")]
        public string email { get; set; }

        [Required(ErrorMessage = "Debe digitar el teléfono")]
        [Display(Name = "Teléfono")]
        [DataType(DataType.PhoneNumber)]
        public int phone { get; set; }

        public int userType { get; set; }

        [Required(ErrorMessage = "Debe digitar la contraseña")]
        [Display(Name = "Contraseña")]
        [DataType(DataType.Password)]
        public string password { get; set; }

        [Required(ErrorMessage = "Debe confirmar la contraseña")]
        [Display(Name = "Confirmar contraseña")]
        [DataType(DataType.Password)]
        [Compare("password", ErrorMessage = "Las contraseñas con coinciden")]
        public string confirmPassword { get; set; }

        [Display(Name = "Especifique")]
        public string disability { get; set; }

    }
}
