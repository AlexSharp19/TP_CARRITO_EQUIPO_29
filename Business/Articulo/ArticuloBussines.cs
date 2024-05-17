using Dao.Implements;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Deployment.Internal;


namespace Business.Articulo
{
    public class ArticuloBussines
    {
        public List<ArticuloEntity> GetArticulo(int pagina)
        {
            var listArticulos = new List<ArticuloEntity>();
            var ArticuloDao = new ArticuloImp();
            try
            {
                listArticulos = ArticuloDao.GetArticulo(pagina);

                return listArticulos;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public int CantidadRegistros()
        {
            var ArticuloDao = new ArticuloImp();
            try
            {
                return ArticuloDao.CantidadRegistros();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public int agregarArticulo(ArticuloEntity nuevo)
        {
            ArticuloImp artImp = new ArticuloImp();
            try
            {
                return artImp.AgregarArticulo(nuevo);
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public void Eliminar(int id)
        {
            ArticuloImp articuloImp = new ArticuloImp();
            try
            {
                articuloImp.Eliminar(id);
            }
            catch (Exception ex)
            {

                throw ex;
            }

        }
        public int ModificarArticulo(ArticuloEntity categoria)
        {
            ArticuloImp catImp = new ArticuloImp();

            try
            {
                return catImp.ModificarArticulo(categoria);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public ArticuloEntity getByID(int id)
        {
            ArticuloImp articulo = new ArticuloImp();
            try
            {
                return articulo.getByID(id);
            }
            catch (Exception ex)
            {

                throw ex;
            }

        }
    }

}
