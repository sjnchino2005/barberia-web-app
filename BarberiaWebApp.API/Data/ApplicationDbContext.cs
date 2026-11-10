using Microsoft.EntityFrameworkCore;
using BarberiaWebApp.API.Models;

namespace BarberiaWebApp.API.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }

        public DbSet<Cliente> Clientes => Set<Cliente>();
        public DbSet<HistorialCorte> HistorialCortes => Set<HistorialCorte>();
        public DbSet<Turno> Turnos => Set<Turno>();
    }
}