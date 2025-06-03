using Historicos.Application.DTOs;
using Historicos.Application.Interfaces;

namespace Historicos.Application.CasoUso
{
    public class ObtenerHistoricos
    {
        private readonly IHistoricoDespachoQuery _query;

        public ObtenerHistoricos(IHistoricoDespachoQuery query)
        {
            _query = query;
        }

        public async Task<IEnumerable<HistoricoDto>> Ejecutar()
        {
            var historicos = await _query.ObtenerHistoricos();
            return historicos.Select(HistoricoDto.FromDomain);
        }
    }
}
