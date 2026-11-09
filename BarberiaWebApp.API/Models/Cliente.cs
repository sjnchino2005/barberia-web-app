using System.ComponentModel.DataAnnotations;

namespace BarberiaWebApp.API.Models
{
    public class Cliente
    {
        [Key]
        public int Id { get; set; }

        public string NombreCompleto { get; set; } = string.Empty;
        public string Telefono { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public int PuntosAcumulados { get; set; } = 0;
        public DateTime FechaRegistro { get; set; } = DateTime.Now;

        // Relación
        public ICollection<HistorialCorte> HistorialCortes { get; set; } = new List<HistorialCorte>();
    }
}