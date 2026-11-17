using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using BarberiaWebApp.API.Data;
using BarberiaWebApp.API.DTOs;

namespace BarberiaWebApp.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AuthController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public AuthController(ApplicationDbContext context)
        {
            _context = context;
        }

        // POST: api/auth/login
        [HttpPost("login")]
        public async Task<ActionResult<SesionUsuarioDto>> Login([FromBody] LoginDto dto)
        {
            var usuario = await _context.Usuarios
                .FirstOrDefaultAsync(u => u.Username == dto.Username && u.Password == dto.Password);

            if (usuario == null)
            {
                return Unauthorized(new { mensaje = "Usuario o contraseña incorrectos" });
            }

            return Ok(new SesionUsuarioDto
            {
                Id = usuario.Id,
                Username = usuario.Username,
                NombreCompleto = usuario.NombreCompleto,
                Rol = usuario.Rol
            });
        }
    }
}