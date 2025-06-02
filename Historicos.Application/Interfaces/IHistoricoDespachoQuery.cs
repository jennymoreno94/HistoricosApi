using Historicos.Application.DTOs;

namespace Historicos.Application.Interfaces
{
    public interface IHistoricoDespachoQuery
    {
        Task<List<EstadoHistoricoDto>> ObtenerHistoricos();
        Task<List<TiempoEtapaDto>> CalcularTiemposPromedio();
        Task<List<PedidoRetrasadoDto>> ObtenerPedidosRetrasados();
    }
}
