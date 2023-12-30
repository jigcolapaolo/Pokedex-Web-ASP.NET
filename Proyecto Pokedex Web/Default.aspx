<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="Proyecto_Pokedex_Web.Default" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <h1 class="mb-5">Bienvenido!</h1>


    <div class="row row-cols-1 row-cols-md-3 g-4">

        <!--      <%
            //foreach (Dominio.Pokemon poke in ListaPokemon)
            {%>
                                        <%--LA TARJETA SE REPETIRA TANTAS VECES COMO POKEMONS HAYA EN LA LISTA--%>
                <div class="col">
                    <div class="card">
                        <img src="%: poke.UrlImagen %" class="card-img-top" alt="...">
                        <div class="card-body">
                            <h5 class="card-title">%: poke.Nombre %</h5>
                            <p class="card-text">%: poke.Descripcion %</p>
                            <a href="DetallePokemon.aspx?id=%: poke.Id %">Ver Detalle</a>  <%--VOY A DETALLEPOKEMON Y LLEVO LA VARIABLE ID DEL POKEMON, USAR QUERYSTRING EN EL BACK--%>
                        </div>
                    </div>
                </div>

        <% }%>      -->


        <asp:Repeater runat="server" ID="repRepeater">
            <ItemTemplate>

                <%--LA TARJETA SE REPETIRA TANTAS VECES COMO POKEMONS HAYA EN LA LISTA--%>
                <div class="col">
                    <div class="card">
                        <img src='<%# string.IsNullOrEmpty(Eval("UrlImagen").ToString()) ? "https://t4.ftcdn.net/jpg/04/73/25/49/360_F_473254957_bxG9yf4ly7OBO5I0O5KABlN930GwaMQz.jpg" : Eval("UrlImagen") %>' class="card-img-top" alt="...">
                        <div class="card-body">
                            <h5 class="card-title"><%#Eval("Nombre") %></h5>            <%--USO EVAL(<NOMBREDEPROPIEDAD>)--%>
                            <p class="card-text"><%#Eval("Descripcion") %></p>
                            <a href="FormularioPokemon.aspx?id=<%#Eval("Id")%>">Ver Detalle</a>  <%--VOY A DETALLEPOKEMON Y LLEVO LA VARIABLE ID DEL POKEMON, USAR QUERYSTRING EN EL BACK--%>
                            <asp:Button Text="Ejemplo" CssClass="btn btn-primary" ID="btnEjemplo" CommandArgument='<%#Eval("Id") %>' CommandName="PokemonId" OnClick="btnEjemplo_Click" runat="server" />
                        </div>
                    </div>
                </div>

            </ItemTemplate>
        </asp:Repeater>

    </div>

</asp:Content>
