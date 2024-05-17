using Business.Articulo;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace TPCarrito_Equipo_29
{
    public partial class _Default : Page
    {
        private List<ArticuloEntity> listArticulos;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                LoadData();
                BindListView();
                GeneratePagination();
            }
        }

        private void BindListView()
        {
            int pageIndex = 0;
            if (Request.QueryString["page"] != null)
            {
                pageIndex = Convert.ToInt32(Request.QueryString["page"]) - 1;
            }

            var pagedDataSource = new PagedDataSource
            {
                DataSource = listArticulos,
                AllowPaging = true,
                PageSize = 8,
                CurrentPageIndex = pageIndex
            };

            dgvArticulos.DataSource = pagedDataSource;
            dgvArticulos.DataBind();
        }

        private void LoadData()
        {
            var articuloBusinees = new ArticuloBussines();
            try
            {
                listArticulos = articuloBusinees.GetArticulos();

                foreach (var item in listArticulos)
                {
                    if (!CargarImagen(item.Imagen.UrlImagen))
                    {
                        item.Imagen.UrlImagen = "https://img.freepik.com/vector-gratis/ilustracion-icono-galeria_53876-27002.jpg?size=626&ext=jpg&ga=GA1.1.1687694167.1713916800&semt=ais";
                    }
                }

                ViewState["articulos"] = listArticulos;
            }
            catch (Exception ex)
            {
                throw new Exception("Ocurrio un error al intentar obtener los articulos: " + ex.Message);
            }
        }

        private void GeneratePagination()
        {
            int totalPages = (int)Math.Ceiling((double)listArticulos.Count / 8);

            StringBuilder paginationHtml = new StringBuilder();
            for (int i = 1; i <= totalPages; i++)
            {
                string activeClass = i == GetCurrentPageIndex() ? "active" : "";
                paginationHtml.AppendFormat("<li class='page-item {1}'><a class='page-link' href='?page={0}'>{0}</a></li>", i, activeClass);
            }

            litPagination.Text = paginationHtml.ToString();
        }

        private int GetCurrentPageIndex()
        {
            int pageIndex = 1;
            if (Request.QueryString["page"] != null)
            {
                pageIndex = Convert.ToInt32(Request.QueryString["page"]);
            }
            return pageIndex;
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

        protected void btnAgregar_Click(object sender, EventArgs e)
        {
            int articuloId = int.Parse(((System.Web.UI.WebControls.LinkButton)sender).CommandArgument);
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
            }
            catch(Exception ex)
            {
                throw new Exception("Ocurrio un error al intentar obtener los articulos: " + ex.Message);
            }
            
        }

    }
}