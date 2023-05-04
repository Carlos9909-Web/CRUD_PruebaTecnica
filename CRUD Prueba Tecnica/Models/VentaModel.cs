namespace CRUD_Prueba_Tecnica.Models
{
    public class VentaModel
    {
        public int IdVenta { get; set; }
        public int IdProducto{ get; set; }
        public string? NombreProducto { get; set; }

        public int PrecioBase { get; set; }
        public int PrecioVenta { get; set; }
        public int GananciaVenta { get; set; }
    }
}
