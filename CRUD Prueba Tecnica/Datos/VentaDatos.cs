using CRUD_Prueba_Tecnica.Models;
using System.Data.SqlClient;
using System.Data;

namespace CRUD_Prueba_Tecnica.Datos
{
    public class VentaDatos
    {
        public bool SaveVenta(VentaModel oVenta)
        {
            bool cambioExitoso;

            try
            {
                var cn = new Conexion();

                using (var conexion = new SqlConnection(cn.getCadenaSQL()))
                {
                    conexion.Open();
                    SqlCommand cmd = new SqlCommand("SPI_SAVEVENTA", conexion);
                    cmd.Parameters.AddWithValue("IdProducto", oVenta.IdProducto);
                    cmd.Parameters.AddWithValue("PrecioVenta", oVenta.PrecioVenta);
                    cmd.Parameters.AddWithValue("GananciaVenta", oVenta.GananciaVenta);
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

        public List<VentaModel> GetGanancias()
        {

            var ListaGanancias = new List<VentaModel>();

            var cn = new Conexion();

            using (var conexion = new SqlConnection(cn.getCadenaSQL()))
            {
                conexion.Open();
                SqlCommand cmd = new SqlCommand("SPS_GETGANANCIAS", conexion);
                cmd.CommandType = CommandType.StoredProcedure;

                using (var dr = cmd.ExecuteReader())
                {

                    while (dr.Read())
                    {
                        ListaGanancias.Add(new VentaModel()
                        {
                            IdVenta = Convert.ToInt32(dr["IdVenta"]),
                            IdProducto = Convert.ToInt32(dr["IdProducto"]),
                            NombreProducto = dr["NombreProducto"].ToString(),
                            PrecioBase = Convert.ToInt32(dr["PrecioBase"]),
                            PrecioVenta = Convert.ToInt32(dr["PrecioVenta"]),
                            GananciaVenta = Convert.ToInt32(dr["GananciaVenta"])
                        });

                    }
                }
            }

            return ListaGanancias;
        }
    }
}
