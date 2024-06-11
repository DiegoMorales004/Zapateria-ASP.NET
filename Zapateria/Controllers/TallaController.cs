using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Zapateria.Models;

namespace Zapateria.Controllers
{
    public class TallaController : Controller
    {

        private readonly PruebaAPIPrendasContext _context;

        public TallaController(PruebaAPIPrendasContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            return View(await _context.Tallas.ToListAsync());
        }

        public IActionResult Agregar(Talla talla)
        {
            return View("Editar",talla);
        }

        public async Task<IActionResult> Editar(int id)
        {
            var talla = await _context.Tallas.FindAsync(id);

            if (talla == null)
            {
                return RedirectToAction("NoEncontrado", "Error");
            }

            return View(talla);

        }

        [HttpPost]
        public async Task<IActionResult> Editar(Talla talla)
        {
            if(talla.IdTalla < 1)
            {
                _context.Tallas.Add(talla);
            }
            else
            {
                _context.Tallas.Update(talla);
            }

            await _context.SaveChangesAsync();

            return RedirectToAction("Index");

        }
    }
}
