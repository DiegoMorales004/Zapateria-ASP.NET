using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Zapateria.Models;

namespace Zapateria.Controllers
{
    public class ZapatoController : Controller
    {

        private readonly PruebaAPIPrendasContext _context;
        private readonly ILogger<ZapatoController> _logger;

        public ZapatoController(PruebaAPIPrendasContext context, ILogger<ZapatoController> logger)
        {
            _context = context;
            _logger = logger;
        }

        public async Task<IActionResult> Index()
        {

            // List<Zapato> listaDeZapatos = await _context.Zapatos.ToListAsync();
            List<Zapato> listaDeZapatos = await _context.Zapatos.Include(z => z.TallaNavigation).ToListAsync();

            return View( listaDeZapatos);
        }


        public async Task<IActionResult> Agregar()
        {
            Zapato zapato = new Zapato();
            zapato.FechaSalida = DateTime.Now;
            ViewBag.tallas = await _context.Tallas.ToListAsync();
            return View("Editar", zapato);
        }

        public async Task<IActionResult> Editar(int id)
        {
            var zapato = await _context.Zapatos.FindAsync(id);

            if (zapato == null)
            {
                return RedirectToAction("NoEncontrado", "Error");
            }

            ViewBag.tallas = await _context.Tallas.ToListAsync();

            return View( zapato );
        }

        [HttpPost]
        public async Task<ActionResult> Editar(Zapato zapato)
        {

            if ( zapato.IdZapato < 1)
            {
                _context.Zapatos.Add(zapato);
            }
            else
            {
            _context.Zapatos.Update(zapato);
            }
            await _context.SaveChangesAsync();
            return RedirectToAction("Index", "Zapato");
        }

    }
}
