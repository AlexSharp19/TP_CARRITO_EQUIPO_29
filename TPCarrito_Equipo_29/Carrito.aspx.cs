using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;

namespace TPCarrito_Equipo_29
{
    public partial class Carrito : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                BindGrid();
            }
        }

        private void BindGrid()
        {
            if (Session["articulosSeleccionados"] != null)
            {
                List<ArticuloEntity> carrito = (List<ArticuloEntity>)Session["articulosSeleccionados"];
                gvCarrito.DataSource = carrito;
                gvCarrito.DataBind();

                decimal total = carrito.Sum(a => a.Precio);
                lblTotal.Text = "Total: " + total.ToString("C");
            }
            else
            {
                lblTotal.Text = "Total: $0.00";
            }
        }

        protected void btnEliminar_Click(object sender, EventArgs e)
        {
            int articuloId = int.Parse(((System.Web.UI.WebControls.LinkButton)sender).CommandArgument);

            if (Session["articulosSeleccionados"] != null)
            {
                List<ArticuloEntity> carrito = (List<ArticuloEntity>)Session["articulosSeleccionados"];
                ArticuloEntity articulo = carrito.FirstOrDefault(a => a.Id == articuloId);

                if (articulo != null)
                {
                    carrito.Remove(articulo);
                    Session["articulosSeleccionados"] = carrito;
                    BindGrid();
                }
            }
        }

    }
}