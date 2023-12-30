<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="SeleccionElementos.aspx.cs" Inherits="Proyecto_Pokedex_Web.SeleccionElementos" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">


    <h4>Seleccion de elementos</h4>


    <div class="mb-3 row">

        <div class="col-sm-5">
            <asp:Label Text="ID" runat="server" />
            <asp:TextBox runat="server" ID="txtID" AutoPostBack="true" CssClass="form-control" />
        </div>

        <div class="col">
            <asp:Label Text="Elemento Preseleccionado" runat="server" CssClass="form-label" />
            <asp:DropDownList runat="server" ID="ddlElementos" CssClass="btn btn-outline-dark dropdown-toggle"></asp:DropDownList>
        </div>

    </div>

    <asp:Button Text="Aceptar" ID="btnAceptar" OnClick="btnAceptar_Click" runat="server" CssClass="mt-5 btn btn-primary" UseSubmitBehavior="false" />



</asp:Content>
