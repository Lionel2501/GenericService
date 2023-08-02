using GenericService.Models;
using GenericService.Repositories;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var constr = builder.Configuration.GetConnectionString("defaultValue");
builder.Services.AddDbContext<DatabaseContext>(op => op.UseSqlServer(constr));

builder.Services.AddTransient<IGenericRepository<Direcciones>, GenericRepository<Direcciones>>();
builder.Services.AddTransient<IGenericRepository<Ciudades>, GenericRepository<Ciudades>>();
builder.Services.AddTransient<IGenericRepository<Persons>, GenericRepository<Persons>>();

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
