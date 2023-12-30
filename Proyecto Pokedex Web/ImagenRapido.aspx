<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="ImagenRapido.aspx.cs" Inherits="Proyecto_Pokedex_Web.ImagenRapido" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <h4>Imagen Rapido</h4>

    <div class="row">

        <div class="mb-5 col">
            <asp:Label Text="Url Imagen" ID="lblImagen" runat="server" CssClass="form-label" />
            <asp:TextBox runat="server" ID="txtUrlImagen" CssClass="form-control" />
        </div>

        <div class="mb-5 col">
            <asp:Button Text="Cargar" runat="server" ID="btnCargar" OnClick="btnCargar_Click" UseSubmitBehavior="false" CssClass="mt-4 btn btn-primary" />
        </div>

        <div class="row">
            <div class="col">
                <img src="<%= UrlImagen %>" alt="alternate" />
            </div>
        </div>

    </div>

</asp:Content>
