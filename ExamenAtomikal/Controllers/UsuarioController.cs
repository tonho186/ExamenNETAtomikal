using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ExamenAtomikal.Models;

namespace ExamenAtomikal.Controllers
{
    public class UsuarioController : Controller
    {
        // GET: Usuario
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Registro(beUsuario obeUsuario, HttpPostedFileBase Foto)
        {
            brUsuario obrUsuario = new brUsuario();
            if (obeUsuario.Codigo != null)
            {
                List<beUsuario> lbeUsuario = new List<beUsuario>();
                lbeUsuario = obrUsuario.listarUsuarios();
                obrUsuario.guardarUsuario(obeUsuario, lbeUsuario);
                string archivo = Server.MapPath(String.Format("~/Content/{0}.jpg", obeUsuario.Codigo));
                Foto.SaveAs(archivo);
            }
            return View(obeUsuario);
        }

        public ActionResult Lista(beUsuario obeUsuario)
        {
            List<beUsuario> lbeUsuario = new List<beUsuario>();
            brUsuario obrUsuario = new brUsuario();
            lbeUsuario = obrUsuario.listarUsuarios();
            return View(lbeUsuario);
        }
    }
}