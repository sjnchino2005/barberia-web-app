namespace BarberiaWebApp.API.DTOs
{
    public class ClienteDto
    {
        public int Id { get; set; }
        public string NombreCompleto { get; set; } = string.Empty;
        public string Telefono { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public int PuntosAcumulados { get; set; }
    }

    public class HistorialCorteDto
    {
        public int Id { get; set; }
        public DateTime FechaServicio { get; set; }
        public string TipoCorte { get; set; } = string.Empty;
        public decimal PrecioBs { get; set; }
        public string? NotasTecnicas { get; set; }
    }
}