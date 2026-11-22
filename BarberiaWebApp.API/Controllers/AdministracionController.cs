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
        // --- INVENTARIO Y STOCK (SCRUM-23) ---
        [HttpGet("productos")]
        public async Task<IActionResult> GetProductos() => Ok(await _context.Productos.ToListAsync());

        [HttpPost("productos")]
        public async Task<IActionResult> CrearProducto([FromBody] Producto producto)
        {
            _context.Productos.Add(producto);
            await _context.SaveChangesAsync();
            return Ok(producto);
        }

        [HttpPut("productos/{id}/stock")]
        public async Task<IActionResult> ActualizarStock(int id, [FromBody] int cantidadDelta)
        {
            var prod = await _context.Productos.FindAsync(id);
            if (prod == null) return NotFound();

            prod.StockActual = Math.Max(0, prod.StockActual + cantidadDelta);
            await _context.SaveChangesAsync();
            return Ok(prod);
        }

        // --- REPORTES MENSUALES Y CAJA (SCRUM-24) ---
        [HttpGet("reporte-mensual")]
        public async Task<IActionResult> GetReporteMensual()
        {
            var inicioMes = new DateTime(DateTime.Now.Year, DateTime.Now.Month, 1);

            var cortesMes = await _context.HistorialCortes
                .Where(c => c.FechaServicio >= inicioMes)
                .ToListAsync();

            var totalIngresosBs = cortesMes.Sum(c => c.PrecioBs);
            var totalServicios = cortesMes.Count;
            var ticketPromedioBs = totalServicios > 0 ? Math.Round(totalIngresosBs / totalServicios, 2) : 0;
            var productosBajoStock = await _context.Productos.CountAsync(p => p.StockActual <= p.StockMinimo);

            var desgloseServicios = cortesMes
                .GroupBy(c => c.TipoCorte)
                .Select(g => new
                {
                    Servicio = g.Key,
                    Cantidad = g.Count(),
                    SubtotalBs = g.Sum(x => x.PrecioBs)
                })
                .OrderByDescending(x => x.SubtotalBs)
                .ToList();

            return Ok(new
            {
                mes = DateTime.Now.ToString("MMMM yyyy"),
                totalIngresosBs,
                totalServicios,
                ticketPromedioBs,
                productosBajoStock,
                desgloseServicios
            });
        }
    }
}