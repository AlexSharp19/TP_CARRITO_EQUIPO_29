<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Carrito.aspx.cs" Inherits="TPCarrito_Equipo_29.Carrito" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    
        <div class="container">
            <h2 class="mt-4">Carrito de Compras</h2>
            <asp:GridView ID="gvCarrito" runat="server" AutoGenerateColumns="False" CssClass="table table-striped">
                <Columns>
                    <asp:BoundField DataField="Nombre" HeaderText="Nombre" />
                    <asp:BoundField DataField="Descripcion" HeaderText="Descripción" />
                    <asp:BoundField DataField="Precio" HeaderText="Precio" DataFormatString="{0:C}" />
                    <asp:TemplateField>
                        <ItemTemplate>
                            <asp:LinkButton ID="btnEliminar" runat="server" CssClass="btn btn-danger" OnClick="btnEliminar_Click" CommandArgument='<%# Eval("Id") %>' Text="Eliminar" />
                        </ItemTemplate>
                    </asp:TemplateField>
                </Columns>
            </asp:GridView>
            <div class="mt-3">
                <asp:Label ID="lblTotal" runat="server" CssClass="h4"></asp:Label>
            </div>
        </div>
    
</asp:Content>
