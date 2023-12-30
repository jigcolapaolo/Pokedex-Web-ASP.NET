using Dominio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Proyecto_Pokedex_Web
{
    public partial class MenuLoginEjemplo1 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["usuario"] == null)     /*VERIFICA SI HAY UN USUARIO LOGUEADO*/
            {
                Session.Add("Error", "Debes loguearte correctamente");
                Response.Redirect("Error.aspx", false);
            }

        }

        protected void btnPagina2Admin_Click(object sender, EventArgs e)
        {
            Response.Redirect("Pagina2LoginAdmin.aspx", false);
        }
    }
}