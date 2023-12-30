using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Remoting.Channels;
using System.Text;
using System.Threading.Tasks;
using Dominio;

namespace Funciones
{
    public static class Funcion
    {
        public static bool validarAdmin(Usuario usuario)
        {
            try
            {
                if (usuario != null && usuario.TipoUsuario == TipoUsuario.ADMIN)
                {
                    return true;

                }

                return false;

            }
            catch (Exception ex)
            {

                throw ex;
            }

        }   /*FUNCION SOLO PARA USUARIOS, NO TRAINEE*/

        public static string cargarImagenConRuta(string ruta, Trainee user, string imagenDefault)
        {
            
            if (!string.IsNullOrEmpty(user.ImagenPerfil))
            {
                return ruta + user.ImagenPerfil;
            }
            

            return imagenDefault;
        }
    }
}
