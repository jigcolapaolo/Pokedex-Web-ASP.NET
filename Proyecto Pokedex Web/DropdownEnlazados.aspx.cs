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
    public partial class DropdownEnlazados : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            PokemonNegocio negocio = new PokemonNegocio();
            ElementoNegocio tipoNegocio = new ElementoNegocio();

            try
            {
                if (!IsPostBack)
                {
                    List<Pokemon> listaPokemon = negocio.listarConSP();
                    List<Elementos> listaElementos = tipoNegocio.listar();

                    ddlPokemonsFiltrados.DataSource = listaPokemon;
                    ddlPokemonsFiltrados.DataTextField = "Nombre";          /*PORQUE SE MUESTRA POKEMON.DOMINIO*/
                    ddlPokemonsFiltrados.DataBind();

                    Session["listaPokemon"] = listaPokemon;             /*GUARDO LA LISTA DE POKEMONS EN SESION PARA USARLA DESPUES*/

                    ddlTipos.DataSource = listaElementos;
                    ddlTipos.DataTextField = "Descripcion";      /*EN EL DROPDOWN SE MOSTRARA LA DESCRIPCION DEL ELEMENTO*/
                    ddlTipos.DataValueField = "Id";             /*PERO AL SELECCIONAR LA DESCRIPCION, EL VALOR EN REALIDAD*/
                    ddlTipos.DataBind();                        /*ES EL ID DE ESE ELEMENTO*/

                }
            }
            catch (Exception ex)
            {

                Session.Add("Error", ex);
            }
        }

        protected void ddlTipos_SelectedIndexChanged(object sender, EventArgs e)
        {
            int id = int.Parse(ddlTipos.SelectedItem.Value);            /*GUARDO EL ID DEL ELEMENTO SELECCIONADO*/
            ddlPokemonsFiltrados.DataSource = ((List<Pokemon>)Session["listaPokemon"]).FindAll(x => x.Tipo.Id == id);
            ddlPokemonsFiltrados.DataBind();            /*PONGO COMO DATASOURCE TODOS LOS POKEMONS QUE TENGAN EL ID DE SU TIPO = AL SELECCIONADO*/
        }
    }
}