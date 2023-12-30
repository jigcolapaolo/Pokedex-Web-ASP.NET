using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.UI.WebControls;

namespace Funciones
{
    public static class Validacion
    {

        //TEXTBOX NECESITA using System.Web.UI.WebControls;
        public static bool validaTextoVacio(object control)    /*RECIBE EL CONTROL ASP TEXTBOX*/
        {
            if (control is TextBox texto)
            {
                if (string.IsNullOrEmpty(texto.Text))
                    return false;
                else
                    return true;
            }
            return false;
        }
    }
}
