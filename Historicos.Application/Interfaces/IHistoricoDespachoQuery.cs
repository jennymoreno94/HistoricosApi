using Historicos.Application.DTOs;
using Historicos.Domain.Entitidades;


namespace Historicos.Application.Interfaces
{
    public interface IHistoricoDespachoQuery
    {
        Task<List<Historico>> ObtenerHistoricos();
        Task<List<TiempoEtapaDto>> CalcularTiemposPromedio();
        Task<List<PedidoRetrasadoDto>> ObtenerPedidosRetrasados();
    }
}
