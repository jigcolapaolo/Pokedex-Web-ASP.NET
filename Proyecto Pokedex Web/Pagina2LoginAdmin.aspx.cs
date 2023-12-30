using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Dominio;
using Negocio;
using Funciones;

namespace Proyecto_Pokedex_Web
{
    public partial class Pagina2LoginAdmin : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if ((Usuario)Session["usuario"] == null || !Funcion.validarAdmin((Usuario)Session["usuario"]))
            {
                Session.Add("Error", "No te logueaste con cuenta Admin.");
                Response.Redirect("Error.aspx", false);
            }
        }

        protected void btnRegresar_Click(object sender, EventArgs e)
        {
            Response.Redirect("MenuLoginEjemplo1.aspx", false);
        }
    }
}