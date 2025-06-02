namespace Historicos.Domain.Entities
{
    public class Historico
    {
        public string NumeroSerie { get; }
        public string EstadoAnterior { get; }
        public string EstadoNuevo { get; }
        public DateTime FechaCambio { get; }
        public string Ruta { get; }
        public string Ciudad { get; }

        public Historico(string numeroSerie, string estadoAnterior, string estadoNuevo, DateTime fechaCambio, string ruta, string ciudad)
        {
            NumeroSerie = numeroSerie;
            EstadoAnterior = estadoAnterior;
            EstadoNuevo = estadoNuevo;
            FechaCambio = fechaCambio;
            Ruta = ruta;
            Ciudad = ciudad;
        }
    }
}