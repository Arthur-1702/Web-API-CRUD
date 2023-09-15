using API_Cadastro.Repository;
using API_Cadastro.Service;
using Microsoft.Extensions.DependencyInjection;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddScoped<CadastroRepository>();
builder.Services.AddScoped<CadastroService>();

builder.Services.AddCors();

var app = builder.Build();
app.UseCors(x => x.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader());

// Configure the HTTP request pipeline.

app.UseAuthorization();

app.MapControllers();

app.Run();
