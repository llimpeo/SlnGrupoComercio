using CrossCutting.Common;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace DataAccess
{
  
        public class DAOrdenPago
        {

            private static readonly string[] tableNames = new[] { Constant.Entity.OrdenPago };


        public DataSet GetAllOrdenPagos()
        {
            DataSet ds = new DataSet();



            return ds;
        }


        public DataSet FindOrdenPagoByIdOrNumber(int idOrdenPago, string numero)
        {
            DataSet ds = new DataSet();

            return ds;
        }

        public DataSet FindOrdenPagoBySucursal(int idSucusal, int idMoneda)
        {
            DataSet ds = new DataSet();
            //Enviar SP a la base de datos retornar DATAset;

            return ds;

        }

    }
}
