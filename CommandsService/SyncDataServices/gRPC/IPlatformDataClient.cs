using CommandsService.Models;

namespace CommandService.SyncDataServices.gRPC;

public interface IPlatformDataClient
{
    IEnumerable<Platform> ReturnAllPlatforms();
}
