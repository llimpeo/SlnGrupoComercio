using CrossCutting.Common;
using System;
using System.Collections.Generic;
using System.Data;

namespace DataAccess
{
    public class DABanco
    {

        private static readonly string[] tableNames = new[] { Constant.Entity.Banco };


        public  bool Exists(string tableName, string indexColumn, string value)
        {
            var existCommand = "SELECT * FROM " + tableName + " WHERE " + indexColumn + " =" + value;
            return SQLHelper.ExecuteNonQuery(existCommand, null) > 1;
        }

        public int Delete(string tableName, string indexColumn, string value)
        {
            var deleteCommand = "DELETE FROM " + tableName + " WHERE " + indexColumn + " =" + value;

            return SQLHelper.ExecuteNonQuery(deleteCommand, null);

        }
        


        public DataSet GetAllBancos()
        {
            DataSet ds = new DataSet();

            return ds;
        }

        public DataSet FindBancosByIdOrName(int id, string descripcion)
        {
            DataSet ds = new DataSet();

            return ds;
        }
        




    }

}