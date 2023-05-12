using Microsoft.AspNetCore.Mvc.ModelBinding;
using RegistryServices.Application.Interfaces;
using RegistryServices.Application.Mapping;
using RegistryServices.Application.UserCase;
using RegistryServices.Infastructure.Repositories;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

var connectionString = builder.Configuration.GetConnectionString("defaultconnection");

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddAutoMapper(typeof(MappingProfile).Assembly);
builder.Services.AddTransient<IClientRepository, ClientRepository>();
builder.Services.AddTransient<IClientUseCase, ClientUseCase>();

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
