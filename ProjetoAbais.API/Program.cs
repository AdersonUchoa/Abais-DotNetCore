using Microsoft.EntityFrameworkCore;
using ProjetoAbais.API.Interfaces;
using ProjetoAbais.API.Mappings;
using ProjetoAbais.API.Models;
using ProjetoAbais.API.Repository;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddDbContext<abaisdbContext>(options =>
{
    var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
    options.UseSqlServer(connectionString);
});

builder.Services.AddControllers();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddOpenApi();
builder.Services.AddScoped<InquilinoInterfaceRepository, InquilinoRepository>();
builder.Services.AddScoped<AluguelInterfaceRepository, AluguelRepository>();
builder.Services.AddScoped<ImovelInterfaceRepository, ImovelRepository>();
builder.Services.AddScoped<AdministradorInterfaceRepository, AdministradorRepository>();
builder.Services.AddAutoMapper(typeof(EntityToDTOsMappingProfile));

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
