using CRUD_Prueba_Tecnica.Models;
using System.Data.SqlClient;
using System.Data;

namespace CRUD_Prueba_Tecnica.Datos
{
    public class ProductoDatos
    {
        public List<ProductoModel> GetProductos()
        {

            var ListaProductos = new List<ProductoModel>();

            var cn = new Conexion();

            using (var conexion = new SqlConnection(cn.getCadenaSQL()))
            {
                conexion.Open();
                SqlCommand cmd = new SqlCommand("SPS_GETPRODUCTOS", conexion);
                cmd.Parameters.AddWithValue("IdProducto", 0);
                cmd.CommandType = CommandType.StoredProcedure;

                using (var dr = cmd.ExecuteReader())
                {

                    while (dr.Read())
                    {
                        ListaProductos.Add(new ProductoModel()
                        {
                            IdProducto = Convert.ToInt32(dr["IdProducto"]),
                            NombreProducto = dr["NombreProducto"].ToString(),
                            DescripcionProducto = dr["DescripcionProducto"].ToString(),
                            CantidadDisponible = Convert.ToInt32(dr["CantidadDisponible"]),
                            PrecioBase = Convert.ToInt32(dr["PrecioBase"]),
                            PrecioVenta = Convert.ToInt32(dr["PrecioVenta"])
                        });

                    }
                }
            }

            return ListaProductos;
        }

        public ProductoModel GetProducto(int IdProducto)
        {

            var oProducto = new ProductoModel();

            var cn = new Conexion();

            using (var conexion = new SqlConnection(cn.getCadenaSQL()))
            {
                conexion.Open();
                SqlCommand cmd = new SqlCommand("SPS_GETPRODUCTOS", conexion);
                cmd.Parameters.AddWithValue("IdProducto", IdProducto);
                cmd.CommandType = CommandType.StoredProcedure;

                using (var dr = cmd.ExecuteReader())
                {

                    while (dr.Read())
                    {
                        oProducto.IdProducto = Convert.ToInt32(dr["IdProducto"]);
                        oProducto.NombreProducto = dr["NombreProducto"].ToString();
                        oProducto.DescripcionProducto = dr["DescripcionProducto"].ToString();
                        oProducto.CantidadDisponible = Convert.ToInt32(dr["CantidadDisponible"]);
                        oProducto.PrecioBase = Convert.ToInt32(dr["PrecioBase"]);
                        oProducto.PrecioVenta = Convert.ToInt32(dr["PrecioVenta"]);
                    }
                }
            }

            return oProducto;
        }

        public bool SaveProducto(ProductoModel oProducto)
        {
            bool cambioExitoso;

            try
            {
                var cn = new Conexion();

                using (var conexion = new SqlConnection(cn.getCadenaSQL()))
                {
                    conexion.Open();
                    SqlCommand cmd = new SqlCommand("SPI_SAVEPRODUCTO", conexion);
                    cmd.Parameters.AddWithValue("NombreProducto", oProducto.NombreProducto );
                    cmd.Parameters.AddWithValue("DescripcionProducto", oProducto.DescripcionProducto );
                    cmd.Parameters.AddWithValue("CantidadDisponible", oProducto.CantidadDisponible );
                    cmd.Parameters.AddWithValue("PrecioBase", oProducto.PrecioBase );
                    cmd.Parameters.AddWithValue("PrecioVenta", oProducto.PrecioVenta );
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.ExecuteNonQuery();
                }
                cambioExitoso = true;
            }
            catch (Exception e)
            {
                string error = e.Message;
                cambioExitoso = false;
            }
            return cambioExitoso;
        }


        public bool EditarProducto(ProductoModel oProducto)
        {
            bool CambioExitoso;

            try
            {
                var cn = new Conexion();

                using (var conexion = new SqlConnection(cn.getCadenaSQL()))
                {
                    conexion.Open();
                    SqlCommand cmd = new SqlCommand("SPU_UPDATEPRODUCTO", conexion);
                    cmd.Parameters.AddWithValue("IdProducto", oProducto.IdProducto);
                    cmd.Parameters.AddWithValue("NombreProducto", oProducto.NombreProducto);
                    cmd.Parameters.AddWithValue("DescripcionProducto", oProducto.DescripcionProducto);
                    cmd.Parameters.AddWithValue("CantidadDisponible", oProducto.CantidadDisponible);
                    cmd.Parameters.AddWithValue("PrecioBase", oProducto.PrecioBase);
                    cmd.Parameters.AddWithValue("PrecioVenta", oProducto.PrecioVenta);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.ExecuteNonQuery();
                }
                CambioExitoso = true;
            }
            catch (Exception e)
            {
                string error = e.Message;
                CambioExitoso = false;
            }
            return CambioExitoso;
        }

        public bool EliminarProducto(int IdProducto)
        {
            bool CambioExitoso;
            try
            {
                var cn = new Conexion();
                using (var conexion = new SqlConnection(cn.getCadenaSQL()))
                {
                    conexion.Open();
                    SqlCommand cmd = new SqlCommand("SPD_DELETEPRODUCTO", conexion);
                    cmd.Parameters.AddWithValue("IdProducto", IdProducto);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.ExecuteNonQuery();
                }
                CambioExitoso = true;
            }
            catch (Exception e)
            {
                string error = e.Message;
                CambioExitoso = false;
            }
            return CambioExitoso;
        }

        public bool VentaProducto(ProductoModel oProducto)
        {
            bool cambioExitoso;

            try
            {
                var cn = new Conexion();

                using (var conexion = new SqlConnection(cn.getCadenaSQL()))
                {
                    conexion.Open();
                    SqlCommand cmd = new SqlCommand("SPI_SAVEVENTA", conexion);
                    cmd.Parameters.AddWithValue("IdProducto", oProducto.IdProducto);
                    cmd.Parameters.AddWithValue("PrecioVenta", oProducto.PrecioVenta);
                    cmd.Parameters.AddWithValue("GananciaVenta", oProducto.PrecioVenta-oProducto.PrecioBase);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.ExecuteNonQuery();
                }
                cambioExitoso = true;
            }
            catch (Exception e)
            {
                string error = e.Message;
                cambioExitoso = false;
            }
            return cambioExitoso;
        }
    }
}
