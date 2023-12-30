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
    public partial class DropdownEjemplos : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            PokemonNegocio negocio = new PokemonNegocio();

            try   /*VALIDACION*/
            {
                if (!IsPostBack)
                {
                    //DROPDOWN CON DB
                    ddlPokemons.DataSource = negocio.listarConSP();
                    ddlPokemons.DataTextField = "Nombre";
                    ddlPokemons.DataBind();
                }
            }
            catch (Exception ex)
            {

                Session.Add("Error", ex);      /*EL ERROR SE GUARDA EN SESION*/
            }
        }
    }
}