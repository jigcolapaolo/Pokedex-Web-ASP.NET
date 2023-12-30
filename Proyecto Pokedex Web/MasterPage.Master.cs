using Dominio;
using Funciones;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Proyecto_Pokedex_Web
{
    public partial class MasterPage : System.Web.UI.MasterPage
    {

        //EL PAGE LOAD DE LA MASTER SE EJECUTA SIEMPRE EN EL POSTBACK, ANTES DEL PAGE LOAD DE TODAS LAS OTRAS PAGINAS QUE USEN ESTA 
        //    MASTER PAGE
        protected void Page_Load(object sender, EventArgs e)
        {

            //SI LA PAGINA NO ES DEFAULT NI LOGIN NI REGISTROTRAINEE, REDIRIGE A LOGIN.ASPX, NO PERMITE ACCEDER A LAS OTRAS PAGINAS
            //    HASTA LOGUEARSE

            if (!(Page is Default || Page is Login || Page is RegistroTrainee || Page is Error))
            {

                if (!Seguridad.sesionActiva(Session["trainee"]))
                {
                    /*VALIDACION DE SESION DE TRAINEE ACTIVA COMO EN MI PERFIL PERO CON METODO*/

                    //SI NO HAY UNA SESION ACTIVA, REDIRIGE A LOGIN
                    Response.Redirect("Login.aspx", false);

                }




            }

            //COMPRUEBO SI TENGO UNA SESION ABIERTA PARA CARGAR LA IMAGEN DE PERFIL DE LA BARRA
            if (Seguridad.sesionActiva(Session["trainee"]))
            {
                Trainee trainee = (Trainee)Session["trainee"];

                //TOMAR LA IMAGEN EN RUTA VIRTUAL
                string rutaFisica = Server.MapPath("./Images/");
                string rutaVirtual = rutaFisica.Replace(Server.MapPath("~"), "~/").Replace("\\", "/");

                string criterioBusqueda = "p-" + trainee.Id + "*.jpg";
                string[] archivosEncontrados = Directory.GetFiles(rutaFisica, criterioBusqueda);

                if (archivosEncontrados.Length != 0)
                    imgPerfil.ImageUrl = Funcion.cargarImagenConRuta(rutaVirtual, trainee, imgPerfil.ImageUrl);
                else
                    imgPerfil.ImageUrl = "https://cdn.pixabay.com/photo/2015/10/05/22/37/blank-profile-picture-973460_960_720.png";

                if (string.IsNullOrEmpty(trainee.Nombre))
                    nombreUsuario.Text = trainee.Email;
                else
                    nombreUsuario.Text = trainee.Nombre;


            }


        }

        protected void btnCerrarSesion_Click(object sender, EventArgs e)
        {
            //LIBERO TODA LA INFORMACION DE LA SESION QUE ESTABA ACTIVA.
            Session.Clear();
            Response.Redirect("Login.aspx", false);
        }
    }
}