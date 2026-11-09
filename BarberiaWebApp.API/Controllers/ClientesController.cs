using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using BarberiaWebApp.API.Data;
using BarberiaWebApp.API.DTOs;

namespace BarberiaWebApp.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ClientesController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public ClientesController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: api/clientes/5/perfil (SCRUM-2)
        [HttpGet("{id}/perfil")]
        public async Task<ActionResult<ClienteDto>> GetPerfil(int id)
        {
            var cliente = await _context.Clientes.FindAsync(id);

            if (cliente == null)
                return NotFound(new { mensaje = "Cliente no encontrado" });

            return new ClienteDto
            {
                Id = cliente.Id,
                NombreCompleto = cliente.NombreCompleto,
                Telefono = cliente.Telefono,
                Email = cliente.Email,
                PuntosAcumulados = cliente.PuntosAcumulados
            };
        }

        // GET: api/clientes/5/historial (SCRUM-3)
        [HttpGet("{id}/historial")]
        public async Task<ActionResult<IEnumerable<HistorialCorteDto>>> GetHistorial(int id)
        {
            var clienteExiste = await _context.Clientes.AnyAsync(c => c.Id == id);
            if (!clienteExiste)
                return NotFound(new { mensaje = "Cliente no encontrado" });

            var historial = await _context.HistorialCortes
                .Where(h => h.ClienteId == id)
                .OrderByDescending(h => h.FechaServicio)
                .Select(h => new HistorialCorteDto
                {
                    Id = h.Id,
                    FechaServicio = h.FechaServicio,
                    TipoCorte = h.TipoCorte,
                    PrecioBs = h.PrecioBs,
                    NotasTecnicas = h.NotasTecnicas
                })
                .ToListAsync();

            return Ok(historial);
        }
    }
}