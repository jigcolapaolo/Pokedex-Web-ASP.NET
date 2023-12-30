using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace Dominio
{
    public enum TipoUsuario         /*ESPECIE DE CLASE QUE USA LOS VALORES NORMAL Y ADMIN*/
    {                               /*TIPO ENTERO*/
        NORMAL = 1,
        ADMIN = 2
    }
    public class Usuario
    {
        public int Id { get; set; }
        public string User { get; set; }
        public string Pass { get; set; }
        public TipoUsuario TipoUsuario { get; set; }

        public Usuario(string user, string pass, bool admin) /*CONSTRUCTOR*/
        {
            User = user;
            Pass = pass;
            TipoUsuario = admin ? TipoUsuario.ADMIN : TipoUsuario.NORMAL;
            //SI ADMIN ESTA EN TRUE, EL TIPOUSUARIO SERA 2, SI NO, SERA 1
        }

    }
}
