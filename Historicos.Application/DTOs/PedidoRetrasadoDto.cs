namespace Historicos.Application.DTOs
{
    public class PedidoRetrasadoDto
    {
        public string NumeroSerie { get; set; }
        public DateTime FechaReal { get; set; }
        public string EstadoFinal { get; set; }
    }
}
