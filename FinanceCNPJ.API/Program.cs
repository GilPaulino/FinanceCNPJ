using FinanceCNPJ.Infraestrutura.Persistencia.Contexto;
using FinanceCNPJ.Infraestrutura.Persistencia.Repositorios;
using FinanceCNPJ.Dominio.Repositorios;
using FinanceCNPJ.Aplicacao.Conta.Servicos;
using FinanceCNPJ.Aplicacao.Conta.Servicos.Interfaces;
using FinanceCNPJ.Aplicacao.Conta.Servicos.Implementacoes;
using Microsoft.EntityFrameworkCore;
using System.Net.Http;
using FinanceCNPJ.Aplicacao.Conta.Comandos.Criar;
using MediatR;
using FluentValidation;
using FluentValidation.AspNetCore;
using FinanceCNPJ.Infraestrutura.Repositorios;
using FinanceCNPJ.Aplicacao.Transacao.Servicos.Interfaces;
using FinanceCNPJ.Aplicacao.Transacao.Servicos.Implementacoes;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();

builder.Services.AddMediatR(
    typeof(Program).Assembly,
    typeof(CriarContaComando).Assembly
);

builder.Services.AddScoped<IContaRepositorio, ContaRepositorio>();
builder.Services.AddScoped<ITransacaoRepositorio, TransacaoRepositorio>();

builder.Services.AddScoped<ICnpjFormatter, CnpjFormatter>();
builder.Services.AddScoped<IDocumentoService, DocumentoService>();
builder.Services.AddScoped<IReceitaWsService, ReceitaWsService>();
builder.Services.AddScoped<ISaldoService, SaldoService>();

builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseNpgsql(builder.Configuration.GetConnectionString("FinanceCNPJConnection"))
);

builder.Services.AddHttpClient();

builder.Services
    .AddFluentValidationAutoValidation()
    .AddFluentValidationClientsideAdapters();

builder.Services.AddValidatorsFromAssemblyContaining<CriarContaComando>();


builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new Microsoft.OpenApi.Models.OpenApiInfo
    {
        Title = "FinanceCNPJ API",
        Version = "v1",
        Description = "API para o sistema FinanceCNPJ",
    });
});

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(c =>
    {
        c.SwaggerEndpoint("/swagger/v1/swagger.json", "FinanceCNPJ API V1");
        c.RoutePrefix = string.Empty;
    });
}

app.UseHttpsRedirection();
app.MapControllers();
app.Run();
