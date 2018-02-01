using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using AlmacenMVC.Models;

namespace AlmacenMVC.Controllers
{
    public class ProductosController : Controller
    {
        Producto obj = new Producto();

        // GET: Productos
        public ActionResult Index()
        {
            ViewBag.Usuario = Session["UserName"];
            ViewBag.Rol = Session["Rol"];

            if (ViewBag.Usuario == null)
            {
                limpiarCahe();
                return RedirectToAction("Index", "Home");
            }
            else
            {
                limpiarCahe();
                return View(obj.productoDatos());
            }

            
        }

        // GET: Productos/Details/5
        public ActionResult Details(int id)
        {
            ViewBag.Usuario = Session["UserName"];
            ViewBag.Rol = Session["Rol"];

            if (ViewBag.Usuario == null)
            {
                return RedirectToAction("Index", "Home");
            }
            else
            {
                limpiarCahe();
                return View(obj.editProducto(id));
            }
        }

        // GET: Productos/Create
        public ActionResult Create()
        {
            ViewBag.Usuario = Session["UserName"];
            ViewBag.Rol = Session["Rol"];

            if (ViewBag.Usuario == null)
            {
                return RedirectToAction("Index", "Home");
            }
            else
            {
                limpiarCahe();
                return View();
            }
        }

        // POST: Productos/Create
        [HttpPost]
        public ActionResult Create(Producto model)
        {
            try
            {
                // TODO: Add insert logic here

                if (ModelState.IsValid)
                {
                    if (model.Ingresar() == false)
                    {
                        ViewBag.Message = "El UserName o Correo ya se encuentran Ocupado";
                        return View("Create", model);
                    }
                    else
                    {
                        return RedirectToAction("Index");
                    }
                }
                else
                {
                    return View("Create");
                }
            }
            catch
            {
                return View();
            }
        }

        // GET: Productos/Edit/5
        public ActionResult Edit(int id)
        {
            ViewBag.Usuario = Session["UserName"];
            ViewBag.Rol = Session["Rol"];

            if (ViewBag.Usuario == null)
            {
                return RedirectToAction("Index", "Home");
            }
            else
            {
                limpiarCahe();
                return View(obj.editProducto(id));
            }

        }

        // POST: Productos/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, Producto model)
        {
            try
            {
                if (obj.actualizar(model) == true)
                {
                    return RedirectToAction("Index");
                }
                else
                {
                    return View(model);
                }

            }
            catch
            {
                return View();
            }
        }

        // GET: Productos/Delete/5
        public ActionResult Delete(int id)
        {
            ViewBag.Usuario = Session["UserName"];
            ViewBag.Rol = Session["Rol"];

            if (ViewBag.Usuario == null)
            {
                return RedirectToAction("Index", "Home");
            }
            else
            {
                limpiarCahe();
                return View(obj.editProducto(id));
            }
        }

        // POST: Productos/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, Producto model)
        {
            try
            {
                if (obj.Borrar(id) == true)
                {
                    return RedirectToAction("Index");
                }

                else
                {
                    return View(model);
                }
            }
            catch
            {
                return View();
            }
        }


        public void limpiarCahe()
        {
            Response.Cache.SetCacheability(HttpCacheability.ServerAndNoCache);
            Response.Cache.SetAllowResponseInBrowserHistory(false);
            Response.Cache.SetNoStore();
        }


    }
}
