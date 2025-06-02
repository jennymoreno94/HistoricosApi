using Historicos.Application.DTOs;
using Historicos.Application.Interfaces;
using Microsoft.Azure.Cosmos;
using Microsoft.Extensions.Configuration;


namespace Historicos.Infrastructure.Repositorios
{
    public class HistoricoDespachoQuery : IHistoricoDespachoQuery
    {
        private readonly Container _container;
        public HistoricoDespachoQuery(CosmosClient client, IConfiguration config)
        {
            _container = client.GetContainer(config["CosmosDb:Database"], config["CosmosDb:ContainerDespachos"]);
        }

        public async Task<List<EstadoHistoricoDto>> ObtenerHistoricos()
        {
            var query = new QueryDefinition("SELECT c.numeroSerie, c.estadoAnterior, c.estadoNuevo, c.fechaInicio AS FechaCambio, c.ruta, c.ciudad FROM c  ORDER BY c.fechaInicio");
            var iterator = _container.GetItemQueryIterator<EstadoHistoricoDto>(query);
            var resultados = new List<EstadoHistoricoDto>();
            while (iterator.HasMoreResults) resultados.AddRange(await iterator.ReadNextAsync());
            return resultados;
        }

        public async Task<List<TiempoEtapaDto>> CalcularTiemposPromedio()
        {
            var query = new QueryDefinition("SELECT c.estadoNuevo AS Etapa, AVG(DateTimeDiff('minute', c.fechaInicio, c.fechaFin)) AS TiempoPromedioMinutos FROM c WHERE IS_DEFINED(c.fechaInicio) AND IS_DEFINED(c.fechaFin) GROUP BY c.estadoNuevo");
            var iterator = _container.GetItemQueryIterator<TiempoEtapaDto>(query);
            var resultados = new List<TiempoEtapaDto>();
            while (iterator.HasMoreResults) resultados.AddRange(await iterator.ReadNextAsync());
            return resultados;
        }

        public async Task<List<PedidoRetrasadoDto>> ObtenerPedidosRetrasados()
        {
            //var query = new QueryDefinition("SELECT c.numeroSerie, c.fechaEsperada, c.fechaFin AS FechaReal, c.estadoNuevo AS EstadoFinal FROM c WHERE c.fechaFin > c.fechaEsperada AND c.fechaEsperada < @fechaCorte")
            var query = new QueryDefinition(@"SELECT 
                                c.numeroSerie, 
                                c.fechaFin AS FechaReal, 
                                c.estadoNuevo AS EstadoFinal 
                            FROM c");
          
            var iterator = _container.GetItemQueryIterator<PedidoRetrasadoDto>(query);
            var resultados = new List<PedidoRetrasadoDto>();
            while (iterator.HasMoreResults) resultados.AddRange(await iterator.ReadNextAsync());
            return resultados;
        }
    }
}
