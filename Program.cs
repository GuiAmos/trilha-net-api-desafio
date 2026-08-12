using System.Text.Json.Serialization;
using Microsoft.EntityFrameworkCore;
using Scalar.AspNetCore;
using TrilhaApiDesafio.Context;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddAuthorization(); 

builder.Services.AddControllers();
builder.Services.AddOpenApi();

// 1. Busque a string de conexão do seu appsettings.json
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");

// 2. Configure o DbContext usando o nome CORRETO da classe: OrganizadorContext
// builder.Services.AddDbContext<OrganizadorContext>(options => 
//     options.UseMySql(connectionString, new MySqlServerVersion(new Version(8, 0, 30))));

// Antes (Pomelo): builder.Services.AddDbContext<Context>(options => options.UseMySql(...));

// Agora (Oficial MySQL):
// builder.Services.AddDbContext<OrganizadorContext>(options => 
//     options.UseMySQL(builder.Configuration.GetConnectionString("ConexaoPadrao")));

// Cole esta linha provisória no lugar:
builder.Services.AddDbContext<OrganizadorContext>(options => 
    options.UseInMemoryDatabase("DesafioDio"));


// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
    app.MapScalarApiReference();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();

internal class TarefaContext
{
}