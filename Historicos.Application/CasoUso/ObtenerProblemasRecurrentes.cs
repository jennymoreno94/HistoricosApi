using Historicos.Application.DTOs;
using Historicos.Application.Interfaces;

namespace Historicos.Application.CasoUso
{
    public class ObtenerProblemasRecurrentes
    {
        private readonly IHistoricoNovedadQuery _repository;
        public ObtenerProblemasRecurrentes(IHistoricoNovedadQuery repository) => _repository = repository;

        public Task<List<ProblemaRecurrenteDto>> Ejecutar(int top) => _repository.ObtenerProblemasRecurrentes(top);
    }
}
