using Historicos.Application.DTOs;

namespace Historicos.Application.Interfaces
{
    public interface IHistoricoNovedadQuery
    {
        Task<List<ProblemaRecurrenteDto>> ObtenerProblemasRecurrentes();

    }
}
