<%@ Page Title="Detalles del Artículo" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="DetalleArticulos.aspx.cs" Inherits="TPCarrito_Equipo_29.DetalleArticulos" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div class="container">
        <h2>Detalles del Artículo</h2>
        <div class="row">
            <div class="col-md-6">
                <asp:Image ID="imgArticulo" runat="server" CssClass="img-fluid" />
            </div>
            <div class="col-md-6">
                <h3><asp:Literal ID="litNombre" runat="server" /></h3>
                <p>Precio: $<asp:Literal ID="litPrecio" runat="server" /></p>
            
            </div>
            <!-- Panel para la ficha técnica -->
            <div class="col-md-12">
                <div id="panelFichaTecnica" runat="server" class="card p-4 mb-4"> <!-- Aplica la clase card de Bootstrap aquí -->
                    <h4>Descripcion</h4>
                   
                     <p><asp:Literal ID="litDescripcion" runat="server" /></p>

                    <h4>Ficha Técnica</h4>
                    <ul class="list-group"> <!-- Utiliza la clase list-group de Bootstrap para la lista -->
                        <li class="list-group-item"><h2>Categoria:</h2> <p><asp:Literal ID="litCategoria" runat="server" /></p></li>
                        <li class="list-group-item">Marca: <p> <asp:Literal ID="litMarca" runat="server" /></p></li>
                        
                    </ul>
                </div>
            </div>

        </div>
    </div>
</asp:Content>