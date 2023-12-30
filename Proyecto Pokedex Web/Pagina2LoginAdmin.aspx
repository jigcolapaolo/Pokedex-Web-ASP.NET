<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="Pagina2LoginAdmin.aspx.cs" Inherits="Proyecto_Pokedex_Web.Pagina2LoginAdmin" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <h1>Te logueaste como admin!</h1>

    <asp:Button Text="Regresar" ID="btnRegresar" OnClick="btnRegresar_Click" CssClass="btn btn-primary" runat="server" />

</asp:Content>
