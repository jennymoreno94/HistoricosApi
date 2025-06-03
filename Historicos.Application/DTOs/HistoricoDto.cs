using Historicos.Domain.Entitidades;

namespace Historicos.Application.DTOs
{
    public class HistoricoDto
    {
        public string id { get; set; }
        public string NumeroSerie { get; set; }
        public string EstadoAnterior { get; set; }
        public string EstadoNuevo { get; set; }
        public DateTime? FechaInicio { get; set; }
        public DateTime? FechaFin { get; set; }
        public string Ruta { get; set; }
        public string Ciudad { get; set; }

        public static HistoricoDto FromDomain(Historico historico)
        {
            return new HistoricoDto
            {
                id = historico.Id,
                NumeroSerie = historico.NumeroSerie,
                EstadoAnterior = historico.EstadoAnterior,
                EstadoNuevo = historico.EstadoNuevo,
                FechaInicio = historico.FechaInicio,
                FechaFin = historico.FechaFin,
                Ruta = historico.Ruta,
                Ciudad = historico.Ciudad
            };
        }
    }
}
