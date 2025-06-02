using Historicos.Application.DTOs;
using Historicos.Application.Interfaces;

namespace Historicos.Application.CasoUso
{
    public class ObtenerHistoricos
    {
        private readonly IHistoricoDespachoQuery _repository;
        public ObtenerHistoricos(IHistoricoDespachoQuery repository) => _repository = repository;

        public Task<List<EstadoHistoricoDto>> Ejecutar() => _repository.ObtenerHistoricos();
    }
}
