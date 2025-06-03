using Historicos.Application.CasoUso;
using Microsoft.AspNetCore.Mvc;

namespace HistoricosApi.Controllers
{
    [ApiController]
    [Route("api/reportes")]
    public class ReportesController : ControllerBase
    {
        private readonly ObtenerHistoricos _estados;
        private readonly ObtenerProblemasRecurrentes _problemas;
        private readonly ObtenerTiemposPromedioEtapas _tiempos;
        private readonly ObtenerPedidosRetrasados _retrasos;

        private readonly ILogger<ReportesController> _logger;

        public ReportesController(ObtenerHistoricos estados,
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

        [HttpGet("historicos")]
        public async Task<IActionResult> GetHistoricos() => Ok(await _estados.Ejecutar());

        [HttpGet("problemas-recurrentes")]
        public async Task<IActionResult> GetProblemas() => Ok(await _problemas.Ejecutar());

        [HttpGet("tiempos-promedio")]
        public async Task<IActionResult> GetTiempos() => Ok(await _tiempos.Ejecutar());

        [HttpGet("pedidos-retrasados")]
        public async Task<IActionResult> GetRetrasos() => Ok(await _retrasos.Ejecutar());

    }
}