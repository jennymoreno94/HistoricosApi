using Historicos.Application.DTOs;
using Historicos.Application.Interfaces;

namespace Historicos.Application.CasoUso
{
    public class ObtenerTiemposPromedioEtapas
    {
        private readonly IHistoricoDespachoQuery _repository;
        public ObtenerTiemposPromedioEtapas(IHistoricoDespachoQuery repository) => _repository = repository;

        public Task<List<TiempoEtapaDto>> Ejecutar() => _repository.CalcularTiemposPromedio();
    }
}
