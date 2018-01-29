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

            if (ViewBag.Usuario == "")
            {
                return RedirectToAction("Index", "Home");
            }
            else
            {
                
                return View(obj.userDatos());
            }
            
        }

        public ActionResult Salir()
        {
            Session.Clear();
            return RedirectToAction("Usuarios", "Index");
        }


        // GET: Usuarios/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Usuarios/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Usuarios/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction("Index");
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

            return View(obj.editDatos(id));
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
            return View();
        }

        // POST: Usuarios/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
