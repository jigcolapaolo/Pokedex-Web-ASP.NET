<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="PokemonLista.aspx.cs" Inherits="Proyecto_Pokedex_Web.PokemonLista" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <style>
        .seleccionado > td {
            background-color: lightblue;
            color: black;
        }
    </style>

    <h1>Lista de Pokemons</h1>
    <%--FILTRAR--%>
    <%--FILA FILTRO SIMPLE--%>
    <div class="row">
        <div class="col-6">
            <div class="mb-3">
                <asp:Label Text="Filtrar" ID="lblFiltrar" CssClass="form-label" runat="server" />
                <asp:TextBox runat="server" ID="txtFiltrar" CssClass="form-control" AutoPostBack="true" OnTextChanged="txtFiltrar_TextChanged" />
                <asp:Button Text="Limpiar Filtro" CssClass="btn btn-primary mt-2" ID="btnLimpiarFiltro" UseSubmitBehavior="true" OnClick="btnLimpiarFiltro_Click" runat="server" />
            </div>
        </div>
        <%--CHECK FILTRO AVANZADO--%>
        <div class="col-6">
            <div class="mb-4"></div>
            <div class="mb-3">
                <asp:CheckBox Text="Filtro Avanzado" CssClass="" ID="chkFiltroAvanzado" AutoPostBack="true" OnCheckedChanged="chkFiltroAvanzado_CheckedChanged" runat="server" />
            </div>
        </div>
    </div>

    <%--FILA FILTRO AVANZADO--%>

    <%if (FiltroAvanzado)       /*TAMBIEN PODRIA PONER CHKFILTROAVANZADO.CHECKED EN EL IF*/
        {%>

    <div class="row">
        <div class="col-3">
            <%--CAMPO--%>
            <div class="mb-3">
                <asp:Label Text="Campo" ID="lblCampo" CssClass="form-label" runat="server" />
                <asp:DropDownList ID="ddlCampo" CssClass="form-control" AutoPostBack="true" OnSelectedIndexChanged="ddlCampo_SelectedIndexChanged" runat="server">
                    <asp:ListItem Text="Nombre" />
                    <asp:ListItem Text="Tipo" />
                    <asp:ListItem Text="Numero" />
                </asp:DropDownList>
            </div>
        </div>
        <%--CRITERIO--%>
        <div class="col-3">
            <div class="mb-3">
                <asp:Label Text="Criterio" ID="lblCriterio" CssClass="form-label" runat="server" />
                <asp:DropDownList ID="ddlCriterio"  CssClass="form-control" runat="server"></asp:DropDownList>
            </div>
        </div>
        <%--FILTRO--%>
        <div class="col-3">
            <div class="mb-3">
                <asp:Label Text="Filtro" ID="lblFiltro" CssClass="form-label" runat="server" />
                <asp:TextBox runat="server" Id="txtFiltro" CssClass="form-control"/>
            </div>
        </div>
        <%--ESTADO--%>
        <div class="col-3">
            <div class="mb-3">
                <asp:Label Text="Estado" ID="lblEstado" CssClass="form-label" runat="server" />
                <asp:DropDownList runat="server" ID="ddlEstado" CssClass="form-control">
                    <asp:ListItem Text="Todos" />
                    <asp:ListItem Text="Activo" />
                    <asp:ListItem Text="Inactivo" />
                </asp:DropDownList>
            </div>
        </div>
    </div>
    <%--BOTON FILTRO AVANZADO--%>
    <div class="row">
        <div class="col-6">
            <div class="mb-3">
                <asp:Button Text="Buscar" ID="btnFiltroAvanzado" UseSubmitBehavior="true" OnClick="btnFiltroAvanzado_Click" CssClass="btn btn-primary" runat="server" />

            </div>
        </div>
    </div>

    <%} %>

    <%--GRID CON PAGINATION--%>
    <asp:GridView ID="dgvPokemons" CssClass="table table-dark table-bordered " AutoGenerateColumns="false" runat="server"
        DataKeyNames="Id" OnSelectedIndexChanged="dgvPokemons_SelectedIndexChanged" OnPageIndexChanging="dgvPokemons_PageIndexChanging"
        AllowPaging="True" PageSize="5" SelectedRowStyle-CssClass="seleccionado">
        <Columns>
            <asp:BoundField HeaderText="Nombre" DataField="Nombre" />
            <asp:BoundField HeaderText="Numero" DataField="Numero" />
            <asp:BoundField HeaderText="Tipo" DataField="Tipo.Descripcion" />
            <asp:CheckBoxField HeaderText="Activo" DataField="Activo" />
            <%--En ASP necesita aclararse que quiero que aparezca la propiedad de pokemon Tipo, pero que dentro de tipo, muestre la propiedad descripcion del elemento--%>
            <asp:CommandField ShowSelectButton="true" SelectText="✍🏻" HeaderText="Accion" />

        </Columns>
    </asp:GridView>

    <asp:Button Text="Agregar" CssClass="btn btn-primary" ID="btnAgregar" OnClick="btnAgregar_Click" runat="server" />

</asp:Content>
