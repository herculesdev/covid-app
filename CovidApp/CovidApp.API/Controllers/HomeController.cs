using System;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using CovidApp.Core.Interfaces.Services;

namespace CovidApp.API.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly ICasoCovidService _casoService;

        public HomeController(ILogger<HomeController> logger, ICasoCovidService casoService)
        {
            _logger = logger;
            _casoService = casoService;

            _casoService.AtualizarBaseComDadosDaApiCovid19();
        }

        [HttpGet("/casos/media")]
        public IActionResult GetMediaMovel(DateTime de, DateTime ate)
        {                
            var media = _casoService.CalcularMediaMovelPorPeriodo(de, ate);
            return Ok(media);
        }
    }
}
