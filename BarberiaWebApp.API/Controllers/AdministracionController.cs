using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using BarberiaWebApp.API.Data;
using BarberiaWebApp.API.Models;

namespace BarberiaWebApp.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AdministracionController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public AdministracionController(ApplicationDbContext context)
        {
            _context = context;
        }

        // --- BARBEROS ---
        [HttpGet("barberos")]
        public async Task<IActionResult> GetBarberos() => Ok(await _context.Barberos.ToListAsync());

        [HttpPost("barberos")]
        public async Task<IActionResult> CrearBarbero([FromBody] Barbero barbero)
        {
            _context.Barberos.Add(barbero);
            await _context.SaveChangesAsync();
            return Ok(barbero);
        }

        [HttpDelete("barberos/{id}")]
        public async Task<IActionResult> EliminarBarbero(int id)
        {
            var barbero = await _context.Barberos.FindAsync(id);
            if (barbero == null) return NotFound();
            _context.Barberos.Remove(barbero);
            await _context.SaveChangesAsync();
            return Ok();
        }

        // --- SERVICIOS Y PRECIOS (Bs) ---
        [HttpGet("servicios")]
        public async Task<IActionResult> GetServicios() => Ok(await _context.Servicios.ToListAsync());

        [HttpPost("servicios")]
        public async Task<IActionResult> CrearServicio([FromBody] Servicio servicio)
        {
            _context.Servicios.Add(servicio);
            await _context.SaveChangesAsync();
            return Ok(servicio);
        }

        [HttpDelete("servicios/{id}")]
        public async Task<IActionResult> EliminarServicio(int id)
        {
            var servicio = await _context.Servicios.FindAsync(id);
            if (servicio == null) return NotFound();
            _context.Servicios.Remove(servicio);
            await _context.SaveChangesAsync();
            return Ok();
        }
    }
}