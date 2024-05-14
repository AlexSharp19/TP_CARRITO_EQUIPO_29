using Business.Articulo;
using System;
using System.Web.UI;

namespace TPCarrito_Equipo_29
{
    public partial class _Default : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            var articuloBusinees = new ArticuloBussines();
            dgvArticulos.DataSource = articuloBusinees.GetArticulo();
            dgvArticulos.DataBind();
        }

        protected void btnDetalles_Click(object sender, EventArgs e)
        {
            // Código para manejar el evento Click del botón
            string message = "El botón fue clickeado";
            ClientScript.RegisterStartupScript(this.GetType(), "alert", "alert('" + message + "');", true);
        }
    }
}