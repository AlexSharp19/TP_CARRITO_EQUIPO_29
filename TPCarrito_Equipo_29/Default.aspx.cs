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
            try
            {
                dgvArticulos.DataSource = articuloBusinees.GetArticulo(1);
                dgvArticulos.DataBind();
            }
            catch(Exception ex)
            {
                throw new Exception("Ocurrio un error al intentar obtener los articulos: " + ex.Message);
            }
        }

        protected void btnDetalles_Click(object sender, EventArgs e)
        {

            string articuloID = ((System.Web.UI.WebControls.LinkButton)sender).CommandArgument;
            Response.Redirect("DetalleArticulos.aspx?id=" + articuloID);
        }
    }
}