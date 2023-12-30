using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Dominio;
using Negocio;

namespace Proyecto_Pokedex_Web
{
    public partial class RegistroTrainee : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["trainee"] != null)
            {
                Session.Add("Error", "Ya estas logueado");
                Response.Redirect("Error.aspx", false);
            }
        }

        protected void btnRegistrarse_Click(object sender, EventArgs e)
        {
            try
            {
                Trainee user = new Trainee();
                TraineeNegocio traineeNegocio = new TraineeNegocio();
                EmailService emailService = new EmailService();

                user.Email = txtEmail.Text;
                user.Pass = txtPassword.Text;
                user.Id = traineeNegocio.insertarNuevo(user);      /*INSERTARNUEVO TOMA EL EMAIL Y EL PASS INGRESADO PARA CREAR UN USUARIO EN LA DB,*/

                //AUTOLOGIN
                Session.Add("trainee", user);

                //AL CREARLO, SE LE ASIGNA UNA ID Y CON EL OUTPUT SQL SE EXTRAE ESA MISMA ID.
                emailService.armarCorreo(user.Email, "Bienvenida Trainee", "Hola! Te damos la bienvenida a la aplicación!");
                emailService.enviarMail();

                

                Response.Redirect("Default.aspx", false);
            
            }
            catch (Exception ex)
            {

                Session.Add("Error", ex.ToString());
            }
        }
    }
}