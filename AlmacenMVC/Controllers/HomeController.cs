using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using AlmacenMVC.Models;
using System.Threading.Tasks;

namespace AlmacenMVC.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            Session.Clear();
            Session.Abandon();
            return View();
        }

        public ActionResult Usuarios()
        {
            return View();
        }

        [HttpPost]
        public async Task<ActionResult> Usuarios(UserLogin datos)
        {
            if (ModelState.IsValid)
            {
                if (datos.login() == true)
                {
                    Session["UserName"] = datos.UserName;
                    Session["Rol"] = datos.Id_Rol;

                    return RedirectToAction("Index","Usuarios");
                }
                else
                {
                    ViewBag.Message = "Error";
                    return View("Index");
                }
                
            }
            else
            {
                return View("Index");
            }
        }

        public ActionResult Registro()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Registro(Usuario datos)
        {
            if (ModelState.IsValid)
            {
                if (datos.Registrar() == false)
                {
                    ViewBag.Message = "El UserName o Correo ya se encuentran Ocupado";
                    return View("Registro", datos);
                }
                else
                {
                    return RedirectToAction("Index", "Home");
                }
            }
            else
            {
                return View("Registro");
            }
            
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}