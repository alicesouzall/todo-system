global using System;
using entrypoints;
using infra;
using Microsoft.AspNetCore.Http.Features;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using models;
using services;

var builder = WebApplication.CreateBuilder(args);

// Build Config //
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.Configure<FormOptions>(options =>
{
    options.ValueLengthLimit = int.MaxValue;
    options.MultipartBodyLengthLimit = int.MaxValue;
});
builder.Services.AddCors(options =>
{
    options.AddPolicy("CorsPolicy", builder =>
    {
        builder.AllowAnyMethod().AllowAnyOrigin().AllowAnyHeader();
    });
});

// Adapter Injections //
builder.Services.AddScoped<DatabaseConnection, DatabaseConnectionPostgres>();
builder.Services.AddScoped<TaskRepository, TaskRepositoryPostgres>();
builder.Services.AddScoped<GlobalAdapters>();
builder.Services.AddScoped<EnvironmentVariables>();

var app = builder.Build();
app.UseCors("CorsPolicy");

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.UseRouting();

app.MapControllers();

app.Run();
