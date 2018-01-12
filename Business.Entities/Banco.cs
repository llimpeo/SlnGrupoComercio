using System;
using System.Collections.Generic;

namespace Business.Entities
{
    public class Banco
    {

        public Banco()
        {
            Sucursales = new HashSet<Sucursal>();
        }

        public int IdBanco { get; set; }
       public string Nombre { get; set; }
        public string Direccion { get; set; }
        public DateTime FechaRegistro { get; set; }

        public virtual ICollection<Sucursal> Sucursales { get; set; }

    }
}
