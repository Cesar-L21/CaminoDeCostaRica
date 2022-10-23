using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ElCaminoDeCostaRica.Models
{
    public class Coordinate
    {
        public double latitude { get; set; }
        public double longitude { get; set; }
        public int sequence { get; set; }
        public string name { get; set; }
        public string description { get; set; }
        public int id_stage { get; set; }
        public int id_route { get; set; }
    }
}