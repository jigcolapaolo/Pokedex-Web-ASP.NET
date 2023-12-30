<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="EnvioEmail.aspx.cs" Inherits="Proyecto_Pokedex_Web.EnvioEmail" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <%--FILA 1--%>
    <div class="row">
        <%--COLUMNA 1--%>
        <div class="col-2"></div>
        <%--COLUMNA 2--%>
        <div class="col-5">
            <div class="mb-3">
                <%--EMAIL--%>
                <asp:Label Text="Email" ID="lblEmail" AssociatedControlID="txtEmail" CssClass="form-label" runat="server" />
                <asp:TextBox ID="txtEmail" CssClass="form-control" runat="server" />
            </div>
            <div class="mb-3">
                <%--ASUNTO--%>
                <asp:Label Text="Asunto" ID="lblAsunto" AssociatedControlID="txtAsunto" CssClass="form-label" runat="server" />
                <asp:TextBox ID="txtAsunto" CssClass="form-control" runat="server" />
            </div>
            <div class="mb-3">
                <%--MENSAJE--%>
                <asp:Label Text="Mensaje" CssClass="form-label" AssociatedControlID="txtMensaje" ID="lblMensaje" runat="server" />
                <asp:TextBox ID="txtMensaje" CssClass="form-control" TextMode="MultiLine" runat="server" />
            </div>

            <div class="mb-3">
                <%--BOTON ACEPTAR--%>
                <asp:Button Text="Aceptar" ID="btnAceptar" OnClick="btnAceptar_Click" UseSubmitBehavior="true" CssClass="btn btn-primary" runat="server" />
            </div>


        </div>
    </div>

</asp:Content>
