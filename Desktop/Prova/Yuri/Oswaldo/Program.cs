using API.Models;
using Microsoft.AspNetCore.Mvc;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<AppDataContext>();

var app = builder.Build();

app.MapPost("/api/funcionario/cadastrar", ([FromBody] Funcionario funcionario, [FromServices] AppDataContext ctx) =>
{
    ctx.Funcionario.Add(funcionario);
    ctx.SaveChanges();
    return Results.Created("", funcionario);
});

app.MapGet("api/funcionario/listar", ([FromServices] AppDataContext ctx) =>
{
    if (ctx.Funcionario.Any())
    {
        return Results.Ok(ctx.Funcionario.ToList());
    }
    return Results.NotFound();
});

app.MapPost("/api/folha/cadastrar", ([FromBody] Folha folha, [FromServices] AppDataContext ctx) =>
{
    Funcionario funcionario = ctx.Funcionario.Find(folha.funcionarioId);
    folha.funcionario = funcionario;
    folha.CalcularImpostos();
    ctx.Folha.Add(folha);
    ctx.SaveChanges();
    return Results.Created("", folha);
});

app.MapGet("/api/folha/buscar/{cpf}/{mes}/{ano}", (string cpf, int mes, int ano, [FromServices] AppDataContext ctx) =>
{
    var folha = ctx.Folha
                                .Where(p => p.funcionario.cpf.Contains(cpf))
                                .Where(p => p.mes == mes)
                                .Where(p => p.ano == ano)
                                .ToList();
    return folha.Any() ? Results.Ok(folha) : Results.NotFound("Nenhuma folha encontrada.");
});

app.MapGet("/api/folha/listar", ([FromServices] AppDataContext ctx) =>
{
    if (ctx.Folha.Any())
    {
        return Results.Ok(ctx.Folha.ToList());
    }
    return Results.NotFound();
});

app.Run();
