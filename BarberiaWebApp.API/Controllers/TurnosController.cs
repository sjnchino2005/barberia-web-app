using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using BarberiaWebApp.API.Data;
using BarberiaWebApp.API.Models;

namespace BarberiaWebApp.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class TurnosController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public TurnosController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: api/turnos/activos
        [HttpGet("activos")]
        public async Task<ActionResult<IEnumerable<Turno>>> GetTurnosActivos()
        {
            var turnos = await _context.Turnos
                .Where(t => t.Estado == "En espera" || t.Estado == "En atencion")
                .OrderBy(t => t.HoraCreacion)
                .ToListAsync();

            return Ok(turnos);
        }

        // POST: api/turnos/crear
        [HttpPost("crear")]
        public async Task<ActionResult<Turno>> CrearTurno([FromBody] Turno turno)
        {
            turno.HoraCreacion = DateTime.Now;
            turno.Estado = "En espera";

            _context.Turnos.Add(turno);
            await _context.SaveChangesAsync();

            return Ok(turno);
        }

        // PUT: api/turnos/5/estado
        [HttpPut("{id}/estado")]
        public async Task<IActionResult> CambiarEstado(int id, [FromBody] string nuevoEstado)
        {
            var turno = await _context.Turnos.FindAsync(id);
            if (turno == null) return NotFound();

            turno.Estado = nuevoEstado;
            await _context.SaveChangesAsync();

            return Ok(turno);
        }
    }
}