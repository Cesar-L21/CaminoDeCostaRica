using System.ComponentModel.DataAnnotations;
using System.Web;

namespace ElCaminoDeCostaRica.Models
{
    public class Site
    {
        public int id { get; set; }

        [Required(ErrorMessage = "Debe ingresar el nombre")]
        [MaxLength(250, ErrorMessage = "No puede exceder 250 caracteres")]
        [MinLength(1, ErrorMessage = "Debe ingresar al menos 1 caracter")]
        [Display(Name = "Nombre")]
        public string name { get; set; }

        [MaxLength(500, ErrorMessage = "No puede exceder 500 caracteres")]
        [MinLength(1, ErrorMessage = "Debe ingresar al menos 1 caracter")]
        [Display(Name = "Descripcion")]
        public string description { get; set; }

        [Required(ErrorMessage = "Debe ingresar la longitud")]
        [Range(-180, 180)]
        [Display(Name = "Longitud")]
        public float longitude { get; set; }

        [Required(ErrorMessage = "Debe ingresar la latitud")]
        [Range(-90, 90)]
        [Display(Name = "Latitud")]
        public float latitude { get; set; }

        [Required(ErrorMessage = "Debe ingresar el usuario")]
        [Range(int.MinValue, int.MaxValue)]
        [Display(Name = "Usuario")]
        public int idUser { get; set; }

        [Required(ErrorMessage = "Debe ingresar la etapa")]
        [Range(int.MinValue, int.MaxValue)]
        [Display(Name = "Etapa")]
        public int idStage { get; set; }

        [Required(ErrorMessage = "Debe ingresar la foto")]
        [Display(Name = "Ingrese su foto")]
        public HttpPostedFileBase archive { get; set; }

        //define the type of the picture
        public string typeArchive { get; set; }

        public byte [] img { get; set; }

        [MaxLength(250, ErrorMessage = "No puede exceder 250 caracteres")]
        [MinLength(1, ErrorMessage = "Debe ingresar al menos 1 caracter")]
        [Display(Name = "Descripcion")]
        public string caption { get; set; }
    }
}

