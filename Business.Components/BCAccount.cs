using AutoMapper;
using Business.Entities;
using Business.Services;
using CrossCutting.Common;
using DataAccess;
using Domain.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace Business.Components
{
    public class BCAccount: IBCAccount
    {

        DAAccount DataAccess = new DAAccount();

        public UsuarioModel Usuario(LoginModel user)
        {

            DataSet ds = null;
            try
            {
                ds = DataAccess.GetUsuario(user.UserName, user.Password);
                var usuario = Mapper.Map<IDataReader, List<Usuario>>(ds.Tables[Constant.Entity.Usuario].CreateDataReader());
                var bancos = Mapper.Map<IDataReader, List<Banco>>(ds.Tables[Constant.Entity.Banco].CreateDataReader());
                var sucursales = Mapper.Map<IDataReader, List<Sucursal>>(ds.Tables[Constant.Entity.Sucursal].CreateDataReader());
                var roles = Mapper.Map<IDataReader, List<Rol>>(ds.Tables[Constant.Entity.Rol].CreateDataReader());

                return new UsuarioModel() { Usuario= usuario.FirstOrDefault(), Bancos=bancos, Sucursales=sucursales, Roles=roles };

            }
            catch (Exception ex)
            {
                throw;
            }








        }







    }
}
