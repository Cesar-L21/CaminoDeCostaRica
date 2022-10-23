using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace ElCaminoDeCostaRica.Models
{
    public class StageDates
    {
        public int id { get; set; }

        [Required(ErrorMessage = "Debe ingresar fecha y formato de fecha valida: yyyy-mm-dd")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]

        public DateTime date { get; set; }

        [Required(ErrorMessage = "Debe ingresar la capacidad de cupos")]
        [Range(int.MinValue, int.MaxValue)]
        [Display(Name = "Cupos")]
        public int capacity { get; set; }

        public string code { get; set; }

        [Required(ErrorMessage = "Debe ingresar la etapa")]
        [Range(int.MinValue, int.MaxValue)]
        [Display(Name = "Etapa")]
        public int idStage { get; set; }
    }
}