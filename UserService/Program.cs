using Microsoft.AspNetCore.Mvc.Infrastructure;
using MongoDB.Driver;
using UserService.Repositories;
using UserService.Utilities;

var builder = WebApplication.CreateBuilder(args);


builder.Services.AddControllers(options =>
{
    options.Filters.Add(new ModelStateInvalidFilter());
});
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Configuración de MongoDB
var mongoConnectionString = "mongodb://localhost:27017"; // Cambiar según tu configuración
var mongoClient = new MongoClient(mongoConnectionString);
var mongoDatabase = mongoClient.GetDatabase("Biodigestor"); // Cambiar "MyDb" por el nombre de tu base de datos

// Configuración de AutoMapper
builder.Services.AddAutoMapper(typeof(Program), typeof(AutoMapperProfiles));

builder.Services.AddSingleton<IMongoDatabase>(mongoDatabase);
builder.Services.AddScoped<IUserRepository, UserRepository>();


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseAuthorization();

app.MapControllers();

app.Run();
