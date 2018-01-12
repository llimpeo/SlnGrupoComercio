using Business.Entities.Search;
using Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Services
{
   public interface  IBCOrdenPago
    {
        OrdenPagoModel FindOrdenesPagoBySucursal(SCOrdenPago ordenPago);

    }
}
