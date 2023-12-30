<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="LoginEjemplo1.aspx.cs" Inherits="Proyecto_Pokedex_Web.LoginEjemplo1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <%--FILA 1--%>
    <div class="row">
        <%--COLUMNA 1--%>
        <div class="col-6">
            <%--USER--%>
            <div class="mb-3">
                <asp:Label Text="User" CssClass="form-label" AssociatedControlID="txtUser" ID="lblUser" runat="server" />
                <asp:TextBox runat="server" Placeholder="Ingrese su usuario" CssClass="form-control" ID="txtUser" />
            </div>
            <%--PASSWORD--%>
            <div class="mb-3">
                <asp:Label Text="Password" CssClass="form-label" ID="lblPassword" AssociatedControlID="txtPassword" runat="server" />
                <asp:TextBox runat="server" Placeholder="*****" CssClass="form-control" ID="txtPassword" TextMode="Password" />
            </div>

            <%--BOTON LOGIN--%>
            <asp:Button Text="Ingresar" CssClass="btn btn-primary" ID="btnIngresar" UseSubmitBehavior="true" OnClick="btnIngresar_Click" runat="server" />

        </div>
    </div>

</asp:Content>
