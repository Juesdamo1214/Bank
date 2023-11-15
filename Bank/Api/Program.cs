using Application.Context;
using Application.Interface.Repository;
using Application.Services.Querie;
using Domain.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddSqlServer<BankContext>(builder.Configuration.GetConnectionString("cnBank"));

//builder.Services.AddScoped<BankAccountGetAll>();
//builder.Services.AddScoped<ICommands>();
builder.Services.AddScoped < IQueriesRepository<BankAccount>, BankAccountQuieres>;

var app = builder.Build();

app.MapGet("/dbconnection", async ([FromServices] BankContext dbcontext) =>
{
    dbcontext.Database.EnsureCreated();
    return Results.Ok();
});

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
