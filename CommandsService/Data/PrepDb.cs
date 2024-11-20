using CommandService.SyncDataServices.gRPC;
using CommandsService.Models;
using Grpc.Net.Client;
using Grpc.Net.ClientFactory;

namespace CommandService.Data;

public static class PrepDb
{
    public static void PrepPopulation(WebApplication app)
    {
        using (var serviceScope = app.Services.CreateScope())
        {
            var repoService = serviceScope.ServiceProvider.GetService<ICommandRepo>();
            var grpcClient = serviceScope.ServiceProvider.GetService<IPlatformDataClient>();
            var platforms = grpcClient.ReturnAllPlatforms();

            SeedData(repoService, platforms);
        }
    }

    private static void SeedData(ICommandRepo repo, IEnumerable<Platform> platforms)
    {
        Console.WriteLine("--> Seeding new platforms...");
        foreach (Platform platform in platforms)
        {
            if (!repo.ExternalPlatformExists(platform.ExternalId))
            {
                repo.CreatePlatform(platform);
            }
            repo.SaveChanges();
        }
    }
}