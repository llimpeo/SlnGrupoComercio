using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Entities
{
    public class OrdenPago
    {

        public int IdOrdenPago {get; set;}
       public decimal? monto { get; set; }
        public string Moneda { get; set; }
        public string Estado { get; set; }
        public DateTime FechaPago { get; set; }

    }
}
