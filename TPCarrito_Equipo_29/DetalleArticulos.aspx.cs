using Business.Articulo;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace TPCarrito_Equipo_29
{
    public partial class DetalleArticulos : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                string articuloID = Request.QueryString["id"];
                if (!string.IsNullOrEmpty(articuloID))
                {
                    CargarDetallesArticulo(int.Parse(articuloID));
                    // Hacer visible el panel de la ficha técnica
                    panelFichaTecnica.Visible = true;
                }
                else
                {
                    // Ocultar el panel si no se proporciona un ID de artículo
                    panelFichaTecnica.Visible = false;
                }
            }

        }

        private void CargarDetallesArticulo(int id)
        {
            var articuloBusiness = new ArticuloBussines();
            ArticuloEntity articulo = articuloBusiness.getByID(id);

            if (articulo != null)
            {
                imgArticulo.ImageUrl = articulo.Imagen.UrlImagen;
                litNombre.Text = articulo.Nombre;
                litPrecio.Text = articulo.Precio.ToString("F2");
                litMarca.Text = articulo.Marca.Descripcion;
                litCategoria.Text = articulo.Categoria.Descripcion;
            }
            else
            {
                litNombre.Text = "Artículo no encontrado";
            }
        }
    }
}