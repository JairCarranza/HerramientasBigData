using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HerramientasBigData.Models
{
    public class CustomerDto
    {
        public int Identificacion { get; set; }
        public string Nombre { get; set; }
        public string Ciudad { get; set; }
        public string Localidad { get; set; }
        public string Direccion { get; set; }
    }
}