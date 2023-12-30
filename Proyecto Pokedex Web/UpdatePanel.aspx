<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="UpdatePanel.aspx.cs" Inherits="Proyecto_Pokedex_Web.UpdatePanel" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <asp:ScriptManager runat="server" ID="ScriptManager1" />

    <h3>Update Panel</h3>
    <asp:UpdatePanel runat="server">
        <ContentTemplate>

            <div class="form-group">

                <div class="row">

                    <div class="col">
                        <asp:Label Text="text" runat="server" ID="lblNombre" />
                    </div>

                    <div class="col">
                        <asp:TextBox runat="server" AutoPostBack="true" ID="txtNombre" OnTextChanged="txtNombre_TextChanged" CssClass="form-control"  />
                    </div>

                    <div class="col">
                        <asp:Button Text="Aceptar" runat="server" CssClass="form-control" ID="btnAceptar" OnClick="btnAceptar_Click" />
                    </div>

                </div>

            </div>

        </ContentTemplate>
    </asp:UpdatePanel>

    <hr />

    <a href="EnlazadosUpdatePanel.aspx">Dropdown Enlazados + Update panel</a>
</asp:Content>
