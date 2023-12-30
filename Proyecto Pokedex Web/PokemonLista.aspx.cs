using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Negocio;
using Dominio;
using System.Drawing;
using Funciones;

namespace Proyecto_Pokedex_Web
{
    public partial class PokemonLista : System.Web.UI.Page
    {
        public bool FiltroAvanzado { get; set; }
        protected void Page_Load(object sender, EventArgs e)
        {

            //SI TENGO UNA SESION ACTIVA PERO NO ES ADMIN, NO DEJO INGRESAR A LA PAGINA POKEMONLISTA
            if (!Seguridad.isAdmin(Session["trainee"]))
            {
                Session.Add("Error", "No tiene permisos de Admin.");
                Response.Redirect("Error.aspx", false);
            }



            //if (ListaPokemon == null)
            //{
            //PokemonNegocio negocio = new PokemonNegocio();
            //Session.Add("listaConSP", negocio.listarConSP());
            //    ListaPokemon = negocio.listarConSP();
            //}

            FiltroAvanzado = chkFiltroAvanzado.Checked;      /*SI LO DEJO EN FALSE, SE CERRARA CADA VEZ QUE SE ACTUALICE LA PAGINA*/



            if (!IsPostBack)
            {
                PokemonNegocio negocio = new PokemonNegocio();
                Session.Add("lista", negocio.listarConSP());
                dgvPokemons.DataSource = Session["lista"];   /*ESTOS 4 DEBEN ESTAR ASI PARA QUE FUNCIONE EL PAGINATION*/
                dgvPokemons.DataBind();

                ListItem campoPreseleccionado = ddlCampo.Items.FindByText("Nombre");
                campoPreseleccionado.Selected = true;

                if (ddlCampo.SelectedItem.ToString() == "Nombre")
                {
                    ddlCriterio.Items.Add("Contiene..");
                    ddlCriterio.Items.Add("Empieza con..");
                    ddlCriterio.Items.Add("Termina con..");
                }
            }
        }

        protected void btnAgregar_Click(object sender, EventArgs e)
        {
            Response.Redirect("FormularioPokemon.aspx", false);
        }

        protected void dgvPokemons_SelectedIndexChanged(object sender, EventArgs e)
        {
            string id = dgvPokemons.SelectedDataKey.Value.ToString();           /*AL CAMBIAR DE DATA KEY AL CLICKEAR EL EMOJI EN ACCION, GUARDA EL ID DE LA FILA SELECCIONADA*/
            Response.Redirect("FormularioPokemon.aspx?id=" + id, false);        /*ENVIA EL ID A FORMULARIO POKEMON*/
        }


        //PAGINATION 
        protected void dgvPokemons_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            dgvPokemons.DataSource = Session["lista"];
            dgvPokemons.PageIndex = e.NewPageIndex; /*Establece el índice de página de la GridView(dgvPokemons) al nuevo valor*/
            //proporcionado en e.NewPageIndex.


            dgvPokemons.DataBind();              /*Vuelve a enlazar los datos a la GridView. Este paso es necesario después */
            //de cambiar el índice de página para asegurarse de que la GridView muestre los 
            //datos correspondientes a la nueva página.
        }


        //FILTRO SIMPLE
        protected void txtFiltrar_TextChanged(object sender, EventArgs e)
        {
            List<Pokemon> lista = (List<Pokemon>)Session["lista"];
            List<Pokemon> listaFiltrada = lista.FindAll(x => x.Nombre.ToUpper().Contains(txtFiltrar.Text.ToUpper()));
            dgvPokemons.DataSource = listaFiltrada;
            dgvPokemons.DataBind();
        }

        protected void chkFiltroAvanzado_CheckedChanged(object sender, EventArgs e)
        {
            if (!chkFiltroAvanzado.Checked)
            {
                FiltroAvanzado = false;
            }
            else
            {
                FiltroAvanzado = true;

            }
        }

        protected void ddlCampo_SelectedIndexChanged(object sender, EventArgs e)
        {
            ddlCriterio.Items.Clear();                 /*PARA QUE NO SE ACUMULEN LOS ITEMS CON CADA VEZ QUE SE EJECUTE EL EVENTO*/

            if (ddlCampo.SelectedItem.ToString() == "Numero")
            {
                ddlCriterio.Items.Add("Igual a..");
                ddlCriterio.Items.Add("Mayor a..");
                ddlCriterio.Items.Add("Menor a..");
            }
            else
            {
                ddlCriterio.Items.Add("Contiene..");
                ddlCriterio.Items.Add("Empieza con..");
                ddlCriterio.Items.Add("Termina con..");
            }
        }

        protected void btnFiltroAvanzado_Click(object sender, EventArgs e)
        {
            try
            {
                dgvPokemons.DataSource = null;

                PokemonNegocio negocio = new PokemonNegocio();
                dgvPokemons.DataSource = negocio.filtrar(ddlCampo.SelectedItem.ToString(), ddlCriterio.SelectedItem.ToString(), txtFiltro.Text, ddlEstado.SelectedItem.ToString());
                dgvPokemons.DataBind();

            }
            catch (Exception ex)
            {

                Session.Add("Error", ex);
                throw;
            }
        }

        protected void btnLimpiarFiltro_Click(object sender, EventArgs e)
        {
            txtFiltrar.Text = "";
            dgvPokemons.DataSource = Session["lista"];
            dgvPokemons.DataBind();
        }
    }
}