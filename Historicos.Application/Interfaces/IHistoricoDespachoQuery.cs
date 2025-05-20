using Historicos.Application.DTOs;

namespace Historicos.Application.Interfaces
{
    public interface IHistoricoDespachoQuery
    {
        Task<List<EstadoHistoricoDto>> ObtenerHistorialPorNumeroSerie(string numeroSerie);
        Task<List<TiempoEtapaDto>> CalcularTiemposPromedio();
        Task<List<PedidoRetrasadoDto>> ObtenerPedidosRetrasados(DateTime fechaCorte);
    }
}
