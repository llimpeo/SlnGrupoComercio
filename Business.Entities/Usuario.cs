using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Business.Entities
{
public partial class Usuario : IdentityUser
{
    public Usuario()
    {
   }

    [Key]
    public int IdUsuario { get; set; }
    public string CuentaUsuario { get; set; }
    public string Clave { get; set; }
    public Nullable<int> IdRol { get; set; }
    
}
}
