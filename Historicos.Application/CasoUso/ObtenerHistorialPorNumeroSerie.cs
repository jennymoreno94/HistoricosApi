using Historicos.Application.DTOs;
using Historicos.Application.Interfaces;

namespace Historicos.Application.CasoUso
{
    public class ObtenerHistorialPorNumeroSerie
    {
        private readonly IHistoricoDespachoQuery _repository;
        public ObtenerHistorialPorNumeroSerie(IHistoricoDespachoQuery repository) => _repository = repository;

        public Task<List<EstadoHistoricoDto>> Ejecutar(string numeroSerie) => _repository.ObtenerHistorialPorNumeroSerie(numeroSerie);
    }
}
