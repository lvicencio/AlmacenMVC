using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace AlmacenMVC.Models
{
    public class Producto
    {
        public int Id_Producto { get; set; }

        [Required(ErrorMessage = "El Nombre es Requerido")]
        [Display(Name = "Nombre")]
        public string  Nombre { get; set; }

        [Required(ErrorMessage = "El Descripcion es Requerido")]
        [Display(Name = "Descripion")]
        public string Descripcion { get; set; }

        [Required(ErrorMessage = "El campo {0} es requerido")]
        [Display(Name = "Precio")]
        [Range(0, double.MaxValue, ErrorMessage = "Debe seleccionar un {0} entre {1} y {2} ")]
        public decimal Precio { get; set; }

        [Required(ErrorMessage = "El campo {0} es requerido")]
        [Display(Name = "Cantidad")]
        [Range(0, Int32.MaxValue, ErrorMessage = "El valor {0} no es válido")]
        public int? Cantidad { get; set; }

        DataAlmacenDataContext db = new DataAlmacenDataContext();
        Productos objProd = new Productos();



        public bool Ingresar()
        {
            var query = from u in db.Productos
                        where u.Nombre == Nombre 
                        select u;
            if (query.Count() > 0)
            {
                return false;
            }
            else
            {
                objProd.Nombre = Nombre;
                objProd.Descripcion = Descripcion;
                objProd.Precio = Precio;
                objProd.Cantidad = Cantidad;
               

                db.Productos.InsertOnSubmit(objProd);
                db.SubmitChanges();
                return true;
            }

        }

        public List<Producto> productoDatos()
        {
            List<Producto> List = new List<Producto>();
            var query = from u in db.Productos select u;
            var listaData = query.ToList();
            foreach (var item in listaData)
            {
                List.Add(new Producto()
                {
                    Id_Producto = item.Id_Producto,
                    Nombre = item.Nombre,
                    Descripcion = item.Descripcion,
                    Precio = item.Precio,
                    Cantidad = item.Cantidad                   
                });
            }

            return List;
        }

        public Producto editProducto(int id)
        {
            Producto datos = db.Productos.Where(x => x.Id_Producto == id).Select(x =>
           new Producto()
           {
               Id_Producto = x.Id_Producto,
               Nombre = x.Nombre,
               Descripcion = x.Descripcion,
               Cantidad = x.Cantidad,
               Precio = x.Precio
           }).SingleOrDefault();

            return datos;
        }

        public bool actualizar(Producto model)
        {
            Productos u = db.Productos.Where(x => x.Id_Producto == model.Id_Producto).Single<Productos>();
            u.Nombre = model.Nombre;
            u.Descripcion = model.Descripcion;
            u.Cantidad = model.Cantidad;
            u.Precio = model.Precio;
            
            db.SubmitChanges();
            return true;
        }


        public bool Borrar(int id)
        {
            Productos u = db.Productos.Where(x => x.Id_Producto == id).Single<Productos>();
            db.Productos.DeleteOnSubmit(u);
            db.SubmitChanges();
            return true;

        }


    }
}