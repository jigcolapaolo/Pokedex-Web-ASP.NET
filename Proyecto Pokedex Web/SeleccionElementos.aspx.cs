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
    public partial class SeleccionElementos : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            ElementoNegocio elementoNegocio = new ElementoNegocio();

            try
            {
                if (!IsPostBack)
                {
                    List<Elementos> listaElementos = elementoNegocio.listar();

                    ddlElementos.DataSource = listaElementos;
                    ddlElementos.DataTextField = "Descripcion";
                    ddlElementos.DataValueField = "Id";
                    ddlElementos.DataBind();    
                }
            }
            catch (Exception ex)
            {

                Session.Add("Error", ex);
            }
        }

        protected void btnAceptar_Click(object sender, EventArgs e)
        {
            string id = txtID.Text;


            //int id = int.Parse(ddlElementos.SelectedItem.Value);
            //txtID.Text = id.ToString();


            //OPCION 1   TOMA EL ID ESCRITO EN EL TEXTBOX Y SELECCIONA EL ELEMENTO QUE TENGA EL MISMO ID

            ddlElementos.SelectedIndex = ddlElementos.Items.IndexOf(ddlElementos.Items.FindByValue(id));


            //OPCION 2  NO MUESTRA NINGUN ELEMENTO CON EL INDICE EN -1 Y LUEGO SELECCIONA EL QUE TENGA VALOR DE ID = ID

            //ddlElementos.SelectedIndex = -1;
            //ddlElementos.Items.FindByValue(id).Selected = true;

            
        }
    }
}