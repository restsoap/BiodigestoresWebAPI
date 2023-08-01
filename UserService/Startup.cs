using Microsoft.OpenApi.Models;
using MongoDB.Driver;
using System.Text.Json.Serialization;
using UserService.Models;
using UserService.Repositories;
using UserService.Utilities;

namespace UserService
{

    public class Startup
    {
        private readonly IConfiguration _configuration;
        public Startup(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public IConfiguration Configuration { get; }


        public void ConfigureServices(IServiceCollection services)
        {
            // Configuraci�n de MongoDB
            var mongoConnectionString = "mongodb://localhost:27017"; // Cambiar seg�n tu configuraci�n
            var mongoClient = new MongoClient(mongoConnectionString);
            var mongoDatabase = mongoClient.GetDatabase("Biodigestor"); // nombreDB

            // Configuraci�n de AutoMapper
            services.AddAutoMapper(typeof(Startup));

            // Repositorio y controlador
            services.AddSingleton<IMongoDatabase>(mongoDatabase);
            services.AddScoped<IUserRepository, UserRepository>();
            services.AddControllers();

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "WebAPIAutores", Version = "v1" });
            });

        }

    }
}