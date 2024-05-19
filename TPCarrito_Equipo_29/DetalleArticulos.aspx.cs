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
        private List<ArticuloEntity> listArticulos;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                string articuloID = Request.QueryString["id"];
                if (!string.IsNullOrEmpty(articuloID))
                {
                    CargarDetallesArticulo(int.Parse(articuloID));
                    
                    panelFichaTecnica.Visible = true;
                }
                else
                {
                    
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
                litDescripcion.Text = articulo.Descripcion.ToString();
                btnAgregarDetalle.CommandArgument = articulo.Id.ToString();
            }
            else
            {
                litNombre.Text = "Artículo no encontrado";
            }
        }

        private void ActualizarCarrito()
        {
            if (Session["articulosSeleccionados"] != null)
            {
                var articulosSeleccionados = (List<ArticuloEntity>)Session["articulosSeleccionados"];

                int totalItems = 0;

                foreach (var item in articulosSeleccionados)
                {
                    totalItems += item.Cantidad;
                }

                string script = $"document.getElementById('cartItemCount').innerText = '{totalItems}';";
                ScriptManager.RegisterStartupScript(this, GetType(), "updateCartCount", script, true);
            }
        }

        protected void btnAgregarDetalle_Click(object sender, EventArgs e)
        {
            var linkButton = sender as LinkButton;
            if (linkButton != null)
            {
                if (int.TryParse(linkButton.CommandArgument, out int articuloId))
                {
                    var articuloBusinees = new ArticuloBussines();

                    try
                    {
                        listArticulos = articuloBusinees.GetArticulos();

                        var articulo = listArticulos.FirstOrDefault(s => s.Id == articuloId);
                        if (articulo != null)
                        {
                            List<ArticuloEntity> articulosSeleccionados;
                            if (Session["articulosSeleccionados"] == null)
                            {
                                articulosSeleccionados = new List<ArticuloEntity>();
                            }
                            else
                            {
                                articulosSeleccionados = (List<ArticuloEntity>)Session["articulosSeleccionados"];
                            }

                            articulosSeleccionados.Add(articulo);
                            Session["articulosSeleccionados"] = articulosSeleccionados;
                        }

                        string script = "Swal.fire({ title: 'Éxito', text: 'Artículo agregado correctamente al carrito.', icon: 'success', confirmButtonText: 'OK' });";
                        ScriptManager.RegisterStartupScript(this, GetType(), "showalert", script, true);

                        ActualizarCarrito();
                    }
                    catch (Exception ex)
                    {
                        throw new Exception("Ocurrió un error al intentar obtener los artículos: " + ex.Message);
                    }
                }
                else
                {
                    
                }
            }
        }

    }
}