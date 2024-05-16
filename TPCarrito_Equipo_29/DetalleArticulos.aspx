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
                <p>Marca: <asp:Literal ID="litMarca" runat="server" /></p>
                <p>Categoría: <asp:Literal ID="litCategoria" runat="server" /></p>
            </div>
            <!-- Panel para la ficha técnica -->
            <div class="col-md-12">
                <div id="panelFichaTecnica" runat="server" class="card p-4 mb-4"> <!-- Aplica la clase card de Bootstrap aquí -->
                    <h4>General</h4>
                    <p>Celular. Pantalla de 6.3" FW + Waterdrop Display. Display IPS. Procesador: Octa-Core ((1.6GHz*4) + (1.2GHz*4)). Almacenamiento de 32 GB. Memoria RAM de 2 GB + (2GB Fusion RAM). Camara principal de 8 MP AF / Camara frontal de 5 MP FF. Conexiones: Wifi 802.11b/g/n, 2.4G. Bluetooth 4.2. Micro USB 2.0. Entrada para auricular 3.5 mm. GPS. Slot para tarjetas. Sistema operativo: Android S Go / 12 Go. Bateria 3000 mAh, removible. Desbloqueo facial y lector de huella digital. Radio FM. Flash. Otras funciones: Fotos panoramicas - HDR - Estabilizador imagen. Incluye: Cargador, cable USB, extractor de tarjeta SIM/Micro SD.</p>
                    <h4>Ficha Técnica</h4>
                    <ul class="list-group"> <!-- Utiliza la clase list-group de Bootstrap para la lista -->
                        <li class="list-group-item">EAN: 7796941140617</li>
                        <li class="list-group-item">Alto: 16</li>
                        <li class="list-group-item">Ancho: 7.8</li>
                        <li class="list-group-item">Color: SILVER</li>
                        <li class="list-group-item">Modelo: A33 PLUS</li>
                        <li class="list-group-item">Origen: ARGENTINA</li>
                        <li class="list-group-item">Peso: 0.201</li>
                        <li class="list-group-item">Bluetooth: SI</li>
                        <li class="list-group-item">Camara frontal: 5</li>
                        <li class="list-group-item">GPS: INTEGRADO</li>
                        <li class="list-group-item">Procesador: OCTA CORE</li>
                        <li class="list-group-item">Marca del equipo: ZTE</li>
                        <li class="list-group-item">Radio: SI</li>
                        <li class="list-group-item">Sistema Operativo: ANDROID 12</li>
                        <li class="list-group-item">Tamaño de pantalla: 6.26</li>
                        <li class="list-group-item">Tecnologia: IPS</li>
                        <li class="list-group-item">Tipo de pantalla: IPS LCD HD</li>
                        <li class="list-group-item">USB: SI</li>
                        <li class="list-group-item">Wi Fi: SI</li>
                    </ul>
                </div>
            </div>

        </div>
    </div>
</asp:Content>