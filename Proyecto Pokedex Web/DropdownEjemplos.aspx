<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="DropdownEjemplos.aspx.cs" Inherits="Proyecto_Pokedex_Web.DropdownEjemplos" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <div class="row">               <%--CREO UNA FILA--%>

            <div class="col-1"></div>       <%--COLUMNA PARA SEPARAR--%>
            <div class="col-2">

                                        <%--DROPDOWN LIST ESTATICO--%>
                <label for="ddlColores" class="form-label">DropdownList Estatico</label>
                <asp:DropDownList runat="server" CssClass="btn btn-outline-dark dropdown-toggle" ID="ddlColores">
                    <asp:ListItem Text="Rojo" />
                    <asp:ListItem Text="Negro" />
                    <asp:ListItem Text="Azul" />
                </asp:DropDownList>
            </div>

            <div class="col-4"></div>       <%--COLUMNA PARA SEPARAR--%>

                                <%--DROPDOWN LIST DESDE DB--%>
            <div class="col-2">
                <label for="ddlPokemons" class="form-label">DropdownList desde DB</label>
                <asp:DropDownList runat="server" CssClass="btn btn-outline-dark dropdown-toggle" ID="ddlPokemons"></asp:DropDownList>
            </div>


    </div>

    <hr />

    <h2>Mas Ejemplos</h2>
    <a href="DropdownEnlazados.aspx">Dropdown Enlazados</a>
    <a href="UpdatePanel.aspx">Update Panel</a>
</asp:Content>
