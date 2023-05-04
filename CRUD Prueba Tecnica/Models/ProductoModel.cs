using System.ComponentModel.DataAnnotations;

namespace CRUD_Prueba_Tecnica.Models
{
    public class ProductoModel
    {
        public int IdProducto { get; set; }
        [Required(ErrorMessage = "El campo nombre es obligatorio")]
        public string? NombreProducto { get; set; }

        [MaxLength(200)]
        public string? DescripcionProducto { get; set; }

        [Required(ErrorMessage = "El campo cantidad es obligatorio")]
        public int CantidadDisponible { get; set; }

        [Required(ErrorMessage = "El campo precio base es obligatorio")]
        public int PrecioBase { get; set; }

        [Required(ErrorMessage = "El campo precio venta es obligatorio")]
        public int PrecioVenta { get; set; }
    }
}
