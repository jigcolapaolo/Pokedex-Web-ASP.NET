using Dominio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Negocio;
using Funciones;

namespace Proyecto_Pokedex_Web
{
    public partial class LoginEjemplo1 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
          
        }

        protected void btnIngresar_Click(object sender, EventArgs e)
        {
            try
            {

                //CONSTRUCTOR, EL FALSE SE LO DECLARO MANUALMENTE, ESTE VALOR CAMBIARA CUANDO RECORRA LA DB Y APLIQUE EL VALOR REAL
                Usuario usuario = new Usuario(txtUser.Text, txtPassword.Text, false);
                UsuarioNegocio negocio = new UsuarioNegocio();
                negocio.Loguear(usuario);

                if (negocio.Loguear(usuario))
                {
                    Session.Add("usuario", usuario);
                    Response.Redirect("MenuLoginEjemplo1.aspx", false);
                }
                else
                {
                    Session.Add("Error", "User o Pass incorrectos.");
                    Response.Redirect("Error.aspx", false);
                }



            }
            catch (Exception ex)
            {

                Session.Add("Error", ex.ToString());
                Response.Redirect("Error.aspx", false);
            }
        }
    }
}