using Business.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Models
{
    public class SucursalModel
    {
        public SucursalModel()
        {
            Sucursales = new List<Sucursal>();
        }

        public List<Sucursal> Sucursales { get; set;}

    }
}
