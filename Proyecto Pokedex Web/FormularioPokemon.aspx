<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="FormularioPokemon.aspx.cs" Inherits="Proyecto_Pokedex_Web.FormularioPokemon" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <style>
        .oculto{
            display:none;
        }
        .error{
            color:red;
        }
    </style>

    <asp:ScriptManager runat="server" ID="ScriptManager1" />

    <div class="row">
        <div class="col-6">
            <%--ID--%>
            <div class="mb-3">
                <label for="txtID" class="form-label">Id</label>
                <asp:TextBox runat="server" ID="txtID" CssClass="form-control" />
            </div>
            <%--NOMBRE --%>
            <div class="mb-3">
                <label for="txtNombre" class="form-label">Nombre</label>
                <asp:TextBox runat="server" ID="txtNombre" CssClass="form-control" />
            </div>
            <%--NUMERO--%>
            <div class="mb-3">
                <label for="txtNumero" class="form-label">Numero</label>
                <asp:TextBox runat="server" ID="txtNumero" CssClass="form-control" />
            </div>
            <%--TIPO--%>
            <div class="mb-3">
                <label for="ddlTipo" class="form-label">Tipo</label>
                <asp:DropDownList runat="server" CssClass="form-select" ID="ddlTipo"></asp:DropDownList>
            </div>
            <%--DEBILIDAD--%>
            <div class="mb-3">
                <label for="ddlDebilidad" class="form-label">Debilidad</label>
                <asp:DropDownList runat="server" CssClass="form-select" ID="ddlDebilidad"></asp:DropDownList>
            </div>
            <%--ACEPTAR-CANCELAR-INACTIVAR--%>
            <div class="mb-3">
                <asp:Button Text="Aceptar" ID="btnAceptar" UseSubmitBehavior="false" OnClick="btnAceptar_Click" CssClass="btn btn-primary" runat="server" />
                <a href="PokemonLista.aspx">Cancelar</a>
                <asp:Button Text="Inactivar" ID="btnInactivar" CssClass="btn btn-warning" OnClick="btnInactivar_Click" runat="server" />
            </div>
        </div>
        <div class="col-6">
            <%--DESCRIPCION--%>
            <div class="mb-3">
                <label for="txtDescripcion" class="form-label">Descripcion</label>
                <asp:TextBox runat="server" ID="txtDescripcion" TextMode="MultiLine" CssClass="form-control" />
            </div>

            <%--IMAGEN--%>
            <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                <ContentTemplate>

                    <div class="mb-3">
                        <label for="txtImagenUrl" class="form-label">Url Imagen</label>
                        <asp:TextBox runat="server" ID="txtImagenUrl" CssClass="form-control" AutoPostBack="true" OnTextChanged="txtImagenUrl_TextChanged" />
                    </div>

                    <asp:Image ImageUrl="https://upload.wikimedia.org/wikipedia/commons/thumb/3/3f/Placeholder_view_vector.svg/2560px-Placeholder_view_vector.svg.png" ID="imgPokemon" Width="60%" runat="server" />

                </ContentTemplate>
            </asp:UpdatePanel>
        </div>
    </div>

    <%--BOTON ELIMINAR Y CONFIRMACION--%>
    <div class="row">
        <div class="col-6">
            <asp:UpdatePanel runat="server">
                <ContentTemplate>

                    <div class="mb-3">
                        <asp:Button Text="Eliminar" ID="btnEliminar" UseSubmitBehavior="false" OnClick="btnEliminar_Click" CssClass="btn btn-danger" runat="server" />
                    </div>
                    <%if (ConfirmaEliminacion)
                        {%>
                    <div class="mb-3">
                        <asp:CheckBox Text="Confirmar Eliminacion" ID="chkEliminar"  runat="server" />
                        <asp:Button Text="Eliminar" ID="btnConfirmarEliminar" CssClass="btn btn-outline-danger" OnClick="btnConfirmarEliminar_Click" runat="server" />
                        <asp:Label Text="No se pudo eliminar" CssClass="form-label oculto" ID="lblErrorEliminar" runat="server" />
                    </div>
                    <%} %>

                </ContentTemplate>
            </asp:UpdatePanel>
        </div>
    </div>




    <hr />

</asp:Content>
