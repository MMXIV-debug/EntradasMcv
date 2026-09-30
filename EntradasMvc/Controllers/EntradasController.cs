using EntradasMvc.Models;
using EntradasMvc.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace EntradasMvc.Controllers
{
    public class EntradasController : Controller
    {
        [HttpGet]
        public IActionResult Index()
        {
            var viewModel = new CotizacionInputViewModel();
            return View(viewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Calcular(CotizacionInputViewModel viewModel)
        {
            if (!ModelState.IsValid)
            {
                viewModel.TiposEntrada = CargarTiposEntrada();
                return View("Index", viewModel);
            }
            var cotizacion = new Cotizacion 
            {
                Cliente = viewModel.Cliente,
                Cantidad = viewModel.Cantidad,
                TipoEntreda = viewModel.TipoEntreda
            };
            var resultadoViewModel = new ResultadoCotizacionViewModel
            {
                Cotizacion = cotizacion,
                Evento = "Concierto Web III",
                FechaEvento = new DateTime(2026, 11, 15),
                Mensaje = "Gracias por realizar su cotización"
            };
            
            return View("Resultado", resultadoViewModel);
        }
        private List<SelectListItem> CargarTiposEntrada()
        {
            return new List<SelectListItem>
            {
                new SelectListItem { Value = "General", Text = "General" },
                new SelectListItem { Value = "VIP", Text = "VIP" },
                new SelectListItem { Value = "Platea", Text = "Platea" }
            };
        }
    }
}