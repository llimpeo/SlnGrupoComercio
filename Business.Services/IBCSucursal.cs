using Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Services
{
  public  interface IBCSucursal
    {
        SucursalModel FindAllSucursalByIdBanco(int idBanco);


    }
}
