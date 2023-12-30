using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Proyecto_Pokedex_Web
{
    public partial class ImagenRapido : System.Web.UI.Page
    {
        public string UrlImagen { get; set; }
        protected void Page_Load(object sender, EventArgs e)
        {
            
        }

        protected void btnCargar_Click(object sender, EventArgs e)
        {
            UrlImagen = txtUrlImagen.Text;
        }
    }
}