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

namespace Business.Components
{
    public class BCSucursal: IBCSucursal

    {
        DASucursal DASucursal = new DASucursal();



        public SucursalModel FindAllSucursalByIdBanco(int idBanco)
        {

            DataSet ds = null;
            try
            {
                ds = DASucursal.FindAllSucursalByIdBanco(idBanco);
                var results = Mapper.Map<IDataReader, List<Sucursal>>(ds.Tables[Constant.Entity.Sucursal].CreateDataReader());

                return new SucursalModel() { Sucursales = results };

            }
            catch (Exception ex)
            {
                throw;
            }
         
        }



    }
}
