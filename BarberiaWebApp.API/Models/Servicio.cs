using System.ComponentModel.DataAnnotations;

namespace BarberiaWebApp.API.Models
{
    public class Servicio
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Nombre { get; set; } = string.Empty;
        public decimal PrecioBs { get; set; }
        public int DuracionMinutos { get; set; } = 30;
    }
}