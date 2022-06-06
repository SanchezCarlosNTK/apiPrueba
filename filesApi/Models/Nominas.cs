using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace filesApi.Models
{
    public class Nominas
    {
        public string ejercicio_fiscal { get; set; }
        public Periodo periodo { get; set; }
        public bool recibo { get; set; }
        public bool cfdi_pdf { get; set; }
        public bool cfdi_xml { get; set; }
    }

    public class Periodo
    {
        public  int id { get; set; }
        public string descripcion { get; set; }
    }
}