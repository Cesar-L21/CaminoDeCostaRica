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

<<<<<<< HEAD
        [Required(ErrorMessage = "Debe ingresar fecha y formato de fecha valida: yyyy-mm-dd")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime day { get; set; }


=======
>>>>>>> Cesar
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