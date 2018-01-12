using System;
using System.Collections.Generic;
using System.Text;
using Business.Entities;
using Microsoft.AspNetCore.Identity;

namespace Domain.Models
{

    public class UsuarioModel : IdentityUser
    {


        public UsuarioModel()
        {
            Roles = new List<Rol>();
            Bancos = new List<Banco>();
            Sucursales = new List<Sucursal>();
            Usuario = new Usuario();
        }

        public Usuario Usuario{get; set;}

        public List<Rol> Roles { get; set; }

        public List<Banco> Bancos { get; set; }
        public List<Sucursal> Sucursales { get; set; }

       public bool Succeeded { get; set; }


    }
}