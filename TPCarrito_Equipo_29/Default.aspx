<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="TPCarrito_Equipo_29._Default" %>


<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">

   
    
    <!-- Estas son las Tarjetas -->
    <div class="row row-cols-3 row-cols-md-4 g-4">
        <asp:ListView ID="dgvArticulos" runat="server" ItemPlaceholderID="itemPlaceholder">
            <LayoutTemplate>
                <asp:PlaceHolder ID="itemPlaceholder" runat="server" />
            </LayoutTemplate>
            <ItemTemplate>
                <div class="col">
                    <div class="card">
                        <asp:Image runat="server" ID="imgArticulo" CssClass="card-img-top" />
                        <img class="card-img-top" src='<%# Eval("Imagen.UrlImagen") %>' alt="Imagen del artículo">
                        <div class="card-body">
                            <h5 class="card-title"><%# Eval("Nombre") %></h5>
                            <p class="card-text"><%# Eval("Descripcion") %></p>
                            <p class="card-text">Precio: $<%# Eval("Precio") %></p>
                            <asp:LinkButton ID="btnAgregar" runat="server" CssClass="btn btn-primary" Text="Agregar" />
                            <asp:LinkButton ID="btnDetalles" runat="server" CssClass="btn btn-primary" Onclick="btnDetalles_Click" CommandArgument='<%# Eval("Id") %>'  Text="Ver detalles" />
                        </div>
                    </div>
                </div>
            </ItemTemplate>
        </asp:ListView>
    </div>

    <!-- Paginador "Siguiente,Anterior" -->
     <div class="navbar fixed-bottom bg-white d-flex justify-content-center align-items-center">
        <asp:DataPager ID="lvArticulosDataPager" runat="server" PagedControlID="dgvArticulos">
            <Fields>
                <asp:NextPreviousPagerField ButtonType="Button" ShowPreviousPageButton="True" ShowNextPageButton="True" ButtonCssClass="btn btn-primary" />
            </Fields>
        </asp:DataPager>
    </div>
</asp:Content>