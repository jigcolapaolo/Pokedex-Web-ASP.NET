using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Dominio;
using Negocio;
using Funciones;
using System.IO;

namespace Proyecto_Pokedex_Web
{
    public partial class MiPerfil : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //LE ASIGNO EL OBJETO TRAINEE SI EL VALOR EN SESION NO ES NULL, SI NO, LE ASIGNO NULL
            Trainee trainee = Session["trainee"] != null ? (Trainee)Session["trainee"] : null;

            //COMPRUEBO SI EL OBJETO TRAINEE ES DIFERENTE A NULO Y EL ID ES DIFERENTE A 0, SI LO SON, DARA TRUE PERO ESTA NEGADO.
            //    ENTONCES SE COMPRUEBA LO CONTRARIO
            if (!(trainee != null && trainee.Id != 0))
            {
                //SI NO HAY UN OBJETO TRAINEE EN SESION Y EL ID ES 0, REDIRIGE HACIA EL LOGIN
                Response.Redirect("Login.aspx", false);

                //ESTO PODRIA HACERLO HACIENDO QUE SE OCULTE MI PERFIL SI NO TENGO UN TRAINEE EN SESION PERO SI SE ESCRIBE LA URL,
                //    SE PUEDE ACCEDER IGUAL, POR ESO ES NECESARIA ESTA PARTE DEL CODIGO.


                //EN FAVORITOS.ASPX SE USA ESTO MISMO PERO CON UN METODO
            }
            else
            {
                if (!IsPostBack)
                {
                    txtEmail.Text = trainee.Email;
                    txtNombre.Text = trainee.Nombre;
                    txtApellido.Text = trainee.Apellido;
                    txtFNacimiento.Text = trainee.FechaNacimiento.ToString("yyyy-MM-dd");



                    //TOMAR LA IMAGEN EN RUTA VIRTUAL
                    string rutaFisica = Server.MapPath("./Images/");
                    string rutaVirtual = rutaFisica.Replace(Server.MapPath("~"), "~/").Replace("\\", "/");

                    //VALIDAR SI SE ENCUENTRA ALGUN ARCHIVO CON "P-" + Trainee.ID + "*.JPG" , SOLO DEBERIA HABER 1
                    //YA QUE SE ELIMINA LA IMAGEN ANTERIOR CADA VEZ QUE SE GUARDA UNA NUEVA, ESTA VALIDACION ES PARA
                    //    QUE COMPRUEBE SI SE BORRO ESE ARCHIVO
                    string criterioBusqueda = "p-" + trainee.Id + "*.jpg";
                    string[] archivosEncontrados = Directory.GetFiles(rutaFisica, criterioBusqueda);

                    if (archivosEncontrados.Length != 0)
                        imgNuevoPerfil.ImageUrl = Funcion.cargarImagenConRuta(rutaVirtual, trainee, imgNuevoPerfil.ImageUrl);
                    else
                        imgNuevoPerfil.ImageUrl = "https://t4.ftcdn.net/jpg/04/73/25/49/360_F_473254957_bxG9yf4ly7OBO5I0O5KABlN930GwaMQz.jpg";





                }

            }



        }

        protected void btnGuardar_Click(object sender, EventArgs e)
        {
            //GUARDAR IMAGEN EN RUTA FISICA
            try
            {
                //EJECUTA TODAS LAS VALIDACIONES DE CONTROLES ASP (Necesita los querys de Global o webconfig)
                Page.Validate();
                if (!Page.IsValid)
                {
                    return;
                }



                TraineeNegocio negocio = new TraineeNegocio();
                //SELECCIONA LA UBICACION EN LA QUE ESTAMOS, SELECCIONA IMAGES Y SE METE DENTRO
                string ruta = Server.MapPath("./Images/");
                Trainee user = (Trainee)Session["trainee"];

                string fecha = DateTime.Now.ToString("ddMMyyyyHHmmss");

                string patronBusqueda = "p-" + user.Id + "*.jpg";
                string[] archivosEncontrados = Directory.GetFiles(ruta, patronBusqueda);


                //SI NO ES NULO EL POSTEDFILE Y EL CONTENIDO ES MAYOR A 0 (TAMAÑO), EJECUTO EL CODIGO
                    //O PODRIA SER txtImagen.PostedFile.FileName == ""
                if (txtImagen.PostedFile != null && txtImagen.PostedFile.ContentLength > 0)
                {
                    //SI ENCUENTRO ARCHIVOS CON P- + user.Id Y QUE TERMINEN CON .JPG, LOS ELIMINO Y LUEGO CARGO EL NUEVO ARCHIVO
                    foreach (string archivo in archivosEncontrados)
                    {
                        File.Delete(archivo);
                    }

                    //GUARDO LA IMAGEN QUE HE SELECCIONADO EN LA RUTA COMPLETA QUE QUEDARIA COMO "./Images/perfil-1.jpg"
                    //TAMBIEN PUEDEN AGREGARSE OTRAS VARIABLES COMO LA FECHA DE CREACION DATETIME.NOW
                    txtImagen.PostedFile.SaveAs(ruta + "p-" + user.Id + fecha + ".jpg");


                    //GUARDO EL NOMBRE DE ESTA IMAGEN COMO IMAGEN DE PERFIL DEL USUARIO
                    user.ImagenPerfil = "p-" + user.Id + fecha + ".jpg";

                }


                user.Email = txtEmail.Text;
                user.Nombre = txtNombre.Text;
                user.Apellido = txtApellido.Text;
                if (!string.IsNullOrEmpty(txtFNacimiento.Text))
                {
                    user.FechaNacimiento = DateTime.Parse(txtFNacimiento.Text);
                }

                negocio.actualizar(user);

                Response.Redirect("Default.aspx", false);
            }
            catch (Exception ex)
            {
                throw ex;
                Session.Add("Error", ex.ToString());
            }
        }
    }
}