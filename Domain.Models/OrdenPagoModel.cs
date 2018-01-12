using Business.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Models
{
   public class OrdenPagoModel
    {

        public OrdenPagoModel()
        {
            OrdenesPago = new List<OrdenPago>();
        }

        public List<OrdenPago> OrdenesPago { get; set; }





    }
}
