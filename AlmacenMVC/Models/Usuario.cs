using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace AlmacenMVC.Models
{
    public class Usuario
    {
        public int Id_User { get; set; }

        [Required(ErrorMessage = "El Nombre no es Valido")]
        [Display(Name = "Nombre")]
        public string Nombre { get; set; }

        [Required(ErrorMessage = "El Apellido no es Valido")]
        [Display(Name = "Apellido")]
        public string Apellido { get; set; }

        [Required(ErrorMessage = "El UserName no es Valido")]
        [Display(Name = "UserName")]
        public string UserName { get; set; }

        [EmailAddress]
        [Required(ErrorMessage = "El Correo no es Valido")]
        [Display(Name = "Correo Electronico")]
        public string Email { get; set; }

        [StringLength(100, ErrorMessage = "El Password debe tener maximo 100 caracteres")]
        [Required(ErrorMessage = "El Password es Requerido")]
        [Display(Name = "Contraseña")]
        public string Password { get; set; }

        public int Id_Rol { get; set; }



        DataAlmacenDataContext db = new DataAlmacenDataContext();
        Usuarios objUser = new Usuarios();  //instancio la clase usuarios de la db

        //varifica si ya existe el username o correo
        public bool Registrar()
        {
            var query = from u in db.Usuarios
                        where u.Email == Email ||
                        u.UserName == UserName
                        select u;
            if (query.Count() > 0)
            {
                return false;
            }
            else
            {
                objUser.Nombre = Nombre;
                objUser.Apellido = Apellido;
                objUser.UserName = UserName;
                objUser.Email = Email;
                objUser.Password = Password;
                objUser.Id_Rol = Id_Rol;

                db.Usuarios.InsertOnSubmit(objUser);
                db.SubmitChanges();
                return true;
            }

        }

        public List<Usuario> userDatos()
        {
            List<Usuario> List = new List<Usuario>();
            var query = from u in db.Usuarios select u;
            var listaData = query.ToList();
            foreach (var item in listaData)
            {
                List.Add(new Usuario()
                {
                    Id_User = item.Id_User,
                    Nombre = item.Nombre,
                    Apellido = item.Apellido,
                    UserName = item.UserName,
                    Email = item.Email,
                    Password = item.Password,
                    Id_Rol = item.Id_Rol
                });
            }

            return List;
        }

        public  Usuario editDatos(int id)
        {
            Usuario datos = db.Usuarios.Where(x => x.Id_User == id).Select(x =>
           new Usuario()
           {
               Id_User = x.Id_User,
               Nombre = x.Nombre,
               Apellido = x.Apellido,
               UserName = x.UserName,
               Email = x.Email,
               Password = x.Password,
               Id_Rol = x.Id_Rol
           }).SingleOrDefault();

            return datos;
        }

        public bool actualizar(Usuario model)
        {
            Usuarios u = db.Usuarios.Where(x => x.Id_User == model.Id_User).Single<Usuarios>();
            u.Nombre = model.Nombre;
            u.Apellido = model.Apellido;
            u.UserName = model.UserName;
            u.Email = model.Email;
            u.Password = model.Password;
            u.Id_Rol = model.Id_Rol;

            db.SubmitChanges();
            return true;
        }



    }
}