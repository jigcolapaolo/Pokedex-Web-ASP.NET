<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="DropdownEnlazados.aspx.cs" Inherits="Proyecto_Pokedex_Web.DropdownEnlazados" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">


    <div class="row">
        <div class="col">
            <h4>Dropdown Enlazados</h4>
        </div>
    </div>

    <div class="row">
        <%--CREO UNA FILA--%>

        <div class="col">

            <%--DROPDOWN LIST TIPOS (ELEMENTO)--%>
            <asp:Label Text="Tipos" runat="server" />
            <asp:DropDownList runat="server" CssClass="btn btn-outline-dark dropdown-toggle" ID="ddlTipos" AutoPostBack="true" 
                OnSelectedIndexChanged="ddlTipos_SelectedIndexChanged"> 
            </asp:DropDownList>
        </div>



        <%--DROPDOWN LIST ENLAZADO AL ANTERIOR SEGUN ELEMENTO--%>
        <div class="col">
            <asp:Label Text="Pokemons" runat="server" />
            <asp:DropDownList runat="server" CssClass="btn btn-outline-dark dropdown-toggle" ID="ddlPokemonsFiltrados"></asp:DropDownList>
        </div>


    </div>

    <hr />

</asp:Content>
