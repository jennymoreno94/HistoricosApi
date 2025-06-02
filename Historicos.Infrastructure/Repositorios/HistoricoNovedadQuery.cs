using Historicos.Application.DTOs;
using Historicos.Application.Interfaces;
using Microsoft.Azure.Cosmos;
using Microsoft.Extensions.Configuration;

namespace Historicos.Infrastructure.Repositorios
{
    public class HistoricoNovedadQuery : IHistoricoNovedadQuery
    {
        private readonly Container _container;
        public HistoricoNovedadQuery(CosmosClient client, IConfiguration config)
        {
            _container = client.GetContainer(config["CosmosDb:Database"], config["CosmosDb:ContainerNovedades"]);
        }

        public async Task<List<ProblemaRecurrenteDto>> ObtenerProblemasRecurrentes()
        {
            var query = new QueryDefinition("SELECT  c.tipoNovedad, COUNT(1) AS Cantidad FROM c GROUP BY c.tipoNovedad");
            var iterator = _container.GetItemQueryIterator<ProblemaRecurrenteDto>(query);
            var resultados = new List<ProblemaRecurrenteDto>();
            while (iterator.HasMoreResults) resultados.AddRange(await iterator.ReadNextAsync());
            return resultados
            .OrderByDescending(r => r.Cantidad)
            .ToList();
        }
    }
}
