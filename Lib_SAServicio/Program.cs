using Lib_SAaplicacion.interfaces;
using LibAplicacion.implementaciones;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddScoped<IConexion, Conexion>();
builder.Services.AddScoped<IProductosAplicacion, ProductosAplicacion>();

var app = builder.Build();

// Configure the HTTP request pipeline.

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
