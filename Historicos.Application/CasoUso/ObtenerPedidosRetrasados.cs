using Historicos.Application.DTOs;
using Historicos.Application.Interfaces;

namespace Historicos.Application.CasoUso
{
    public class ObtenerPedidosRetrasados
    {
        private readonly IHistoricoDespachoQuery _repository;
        public ObtenerPedidosRetrasados(IHistoricoDespachoQuery repository) => _repository = repository;

        public Task<List<PedidoRetrasadoDto>> Ejecutar(DateTime fechaCorte) => _repository.ObtenerPedidosRetrasados(fechaCorte);
    }
}
