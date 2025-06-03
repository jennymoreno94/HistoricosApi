namespace Historicos.Domain.Entitidades
{
    public class Historico
    {
        public string NumeroSerie { get; set; }
        public string EstadoAnterior { get; set; }
        public string EstadoNuevo { get; set; }
        public DateTime FechaInicio { get; set; }
        public DateTime FechaFin { get; set; }
        public string Ruta { get; set; }
        public string Ciudad { get; set; }

        public Historico(string numeroSerie, string estadoAnterior, string estadoNuevo, DateTime fechaInicio, DateTime fechaFin, string ruta, string ciudad)
        {
            NumeroSerie = numeroSerie;
            EstadoAnterior = estadoAnterior;
            EstadoNuevo = estadoNuevo;
            FechaInicio = fechaInicio;
            FechaFin = fechaFin;
            Ruta = ruta;
            Ciudad = ciudad;
        }
    }
}