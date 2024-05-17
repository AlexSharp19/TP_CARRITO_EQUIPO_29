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
                            <asp:LinkButton ID="btnAgregar" runat="server" CssClass="btn btn-primary" OnClick="btnAgregar_Click" CommandArgument='<%# Eval("Id") %>' Text="Agregar" />
                            <asp:LinkButton ID="btnDetalles" runat="server" CssClass="btn btn-primary" Onclick="btnDetalles_Click" CommandArgument='<%# Eval("Id") %>'  Text="Ver detalles" />
                        </div>
                    </div>
                </div>
            </ItemTemplate>
        </asp:ListView>
    </div>
   
    <div class="d-flex justify-content-center mt-3">
        <ul class="pagination pagination-lg" id="pagination" >
            <asp:Literal ID="litPagination" runat="server"></asp:Literal>
        </ul>
    </div>

</asp:Content>