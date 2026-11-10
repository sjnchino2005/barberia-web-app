using BarberiaWebApp.API.Models;

namespace BarberiaWebApp.API.Data
{
    public static class DbInitializer
    {
        public static void Initialize(ApplicationDbContext context)
        {
            context.Database.EnsureCreated();

            if (!context.Clientes.Any())
            {
                var cliente = new Cliente
                {
                    NombreCompleto = "Gabriel Hurtado",
                    Telefono = "77000000",
                    Email = "gabriel@gmail.com",
                    PuntosAcumulados = 50,
                    HistorialCortes = new List<HistorialCorte>
                    {
                        new HistorialCorte { TipoCorte = "Fade Medio + Barba", PrecioBs = 50, NotasTecnicas = "Degradado al 0.5 laterales, peinado mate" },
                        new HistorialCorte { TipoCorte = "Corte Clásico", PrecioBs = 40, NotasTecnicas = "Tijera arriba, perfilado de patillas" }
                    }
                };
                context.Clientes.Add(cliente);
            }

            if (!context.Turnos.Any())
            {
                context.Turnos.AddRange(
                    new Turno { NombreCliente = "Carlos Mendoza", BarberoAsignado = "Mateo", Servicio = "Corte Fade", Estado = "En atencion" },
                    new Turno { NombreCliente = "Neptaly Rodriguez", BarberoAsignado = "Luis", Servicio = "Perfilado de Barba", Estado = "En espera" },
                    new Turno { NombreCliente = "Sebastian Rivas", BarberoAsignado = "Mateo", Servicio = "Combo Completo", Estado = "En espera" }
                );
            }

            context.SaveChanges();

        }
    }
}