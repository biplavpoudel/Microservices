using AutoMapper;
using CommandsService.Models;

namespace CommandService.SyncDataServices.gRPC;

public class PlatformDataClient : IPlatformDataClient
{
    private readonly IConfiguration _configuration;
    private readonly IMapper _mapper;

    public PlatformDataClient(IConfiguration configuration, IMapper mapper)
    {
        _configuration = configuration;
        _mapper = mapper;
    }
    public IEnumerable<Platform> ReturnAllPlatforms()
    {
        throw new NotImplementedException();
    }
}