using Dominio;
using Negocio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Funciones;
using System.Threading;

namespace Proyecto_Pokedex_Web
{
    public partial class Login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["trainee"] != null)
            {
                Session.Add("Error", "Ya estas logueado");
                Response.Redirect("Error.aspx", false);
            }
        }

        protected void btnIngresar_Click(object sender, EventArgs e)
        {
            Trainee trainee = new Trainee();
            TraineeNegocio traineeNegocio = new TraineeNegocio();

            try
            {

                if (!Validacion.validaTextoVacio(txtEmail) || !Validacion.validaTextoVacio(txtPassword))
                {
                    Session.Add("Error", "Debes completar ambos campos");
                    Response.Redirect("Error.aspx");
                }

                
                trainee.Email = txtEmail.Text;
                trainee.Pass = txtPassword.Text;


                if (traineeNegocio.Login(trainee))          /*DEVUELVE UN BOOL Y TAMBIEN LE AGREGA EL ID EL ADMIN AL OBJETO TRAINEE*/
                {
                    Session.Add("trainee", trainee);
                    Response.Redirect("MiPerfil.aspx", false);
                }
                else
                {
                    Session.Add("Error", "User o Password incorrectos.");
                    Response.Redirect("Error.aspx", false);
                }

            }
            catch (System.Threading.ThreadAbortException ex) { }
            catch (Exception ex)
            {

                Session.Add("Error", ex.ToString());
            }
        }


        //MANEJO DE ERRORES GENERICO EN ESTA PAGINA LOGIN
        private void Page_Error(object sender, EventArgs e)
        {
            Exception exc = Server.GetLastError();

            Session.Add("Error", exc.ToString());
            Server.Transfer("Error.aspx");
        }
    }
}