using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Negocio;
using Dominio;

namespace Proyecto_Pokedex_Web
{
    public partial class Default : System.Web.UI.Page
    {
        public List<Pokemon> ListaPokemon { get; set; }
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {

                if (ListaPokemon == null)
                {
                    PokemonNegocio negocio = new PokemonNegocio();
                    //Session.Add("listaConSP", negocio.listarConSP());
                    ListaPokemon = negocio.listarConSP();

                }
                    repRepeater.DataSource = ListaPokemon;
                    repRepeater.DataBind();

            }
        }

        protected void btnEjemplo_Click(object sender, EventArgs e)
        {
            string valor = ((Button)sender).CommandArgument.ToString();
        }
    }
}