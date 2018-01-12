using AutoMapper;
using Business.Entities;
using Business.Entities.Search;
using Business.Services;
using CrossCutting.Common;
using DataAccess;
using Domain.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace Business.Components
{
   public class BCOrdenPago: IBCOrdenPago
    {


        DAOrdenPago DAOrdenPago = new DAOrdenPago();
  

        public OrdenPagoModel FindOrdenesPagoBySucursal(SCOrdenPago ordenPago)
        {
            DataSet ds = null;
            try
            {
                ds = DAOrdenPago.FindOrdenPagoBySucursal(ordenPago.IdSucursal, ordenPago.IdMoneda);
                var results = Mapper.Map<IDataReader, List<OrdenPago>>(ds.Tables[Constant.Entity.OrdenPago].CreateDataReader());

                return new OrdenPagoModel() { OrdenesPago=results } ;

            }
            catch (Exception ex)
            {
                    throw;
            }
                 

        }

    }
}
