using System.ComponentModel.DataAnnotations;

namespace BarberiaWebApp.API.Models
{
    public class HistorialCorte
    {
        [Key]
        public int Id { get; set; }

        public int ClienteId { get; set; }
        public DateTime FechaServicio { get; set; } = DateTime.Now;
        public string TipoCorte { get; set; } = string.Empty;
        public decimal PrecioBs { get; set; }
        public string? NotasTecnicas { get; set; }

        // Propiedad de navegación
        public Cliente? Cliente { get; set; }
    }
}