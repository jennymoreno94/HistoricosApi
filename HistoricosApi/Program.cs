using Historicos.Application.CasoUso;
using Historicos.Application.Interfaces;
using Historicos.Infrastructure.Repositorios;
using Microsoft.AspNetCore.Server.Kestrel.Core;
using Microsoft.AspNetCore.Server.Kestrel.Https;
using Microsoft.Azure.Cosmos;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();

builder.Services.AddScoped<ObtenerHistorialPorNumeroSerie>();
builder.Services.AddScoped<ObtenerProblemasRecurrentes>();
builder.Services.AddScoped<ObtenerTiemposPromedioEtapas>();
builder.Services.AddScoped<ObtenerPedidosRetrasados>();
builder.Services.AddScoped<IHistoricoDespachoQuery, HistoricoDespachoQuery>();
builder.Services.AddScoped<IHistoricoNovedadQuery, HistoricoNovedadQuery>();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddSingleton(sp =>
{
    var cfg = builder.Configuration.GetSection("CosmosDb");
    string endpoint = cfg["Account"];
    string key = cfg["Key"];

    // Puedes ajustar opciones avanzadas con CosmosClientOptions si lo necesitas
    return new CosmosClient(endpoint, key, new CosmosClientOptions
    {
        ConnectionMode = ConnectionMode.Direct   
    });
});

// Configuración de Kestrel para .NET 7
builder.WebHost.ConfigureKestrel(options =>
{
    options.ConfigureHttpsDefaults(httpsOptions =>
    {
        httpsOptions.ClientCertificateMode = ClientCertificateMode.NoCertificate;
    });
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}



app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();


