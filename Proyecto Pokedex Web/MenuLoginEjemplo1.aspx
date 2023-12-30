<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="MenuLoginEjemplo1.aspx.cs" Inherits="Proyecto_Pokedex_Web.MenuLoginEjemplo1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">



    <%--FILA 1--%>
    <div class="row">
        <%--COLUMNA 1--%>
        <div class="col-6">
            <div class="mb-3">
                <h1>Te logueaste correctamente!</h1>
            </div>

            <div class="mb-3">
                <asp:Button Text="Pagina 1" CssClass="btn btn-primary" runat="server" />

                <%--SI ES ADMIN, MUESTRO LOS CONTROLES ASP DEBAJO--%>
                <%if (Funciones.Funcion.validarAdmin((Dominio.Usuario)Session["usuario"]) == true)
                    { %>
                <asp:Button Text="Pagina 2" ID="btnPagina2Admin" OnClick="btnPagina2Admin_Click" CssClass="btn btn-primary" runat="server" />
                <asp:Label Text="Tenes que ser admin." AssociatedControlID="" runat="server" />
                <%} %>
            </div>

        </div>
    </div>

</asp:Content>
