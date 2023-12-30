using Dominio;
using System;
using System.Collections.Generic;
using System.Diagnostics.Eventing.Reader;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Funciones
{
    public static class Seguridad
    {
        public static bool sesionActiva(object user)            /*PARA QUE RECIBA CUALQUIER OBJETO / OBJETO GENERICO*/
        {
            Trainee trainee = user != null ? (Trainee)user : null;

            if ((trainee != null && trainee.Id != 0))
            {
                return true;
            }
            else
            {
                return false;

            }
        }

        public static bool isAdmin(object user)
        {
            Trainee trainee = user != null ? (Trainee)user : null;

            return trainee != null ? trainee.Admin : false;
        }
    }
}
