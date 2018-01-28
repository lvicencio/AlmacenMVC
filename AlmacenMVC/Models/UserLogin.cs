using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace AlmacenMVC.Models
{
    public class UserLogin
    {
        [EmailAddress]
        [Required(ErrorMessage ="El Correo no es Valido")]
        [Display(Name ="Correo Electronico")]
        public string Email { get; set; }

        [StringLength(100, ErrorMessage = "El Password debe tener maximo 100 caracteres")]
        [Required(ErrorMessage = "El Password es Requerido")]
        [Display(Name = "Contraseña")]
        public string Password { get; set; }

        public string UserName { get; set; }

        public int Id_Rol { get; set; }


        DataAlmacenDataContext db = new DataAlmacenDataContext();

        public  bool login()
        {
            var query = from u in db.Usuarios
                        where u.Email == Email && u.Password == Password
                        select u;
            if (query.Count() > 0)
            {
                var datos = query.ToList();

                foreach (var item in datos)
                {
                    UserName = item.UserName;
                    Id_Rol = item.Id_Rol;
                }
                return true;
            }
            else
            {
                return false;
            }

        }


    }
}