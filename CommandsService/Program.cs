
using CommandService.Data;
using CommandService.SyncDataServices.gRPC;
using CommandsService.AsyncDataServices;
using CommandsService.Data;
using CommandsService.EventProcessing;
using Microsoft.EntityFrameworkCore;

namespace CommandsService;

public class Program
{
    public static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        // Add services to the container.
        builder.Services.AddAuthorization();
        builder.Services.AddControllers();

        builder.Services.AddDbContext<AppDbContext>(options => options.UseInMemoryDatabase("InMemDb"));
        builder.Services.AddScoped<ICommandRepo, CommandRepo>();
        builder.Services.AddSingleton<IEventProcessor, EventProcessor>();
        builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
        builder.Services.AddHostedService<MessageBusSubscriber>();
        builder.Services.AddScoped<IPlatformDataClient, PlatformDataClient>();

        // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
        builder.Services.AddEndpointsApiExplorer();
        builder.Services.AddSwaggerGen();

        var app = builder.Build();

        // Configure the HTTP request pipeline.
        if (app.Environment.IsDevelopment())
        {
            app.UseSwagger();
            app.UseSwaggerUI();
        }

        // app.UseHttpsRedirection();

        app.UseAuthorization();
        app.MapControllers();

        PrepDb.PrepPopulation(app);

        app.Run();
    }
}
