using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Web;

namespace ExamenAtomikal.Models
{
    [Serializable]
    public class beUsuario
    {
        public string Codigo { get; set; }
        public string Nombre { get; set; }
        public string Correo { get; set; }
        public string Password { get; set; }
    }

    public class brUsuario
    {

        public List<beUsuario> listarUsuarios()
        {
            string archivo = HttpContext.Current.Server.MapPath("~/Content/Usuarios.txt");
            List<beUsuario> lbeUsuario = new List<beUsuario>();
            if (System.IO.File.Exists(archivo))
            {
                using (System.IO.FileStream fs = new System.IO.FileStream(archivo, System.IO.FileMode.Open, System.IO.FileAccess.Read, System.IO.FileShare.Read))
                {
                    BinaryFormatter bf = new BinaryFormatter();
                    lbeUsuario = (List<beUsuario>)bf.Deserialize(fs);
                }
            }
            return (lbeUsuario);
        }

        public void guardarUsuario(beUsuario obeUsuario, List<beUsuario> lbeUsuario)
        {
            string archivo = HttpContext.Current.Server.MapPath("Content/Usuarios.txt");
            lbeUsuario.Add(obeUsuario);
            using (System.IO.FileStream fs = new System.IO.FileStream(archivo, System.IO.FileMode.Create, System.IO.FileAccess.Write, System.IO.FileShare.Write))
            {
                BinaryFormatter bf = new BinaryFormatter();
                bf.Serialize(fs, lbeUsuario);
            }
        }

        public static string obtenerUrlImagen(string codigo)
        {
            string archivo = HttpContext.Current.Server.MapPath(String.Format("../Content/{0}.jpg", codigo));
            string Url = String.Format("../Content/{0}.jpg", codigo);
            if (!System.IO.File.Exists(archivo))
            {
                Url = "../Content/No.jpg";
            }
            return (Url);
        }
    }
}