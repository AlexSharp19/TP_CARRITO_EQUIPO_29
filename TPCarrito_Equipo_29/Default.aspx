<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="TPCarrito_Equipo_29._Default" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">

    <asp:ListView ID="dgvArticulos" runat="server" ItemPlaceholderID="itemPlaceholder">
    <LayoutTemplate>
        <div class="card-deck">
            <asp:PlaceHolder ID="itemPlaceholder" runat="server" />
        </div>
    </LayoutTemplate>
    <ItemTemplate>
        <div class="card mb-3" style="width: 18rem;">
            <asp:Image runat="server" ID="imgArticulo" CssClass="card-img-top" />
            <img class="card-img-top" src='<%# Eval("Imagen.UrlImagen") %>' alt="Imagen del artículo">
            <div class="card-body">
                <h5 class="card-title"><%# Eval("Nombre") %></h5>
                <p class="card-text"><%# Eval("Descripcion") %></p>
                <asp:LinkButton ID="btnDetalles" runat="server" CssClass="btn btn-primary" Text="Ver detalles" />
            </div>
        </div>
    </ItemTemplate>
</asp:ListView>

    <asp:DataPager ID="lvArticulosDataPager" runat="server" PagedControlID="dgvArticulos">
    <Fields>
        <asp:NextPreviousPagerField ButtonType="Button" ShowFirstPageButton="True" ShowPreviousPageButton="True" ShowNextPageButton="False" ShowLastPageButton="False" />
        <asp:NumericPagerField ButtonType="Link" />
        <asp:NextPreviousPagerField ButtonType="Button" ShowNextPageButton="True" ShowLastPageButton="True" ShowPreviousPageButton="False" ShowFirstPageButton="False" />
    </Fields>
</asp:DataPager>

</asp:Content>
