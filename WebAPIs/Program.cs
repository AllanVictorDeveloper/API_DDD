using Dominio.Interfaces;
using Dominio.Interfaces.Genericas;
using Dominio.Interfaces.Servicos;
using Dominio.Servicos;
using Entidades.Modelos;
using Infraestrutura.Configuracao;
using Infraestrutura.Repositorio.Genericos;
using Infraestrutura.Repositorio.Repositorios;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// ConfigServices

builder.Services.AddDbContext<ContextoBase>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DbConnection")));

builder.Services.AddDefaultIdentity<ApplicationUser>(options => options.SignIn.RequireConfirmedAccount = true)
    .AddEntityFrameworkStores<ContextoBase>();

builder.Services.AddControllersWithViews();
builder.Services.AddRazorPages();

// Interfaces e Repositorios
builder.Services.AddSingleton(typeof(IGenerico<>), typeof(RepositorioGenerico<>));
builder.Services.AddSingleton<IMensagem, RepositorioMensagem>();

// Serviço Dominio
builder.Services.AddSingleton<IServicoMensagem, ServicoMensagem>();

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