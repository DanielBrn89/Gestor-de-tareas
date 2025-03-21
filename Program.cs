using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.EntityFrameworkCore;
using Gestor_de_tareas.Models;
using Gestor_de_tareas.Services;

var builder = WebApplication.CreateBuilder(args);

// Configurar servicios
builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlServer("Server=BRAN\\SQLSERVER;Database=gestion_tareas;User ID=metodos;Password=metodos;integrated security=true;"));
builder.Services.AddScoped<AuthService>();
builder.Services.AddControllers();

var app = builder.Build();

// Configurar middleware
if (app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
}

app.UseRouting();
app.UseAuthorization();

app.MapControllers();

app.Run();
