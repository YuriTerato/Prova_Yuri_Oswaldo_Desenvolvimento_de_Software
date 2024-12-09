using API.Models;
using Microsoft.AspNetCore.Mvc;


var builder = WebApplication.CreateBuilder(args);
builder.Services.AddControllers();
builder.Services.AddDbContext<AppDataContext>();
var app = builder.Build();

app.MapGet("/", () => "Hello World!");


//CADASTRAR ALUNO
app.MapPost("/api/alunos/cadastrar", ([FromBody] Aluno aluno, [FromServices] AppDataContext ctx) =>
{   
    ctx.Alunos.Add(aluno);
    ctx.SaveChanges();
    return Results.Created("", aluno);
});

//CADASTRAR IMC
app.MapPost("/api/imc/cadastrar", ([FromBody] Imc Imcs, [FromServices] AppDataContext ctx) =>
{

});

//LISTAR IMCS POR ALUNO


///ALTERAR IMC
app.MapPut("/api/imc/alterar/{id}", ([FromRoute] int id, [FromBody] Imc imcAlterado, [FromServices] AppDataContext ctx ) =>
{
    Imc? imc = ctx.Imcs.Find(id);
    if (imc is null)
    {
        return Results.NotFound();
    }
    imc.NumeroImc = imcAlterado.NumeroImc;
    imc.GrauObesidade = imcAlterado.GrauObesidade;
    imc.Classificacao = imcAlterado.Classificacao;

    ctx.Imcs.Update(imc);
    ctx.SaveChanges();
    return Results.Ok(imc);
});
app.Run();
