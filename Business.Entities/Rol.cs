using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Business.Entities
{
    public class Rol
    {
        public Rol()
        {
            this.Usuarios = new HashSet<Usuario>();
        }

        [Key]
        public int IdRol { get; set; }
        public string Nombre { get; set; }
        public string RolSistema { get; set; }

        public virtual ICollection<Usuario> Usuarios { get; set; }
    }
}