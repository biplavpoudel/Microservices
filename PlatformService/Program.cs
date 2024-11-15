
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using PlatformService.Data;
using PlatformService.Models;
using PlatformService.SyncDataServices.Http;

namespace PlatformService;

public class Program
{
    public static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        // Add services to the container.

        if (builder.Environment.IsProduction())
        {   
            Console.WriteLine("--> Using SQL Server...");
            builder.Services.AddDbContext<AppDbContext>(options =>
                options.UseSqlServer(builder.Configuration.GetConnectionString("PlatformsConn"))); 
        }
        else
        {
            Console.WriteLine("--> Using InMemory Database...");
            builder.Services.AddDbContext<AppDbContext>(options =>
                options.UseInMemoryDatabase("InMemDb"));
        }

        // Add scoped repo service using Dependency Injection
        builder.Services.AddScoped<IPlatformRepo, PlatformRepo>();

        builder.Services.AddHttpClient<ICommandDataClient, HttpCommandDataClient>();

        builder.Services.AddControllers();
        // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
        builder.Services.AddEndpointsApiExplorer();

        // Adding AutoMapper to map Models to DTOs
        builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

        builder.Services.AddSwaggerGen(options =>
        {
            options.SwaggerDoc("v1", new OpenApiInfo
            {
                Version = "v1",
                Title = "Platform Services",
            });
        });

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

        // Populating Database for testing and development
        PrepDb.PrepPopulation(app);

        app.Run();

    }
}
