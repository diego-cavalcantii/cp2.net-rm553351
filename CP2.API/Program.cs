using CP2.API.Application.Interfaces;
using CP2.API.Application.Services;
using CP2.API.Infrastructure.Data.AppData;
using CP2.API.Infrastructure.Data.Repositories;
using CP2.API.Domain.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;

var builder = WebApplication.CreateBuilder(args);

// Configura o DbContext para usar o Oracle
builder.Services.AddDbContext<ApplicationContext>(options =>
{
    options.UseOracle(builder.Configuration.GetConnectionString("Oracle"));
});

// Adiciona os repositórios e serviços
builder.Services.AddTransient<IFornecedorRepository, FornecedorRepository>();
builder.Services.AddTransient<IFornecedorApplicationService, FornecedorApplicationService>();
builder.Services.AddTransient<IVendedorRepository, VendedorRepository>();
builder.Services.AddTransient<IVendedorApplicationService, VendedorApplicationService>();

builder.Services.AddControllers();

// Configuração do Swagger
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo
    {
        Title = "API Fornecedor",
        Version = "v1",
        Description = "API para cadastro de fornecedores"
    });

    c.EnableAnnotations();
});

var app = builder.Build();

// Configure the HTTP request pipeline.
app.UseSwagger();
app.UseSwaggerUI(c =>
{
    c.SwaggerEndpoint("/swagger/v1/swagger.json", "API Fornecedor V1");
    c.RoutePrefix = string.Empty; // Agora o Swagger estará disponível na raiz
});

app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();

app.Run();
