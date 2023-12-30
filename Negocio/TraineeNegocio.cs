using System;
using System.Collections.Generic;
using System.Data.SqlTypes;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dominio;

namespace Negocio
{
    public class TraineeNegocio
    {
        public void actualizar(Trainee user)
        {
            AccesoDatos datos = new AccesoDatos();
            try
            {

                //user.ImagenPerfil = "perfil-" + user.Id + ".jpg";
                //user.Email = txtEmail.Text;
                //user.Nombre = txtNombre.Text;
                //user.Apellido = txtApellido.Text;
                //user.FechaNacimiento = DateTime.Parse(txtFNacimiento.Text);



                datos.setearConsulta("UPDATE USERS SET email = @email, nombre = @nombre, apellido = @apellido, fechaNacimiento = @fechaNacimiento, imagenPerfil = @imagenPerfil WHERE id = @id");
                datos.setearParametros("@email", user.Email);
                datos.setearParametros("@nombre", user.Nombre);
                datos.setearParametros("@apellido", user.Apellido);
                if (user.FechaNacimiento >= SqlDateTime.MinValue.Value)      /*COMPRUEBO SI LA FECHA ES MAYOR O IGUAL AL MENOR VALOR QUE PUEDE TENER UNA FECHA EN SQL*/
                    datos.setearParametros("@fechaNacimiento", user.FechaNacimiento);
                else
                    datos.setearParametros("@fechaNacimiento", DBNull.Value);   /*LE DOY UN VALOR NULL EN LA BASE DE DATOS*/

                //SI ESTO LO HAGO EN OPERADOR TERNARIO, DEBO HACER CASTEO EN (object)DBNull.Value
                if (!string.IsNullOrEmpty(user.ImagenPerfil))
                    datos.setearParametros("@imagenPerfil", user.ImagenPerfil);
                else
                    datos.setearParametros("@imagenPerfil", DBNull.Value); 
                datos.setearParametros("@id", user.Id); ;


                datos.ejecutarAccion();


            }
            catch (Exception ex)
            {

                throw ex;
            }
            finally
            {
                datos.cerrarConexion();
            }
        }

        //id
        //email             DATOS QUE TENGO
        //pass
        //admin false

        //nombre, apellido, fecha, imagen


        /*INSERTARNUEVO TOMA EL EMAIL Y EL PASS INGRESADO PARA CREAR UN USUARIO EN LA DB,*/
        //AL CREARLO, SE LE ASIGNA UNA ID Y CON EL OUTPUT SQL SE EXTRAE ESA MISMA ID.


        //PARA REGISTRARSE
        public int insertarNuevo(Trainee nuevo)
        {
            AccesoDatos datos = new AccesoDatos();
            try
            {
                datos.setearProcedimiento("insertarNuevo");
                datos.setearParametros("@email", nuevo.Email);
                datos.setearParametros("@pass", nuevo.Pass);

                return datos.ejecutarAccionScalar();


            }
            catch (Exception ex)
            {

                throw ex;
            }
            finally
            {
                datos.cerrarConexion();
            }


        }

        //PARA LOGUEARSE

        public bool Login(Trainee trainee)
        {
            AccesoDatos datos = new AccesoDatos();
            try
            {
                datos.setearConsulta("SELECT id, email, pass, nombre, apellido, fechaNacimiento, admin, imagenPerfil FROM USERS WHERE email = @email AND pass = @pass");
                datos.setearParametros("@email", trainee.Email);
                datos.setearParametros("@pass", trainee.Pass);

                datos.ejecutarLectura();
                while (datos.Lector.Read())
                {
                    trainee.Id = (int)datos.Lector["id"];
                    trainee.Admin = (bool)datos.Lector["admin"];
                    trainee.Nombre = datos.Lector["nombre"].ToString();
                    trainee.Apellido = datos.Lector["apellido"].ToString();
                    if (datos.Lector["fechaNacimiento"] != DBNull.Value)
                    {
                        trainee.FechaNacimiento = (DateTime)datos.Lector["fechaNacimiento"];
                    }
                    trainee.ImagenPerfil = datos.Lector["imagenPerfil"].ToString();

                    return true;
                }
                return false;
            }
            catch (Exception ex)
            {

                throw ex;
            }
            finally
            {
                datos.cerrarConexion();
            }
        }

    }
}
