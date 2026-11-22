using System.ComponentModel.DataAnnotations;

namespace BarberiaWebApp.API.Models
{
    public class Barbero
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string NombreCompleto { get; set; } = string.Empty;
        public string Especialidad { get; set; } = string.Empty;
        public decimal PorcentajeComision { get; set; } = 50; // % de ganancia para el barbero
        public bool Activo { get; set; } = true;
    }
}