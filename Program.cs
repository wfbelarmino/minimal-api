using Microsoft.EntityFrameworkCore;
using MinimalApi.Infraestrutura.Db;
using MinimalApi.DTOs;
using Microsoft.Extensions.Options;

var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

builder.Services.AddDbContext<DbContexto>(Options => {
    object value = Options.UseMySql(
        builder.Configuration.GetConnectionString("mysql"),
        ServerVersion.AutoDetect(builder.Configuration.GetConnectionString("mysql"))
    );
});

app.MapGet("/", () => "Olá, Mundo!");

app.MapPost("/login", (MinimalApi.DTOs.LoginDTO loginDTO) =>{
    if(loginDTO.Email =="adm@teste.com" && loginDTO.Senha == "123456")
        return Results.Ok("login com sucesso");
    else
        return Results.Unauthorized();
});


app.Run();

