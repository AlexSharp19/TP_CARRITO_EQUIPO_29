using Business.Articulo;
using Microsoft.AspNet.FriendlyUrls;
using System;
using System.Web.UI;
using System.Web.UI.WebControls;

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

            string articuloID = ((System.Web.UI.WebControls.LinkButton)sender).CommandArgument;
            Response.Redirect("DetalleArticulos.aspx?id=" + articuloID);
        }
    }
}