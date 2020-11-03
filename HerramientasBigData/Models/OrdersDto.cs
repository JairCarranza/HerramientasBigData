using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HerramientasBigData.Models
{
    public class OrdersDto
    {
        public string ClientId { get; set; }
        public string Ciudad { get; set; }
        public string localidad { get; set; }
        public string Direccion { get; set; }
    }
}