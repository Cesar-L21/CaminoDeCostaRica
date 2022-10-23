using System.ComponentModel.DataAnnotations;
using System.Web;

namespace ElCaminoDeCostaRica.Models
{
    public class Picture
    {
        public int id { get; set; }
        
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

        [Required(ErrorMessage = "Debe ingresar la foto")]
        [Display(Name = "Ingrese su foto")]
        public HttpPostedFileBase archive { get; set; }

        //define the type of the picture
        public string typeArchive { get; set; }

        public byte[] img { get; set; }

    }
}