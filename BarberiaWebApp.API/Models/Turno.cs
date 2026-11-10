using System.ComponentModel.DataAnnotations;

namespace BarberiaWebApp.API.Models
{
    public class Turno
    {
        [Key]
        public int Id { get; set; }

        public string NombreCliente { get; set; } = string.Empty;
        public string BarberoAsignado { get; set; } = string.Empty;
        public string Servicio { get; set; } = string.Empty;

        // Estados: "En espera", "En atencion", "Completado", "Cancelado"
        public string Estado { get; set; } = "En espera";

        public DateTime HoraCreacion { get; set; } = DateTime.Now;
    }
}