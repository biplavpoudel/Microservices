using AutoMapper;
using CommandsService.Models;
using Grpc.Net.Client;

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
        Console.WriteLine($"--> Invoking gRPC Service: {_configuration["GrpcPlatform"]}");
        
        var channel = GrpcChannel.ForAddress(_configuration["GrpcPlatform"]);
        var client = new GrpcPlatform.GrpcPlatformClient(channel);
        var request = new GetAllRequest();

        try
        {
            var reply = client.GetAllPlatforms(request);
            return _mapper.Map<IEnumerable<Platform>>(reply.Platform);
        }
        catch (Exception ex)
        {
            Console.WriteLine($"--> Couldn't invoke gRPC Service: {ex.Message}");
            return null;
        }
    }
}