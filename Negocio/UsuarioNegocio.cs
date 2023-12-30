using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Dominio;

namespace Negocio
{
    public class UsuarioNegocio
    {
        public bool Loguear(Usuario usuario)
        {
            AccesoDatos datos = new AccesoDatos();

            try
            {
                datos.setearConsulta("SELECT Id, Usuario, Pass, TipoUser FROM USUARIOS WHERE Usuario = @user AND Pass = @pass");
                datos.setearParametros("@user", usuario.User);
                datos.setearParametros("@pass", usuario.Pass);

                datos.ejecutarLectura();
                while (datos.Lector.Read())
                {
                    //COMPLETO LOS DATOS QUE FALTAN DEL USUARIO CON LOS DATOS DE LA DB,
                    //YA TENGO EL USER Y EL PASS EXTRAIDOS DE LA PAGINA DE LOGUEO
                    usuario.Id = (int)datos.Lector["Id"];
                    usuario.TipoUsuario = (int)datos.Lector["TipoUser"] == 2 ? TipoUsuario.ADMIN : TipoUsuario.NORMAL;
                    //REEMPLAZA EL DATO BOOL ADMIN QUE TENIA POR LOS DATOS CORRECTOS DE LA DB


                    return true;        /*SI ENCUENTRA AL USUARIO, VALIDA CON UN TRUE*/
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
