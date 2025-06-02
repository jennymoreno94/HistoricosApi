namespace Historicos.Application.DTOs
{

    public class EstadoHistoricoDto
    {
        public string NumeroSerie { get; set; }
        public string EstadoAnterior { get; set; }
        public string EstadoNuevo { get; set; }
        public DateTime FechaCambio { get; set; }
        public string Ruta { get; set; }
        public string Ciudad { get; set; }
    }
}
