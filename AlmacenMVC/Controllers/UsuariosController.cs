using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using AlmacenMVC.Models;

namespace AlmacenMVC.Controllers
{
    public class UsuariosController : Controller
    {
        Usuario obj = new Usuario();
        // GET: Usuarios
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
                return View(obj.userDatos());
            }

        }

        public ActionResult Salir()
        {
            Session.Clear();
            Session.Abandon();
            limpiarCahe();
            return RedirectToAction("Index", "Home");
        }


        // GET: Usuarios/Details/5
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
                return View(obj.editDatos(id));
            }

        }

        // GET: Usuarios/Create
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

        // POST: Usuarios/Create
        [HttpPost]
        public ActionResult Create(Usuario model)
        {
            try
            {
                // TODO: Add insert logic here

                if (ModelState.IsValid)
                {
                    if (model.Registrar() == false)
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

        // GET: Usuarios/Edit/5
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
                return View(obj.editDatos(id));
            }


        }

        // POST: Usuarios/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, Usuario model)
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

        // GET: Usuarios/Delete/5
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
                return View(obj.editDatos(id));
            }
        }

        // POST: Usuarios/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, Usuario model)
        {
            try
            {
                if (obj.Borrar(id)== true)
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
