using CrossCutting.Common;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;


namespace DataAccess
{
    public class DASucursal
    {

        private static readonly string[] tableNames = new[] { Constant.Entity.Sucursal };


        public DataSet GetAllSucursales()
        {
            DataSet ds = new DataSet();

            return ds;
        }

        public DataSet FindSucursalById(int idSucursal, string descripcion)
        {
            DataSet ds = new DataSet();

            return ds;
        }




        public DataSet FindSucursalByIdOrName(int idSucursal, string descripcion)
        {
            DataSet ds = new DataSet();

            return ds;
        }


        public DataSet FindSucursalByIdBanco(int idBanco)
        {
            DataSet ds = new DataSet();

            return ds;
        }



        public DataSet FindAllSucursalByIdBanco(int idBanco)
        {
            DataSet ds = new DataSet();

            //Pasar el store procedure a la base de datos.

            return new DataSet();

        }






    }
}
