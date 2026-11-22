using BarberiaWebApp.API.Models;

namespace BarberiaWebApp.API.Data
{
    public static class DbInitializer
    {
        public static void Initialize(ApplicationDbContext context)
        {
            context.Database.EnsureCreated();

            if (!context.Usuarios.Any())
            {
                context.Usuarios.AddRange(
                    new Usuario { Username = "admin", Password = "123", Rol = "Admin", NombreCompleto = "Administrador Principal" },
                    new Usuario { Username = "barbero1", Password = "123", Rol = "Barbero", NombreCompleto = "Mateo Barbero" },
                    new Usuario { Username = "cliente1", Password = "123", Rol = "Cliente", NombreCompleto = "Gabriel Hurtado" }
                );
            }

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
            if (!context.Barberos.Any())
            {
                context.Barberos.AddRange(
                    new Barbero { NombreCompleto = "Mateo Barbero", Especialidad = "Fades y Diseño", PorcentajeComision = 50, Activo = true },
                    new Barbero { NombreCompleto = "Luis Mendoza", Especialidad = "Barba y Corte Clásico", PorcentajeComision = 45, Activo = true }
                );
            }

            if (!context.Servicios.Any())
            {
                context.Servicios.AddRange(
                    new Servicio { Nombre = "Corte Fade + Perfilado", PrecioBs = 50, DuracionMinutos = 40 },
                    new Servicio { Nombre = "Corte Clásico", PrecioBs = 40, DuracionMinutos = 30 },
                    new Servicio { Nombre = "Arreglo de Barba VIP", PrecioBs = 30, DuracionMinutos = 25 },
                    new Servicio { Nombre = "Combo Completo (Corte + Barba)", PrecioBs = 70, DuracionMinutos = 60 }
                );
            }

            if (!context.Productos.Any())
            {
                context.Productos.AddRange(
                    new Producto { Nombre = "Cera Mate Profesional 150g", Categoria = "Venta", PrecioVentaBs = 65, StockActual = 12, StockMinimo = 5 },
                    new Producto { Nombre = "Aceite Hidratante de Barba", Categoria = "Venta", PrecioVentaBs = 55, StockActual = 3, StockMinimo = 5 }, // Alerta stock bajo
                    new Producto { Nombre = "Cuchillas Gillette (Caja x100)", Categoria = "Insumo", PrecioVentaBs = 0, StockActual = 2, StockMinimo = 4 } // Alerta stock bajo
                );
            }
            context.SaveChanges();

        }
    }
}