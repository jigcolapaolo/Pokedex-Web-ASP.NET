using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Dominio;
using Negocio;

namespace Proyecto_Pokedex_Web
{
    public partial class FormularioPokemon : System.Web.UI.Page
    {
        public bool ConfirmaEliminacion { get; set; }     /*PARA QUE ACTIVE O DESACTIVE EL BOTON ELIMINAR*/
        protected void Page_Load(object sender, EventArgs e)
        {

            ConfirmaEliminacion = false;


            txtID.Enabled = false;            /*DESHABILITO EL CONTROL DE ID*/
            PokemonNegocio negocio = new PokemonNegocio();
            ElementoNegocio negocioElementos = new ElementoNegocio();

            try
            {

                if (!IsPostBack)
                {
                    List<Pokemon> listaPokemon = negocio.listarConSP();
                    List<Elementos> listaElementos = negocioElementos.listar();

                    //CONFIGURACION INICIAL (CARGO LOS DROPDOWN)


                    ddlTipo.DataSource = listaElementos;
                    ddlTipo.DataValueField = "Id";
                    ddlTipo.DataTextField = "Descripcion";
                    ddlTipo.DataBind();
                    ddlDebilidad.DataSource = listaElementos;
                    ddlDebilidad.DataValueField = "Id";
                    ddlDebilidad.DataTextField = "Descripcion";
                    ddlDebilidad.DataBind();


                    //MODIFICAR
                    //    SI RECIBO UN ID, LO GUARDO EN LA VARIABLE ID, SI NO, LA DEJO VACIA
                    string id = Request.QueryString["id"] != null ? Request.QueryString["id"].ToString() : "";

                    if (id != "")        /*SI LA VARIABLE ID NO ESTA VACIA, USA EL ID PARA QUE EL METODO LISTAR EXTRAIGA EL POKEMON CON ESE ID Y LO GUARDE EN POKE*/
                    {
                        Pokemon poke = (negocio.listar(id))[0];

                        //GUARDO POKEMON SELECCIONADO EN SESION
                        Session.Add("pokeSeleccionado", poke);

                        txtNombre.Text = poke.Nombre;
                        txtNumero.Text = poke.Numero.ToString();
                        txtID.Text = id.ToString();                         /*CARGO LOS DATOS DEL POKEMON RECIBIDO*/
                        ddlTipo.SelectedValue = poke.Tipo.Id.ToString();
                        ddlDebilidad.SelectedValue = poke.Debilidad.Id.ToString();
                        txtDescripcion.Text = poke.Descripcion;
                        imgPokemon.ImageUrl = poke.UrlImagen;
                        txtImagenUrl.Text = poke.UrlImagen;

                        btnEliminar.Enabled = true;

                        //CONFIGURAR ACCIONES

                        if (!poke.Activo)
                        {
                            btnInactivar.Text = "Activar";
                            btnInactivar.CssClass = "btn btn-success";
                        }
                    }



                    //OTRA FORMA

                    //if (Request.QueryString["id"] != null)          /*RECIBO UN POKEMON PARA MODIFICAR (RECIBO SU ID)*/
                    //{
                    //    int id = int.Parse(Request.QueryString["id"].ToString());
                    //    poke = listaPokemon.Find(x => x.Id == id);

                    //    txtNombre.Text = poke.Nombre;
                    //    txtNumero.Text = poke.Numero.ToString();
                    //    txtID.Text = id.ToString();                         /*CARGO LOS DATOS DEL POKEMON RECIBIDO*/
                    //    ddlTipo.SelectedValue = poke.Tipo.Id.ToString();
                    //    ddlDebilidad.SelectedValue = poke.Debilidad.Id.ToString();
                    //    txtDescripcion.Text = poke.Descripcion;
                    //    imgPokemon.ImageUrl = poke.UrlImagen;
                    //    txtImagenUrl.Text = poke.UrlImagen;

                    //}

                }

            }
            catch (Exception ex)
            {

                Session.Add("Error", ex);
                throw;
                //REDIRECCION A  PAGINA DE ERROR
            }

        }

        protected void btnAceptar_Click(object sender, EventArgs e)
        {
            try
            {

                Pokemon poke = new Pokemon();
                PokemonNegocio negocio = new PokemonNegocio();

                poke.Id =
                poke.Numero = int.Parse(txtNumero.Text);
                poke.Nombre = txtNombre.Text;
                poke.Descripcion = txtDescripcion.Text;
                poke.UrlImagen = txtImagenUrl.Text;
                //DROPDOWNS
                poke.Tipo = new Elementos();
                poke.Tipo.Id = int.Parse(ddlTipo.SelectedValue);
                poke.Debilidad = new Elementos();
                poke.Debilidad.Id = int.Parse(ddlDebilidad.SelectedValue);

                if (Request.QueryString["id"] == null)
                {
                    /*SI NO RECIBE UN ID, AGREGO EL POKEMON, SI NO, LO MODIFICO*/
                    negocio.agregarConSP(poke);

                }
                else
                {
                    //DECLARO EL ID EN MODIFICAR PARA QUE LO UBIQUE
                    poke.Id = int.Parse(txtID.Text);
                    negocio.modificarConSP(poke);
                }



                Response.Redirect("PokemonLista.aspx", false);

            }
            catch (Exception ex)
            {
                Session.Add("Error", ex);
                throw;
            }
        }

        protected void txtImagenUrl_TextChanged(object sender, EventArgs e)
        {
            imgPokemon.ImageUrl = txtImagenUrl.Text;
        }

        protected void btnEliminar_Click(object sender, EventArgs e)
        {
            ConfirmaEliminacion = true;
        }

        protected void btnConfirmarEliminar_Click(object sender, EventArgs e)
        {
            try
            {
                if (Request.QueryString["id"] != null && chkEliminar.Checked)
                {
                    int id = int.Parse(Request.QueryString["id"].ToString());
                    PokemonNegocio negocio = new PokemonNegocio();
                    negocio.eliminar(id);

                    Response.Redirect("PokemonLista.aspx", false);
                }
                else
                {

                    lblErrorEliminar.CssClass = "error";


                }
            }
            catch (Exception ex)
            {

                Session.Add("Error", ex);
                throw;
            }
        }

        protected void btnInactivar_Click(object sender, EventArgs e)
        {
            try
            {
                if (Request.QueryString["id"] != null)
                {
                    int id = int.Parse(Request.QueryString["id"].ToString());
                    PokemonNegocio negocio = new PokemonNegocio();            
                    Pokemon poke = (Pokemon)Session["pokeSeleccionado"];
                    negocio.eliminarLogico(poke.Id, !poke.Activo);          /*LE ENVIO EL ESTADO ACTIVO OPUESTO AL QUE TIENE, PORQUE SI NO, EL METODO*/
                                                                            //APLICARIA EL MISMO ESTADO ACTUAL DEL POKEMON
                    Response.Redirect("PokemonLista.aspx", false);
                }

            }
            catch (Exception ex)
            {

                Session.Add("Error", ex);
                throw;
            }

        }
    }
}