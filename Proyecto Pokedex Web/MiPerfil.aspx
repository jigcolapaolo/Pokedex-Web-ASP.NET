<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="MiPerfil.aspx.cs" Inherits="Proyecto_Pokedex_Web.MiPerfil" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script>

        function validar() {
            //Capturar el control.
            const txtNombre = document.getElementById("txtNombre");
            const txtApellido = document.getElementById("txtApellido");

            const controles = [txtNombre, txtApellido]

            let esValido = true;

            for (const control of controles) {
                if (control.value == "") {
                    control.classList.add("is-invalid");
                    control.classList.remove("is-valid");

                    esValido = false;
                } else {
                    control.classList.add("is-valid");
                    control.classList.remove("is-invalid");

                }
            }

            return esValido;

        }


    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <%--FILA 1--%>
    <div class="row">
        <h1>Mi Perfil</h1>
        <%--COLUMNA 1--%>
        <div class="col-4">
            <%--EMAIL--%>
            <div class="mb-3">
                <asp:Label Text="Email" CssClass="form-label" ID="lblEmail" AssociatedControlID="txtEmail" runat="server" />
                <asp:TextBox CssClass="form-control" ID="txtEmail" runat="server" />
            </div>
            <%--NOMBRE--%>
            <div class="mb-3">
                <asp:Label Text="Nombre" ID="lblNombre" CssClass="form-label" AssociatedControlID="txtNombre" runat="server" />
                <asp:TextBox CssClass="form-control" ID="txtNombre" ClientIDMode="Static" runat="server" />
                <%--<asp:RequiredFieldValidator CssClass="text-danger" ErrorMessage="*Ingrese su nombre." ControlToValidate="txtNombre" runat="server" />--%>
            </div>
            <%--APELLIDO--%>
            <div class="mb-3">
                <asp:Label Text="Apellido" CssClass="form-label" ID="lblApellido" AssociatedControlID="txtApellido" runat="server" />
                <asp:TextBox CssClass="form-control" ClientIDMode="Static" ID="txtApellido" runat="server" />
                <%--<asp:RangeValidator ErrorMessage="Fuera de rango.." Type="Integer" MinimumValue="1" MaximumValue="20" ControlToValidate="txtApellido" runat="server" />--%>
                <%--<asp:RegularExpressionValidator ErrorMessage="Solo numeros." ValidationExpression="^[0-9]+$" ControlToValidate="txtApellido" runat="server" />--%>
                <%--<asp:RegularExpressionValidator ErrorMessage="Ingrese con formato email" ValidationExpression="^[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,}$" ControlToValidate="txtApellido" runat="server" />--%>
            </div>
            <%--FECHA DE NACIMIENTO--%>
            <div class="mb-5">
                <asp:Label Text="Fecha de Nacimiento" ID="lblFNacimiento" CssClass="form-label" AssociatedControlID="txtFNacimiento" runat="server" />
                <asp:TextBox CssClass="form-control" ID="txtFNacimiento" TextMode="Date" runat="server" />
            </div>
        </div>

        <%--COLUMNA 2--%>
        <%--INPUT SELECCIONAR IMAGEN--%>
        <div class="col-4">

            <div class="mb-3">
                <asp:Label Text="Imagen Perfil" CssClass="form-label" ID="lblImagenPerfil" AssociatedControlID="" runat="server" />
                <input type="file" class="form-control" id="txtImagen" runat="server" />
            </div>

            <%--IMAGEN--%>
            <asp:Image
                ImageUrl="https://t4.ftcdn.net/jpg/04/73/25/49/360_F_473254957_bxG9yf4ly7OBO5I0O5KABlN930GwaMQz.jpg"
                runat="server" ID="imgNuevoPerfil" CssClass="img-fluid mb-3" />
        </div>
        <%--COLUMNA 3--%>
        <div class="col-4"></div>

    </div>

    <%--FILA 2--%>
    <div class="row">
        <%--COLUMNA 1--%>
        <div class="col-4">
            <div class="mb-3">
                <%--GUARDAR/REGRESAR--%>
                <div class="mt-5">
                    <asp:Button Text="Guardar" ID="btnGuardar" UseSubmitBehavior="true" CssClass="btn btn-primary" OnClientClick="return validar()" OnClick="btnGuardar_Click" runat="server" />
                    <a href="Default.aspx">Regresar</a>
                </div>
            </div>
        </div>
    </div>

</asp:Content>
