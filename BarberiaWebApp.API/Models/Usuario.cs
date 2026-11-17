using System.ComponentModel.DataAnnotations;

namespace BarberiaWebApp.API.Models
{
    public class Usuario
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string Username { get; set; } = string.Empty;

        [Required]
        public string Password { get; set; } = string.Empty;

        // Roles: "Admin", "Barbero", "Cliente"
        public string Rol { get; set; } = "Cliente";

        public string NombreCompleto { get; set; } = string.Empty;
    }
}