using Microsoft.AspNetCore.Mvc;

namespace Zapateria.Controllers
{
    public class ErrorController : Controller
    {
        public IActionResult NoEncontrado()
        {
            return View();
        }
    }
}
