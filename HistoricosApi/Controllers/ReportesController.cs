using Historicos.Application.CasoUso;
using Microsoft.AspNetCore.Mvc;

namespace HistoricosApi.Controllers
{
    [ApiController]
    [Route("api/reportes")]
    public class ReportesController : ControllerBase
    {
        private readonly ObtenerHistorialPorNumeroSerie _estados;
        private readonly ObtenerProblemasRecurrentes _problemas;
        private readonly ObtenerTiemposPromedioEtapas _tiempos;
        private readonly ObtenerPedidosRetrasados _retrasos;

        private readonly ILogger<ReportesController> _logger;

        public ReportesController(ObtenerHistorialPorNumeroSerie estados,
                                  ObtenerProblemasRecurrentes problemas,
                                  ObtenerTiemposPromedioEtapas tiempos,
                                  ObtenerPedidosRetrasados retrasos,
                                  ILogger<ReportesController> logger)
        {

            _estados = estados;
            _problemas = problemas;
            _tiempos = tiempos;
            _retrasos = retrasos;
            _logger = logger;

        }

        [HttpGet(Name = "estados-por-pedido/{numeroSerie}")]
        public async Task<IActionResult> GetEstados(string numeroSerie) => Ok(await _estados.Ejecutar(numeroSerie));

        [HttpGet("problemas-recurrentes")]
        public async Task<IActionResult> GetProblemas([FromQuery] int top = 5) => Ok(await _problemas.Ejecutar(top));

        [HttpGet("tiempos-promedio")]
        public async Task<IActionResult> GetTiempos() => Ok(await _tiempos.Ejecutar());

        [HttpGet("pedidos-retrasados")]
        public async Task<IActionResult> GetRetrasos([FromQuery] DateTime fechaCorte) => Ok(await _retrasos.Ejecutar(fechaCorte));


        /*public ReportesController(ILogger<ReportesController> logger)
        {
            _logger = logger;
        }

        [HttpGet(Name = "GetWeatherForecast")]
        public IEnumerable<WeatherForecast> Get()
        {
            return Enumerable.Range(1, 5).Select(index => new WeatherForecast
            {
                Date = DateOnly.FromDateTime(DateTime.Now.AddDays(index)),
                TemperatureC = Random.Shared.Next(-20, 55),
                Summary = Summaries[Random.Shared.Next(Summaries.Length)]
            })
            .ToArray();
        }*/
    }
}