using Business.Articulo;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Drawing.Printing;
using System.Net;
using System.Text;
using System.Web.UI;

namespace TPCarrito_Equipo_29
{
    public partial class _Default : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            var articuloBusinees = new ArticuloBussines();
            var listArticulos = new List<ArticuloEntity>();
            try
            {
                listArticulos = articuloBusinees.GetArticulo(1);

                foreach (var item in listArticulos)
                {
                    if (!CargarImagen(item.Imagen.UrlImagen))
                    {
                        item.Imagen.UrlImagen = "https://img.freepik.com/vector-gratis/ilustracion-icono-galeria_53876-27002.jpg?size=626&ext=jpg&ga=GA1.1.1687694167.1713916800&semt=ais";
                    }
                }

                dgvArticulos.DataSource = listArticulos;
                dgvArticulos.DataBind();

                GeneratePagination();
            }
            catch(Exception ex)
            {
                throw new Exception("Ocurrio un error al intentar obtener los articulos: " + ex.Message);
            }
        }

        private void GeneratePagination()
        {
            var articuloBusinees = new ArticuloBussines();

            try
            {
                int totalRegistros = articuloBusinees.CantidadRegistros();
                int totalPages = (int)Math.Ceiling((double)totalRegistros / 8);

                StringBuilder paginationHtml = new StringBuilder();

                for (int i = 1; i <= totalPages; i++)
                {
                    if (i == 1)
                    {
                        paginationHtml.AppendFormat("<li class='page-item active' aria-current='page'><span class='page-link'>{0}</span></li>", i);
                    }
                    else
                    {
                        paginationHtml.AppendFormat("<li class='page-item'><a  ID='ax' class='page-link' Onclick='ax_Click' href='?page={0}'>{0}</a></li>", i);
                    }
                }

                litPagination.Text = paginationHtml.ToString();
            }
            catch(Exception ex)
            {
                throw new Exception("Error: " + ex.Message);
            }
        }

        private bool CargarImagen(string url)
        {
            try
            {
                HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);
                request.Method = "HEAD";
                using (HttpWebResponse response = (HttpWebResponse)request.GetResponse())
                {
                    return (response.StatusCode == HttpStatusCode.OK);
                }
            }
            catch
            {
                return false;
            }
        }

        protected void btnDetalles_Click(object sender, EventArgs e)
        {

            string articuloID = ((System.Web.UI.WebControls.LinkButton)sender).CommandArgument;
            Response.Redirect("DetalleArticulos.aspx?id=" + articuloID);
        }
    }
}