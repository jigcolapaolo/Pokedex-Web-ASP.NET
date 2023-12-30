using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Proyecto_Pokedex_Web
{
    public partial class Error : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["Error"] != null)
            {
                lblMensaje.Text = Session["Error"].ToString();
            }
            else
            {
                Response.Redirect("Default.aspx", false);
            }
        }
    }
}