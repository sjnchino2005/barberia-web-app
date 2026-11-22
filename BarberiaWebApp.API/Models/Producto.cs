using System.ComponentModel.DataAnnotations;

namespace BarberiaWebApp.API.Models
{
    public class Producto
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string Nombre { get; set; } = string.Empty;

        public string Categoria { get; set; } = "Insumo"; // "Venta" o "Insumo"
        public decimal PrecioVentaBs { get; set; }
        public int StockActual { get; set; }
        public int StockMinimo { get; set; } = 5; // Alerta si llega a 5 o menos
    }
}