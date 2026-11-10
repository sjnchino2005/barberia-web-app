using Microsoft.AspNetCore.Mvc;

namespace BarberiaWebApp.API.Controllers
{
    public class HomeController : Controller
    {
        [HttpGet("/")]
        [HttpGet("/cliente/perfil")]
        public IActionResult Perfil()
        {
            return View();
        }
        [HttpGet("/turnero")]
        public IActionResult Turnero()
        {
            return View();
        }

        [HttpGet("/barbero")]
        public IActionResult Barbero()
        {
            return View();
        }
    }
}