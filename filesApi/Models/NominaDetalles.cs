using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace filesApi.Models
{
    public class NominaDetalles
    {
        public string concepto { get; set; }
        public string descripcion { get; set; }
        public double cuota { get; set; }
        public string diasHrs { get; set; }
        public double importe { get; set; }
    }
}