using PlatformService.Dtos;
using RabbitMQ.Client;

namespace PlatformService.AsyncDataServices;

public class MessageBusClient : IMessageBusClient
{
    private readonly IConfiguration _configuration;
    private readonly IConnection _connection;
    public MessageBusClient(IConfiguration configuration)
    {
        _configuration = configuration;
        var factory = new ConnectionFactory(){
            HostName = _configuration["RabbitMQHost"],
            Port = int.Parse(_configuration["RabbitMQPort"])};
        
        try
        {
            _connection = factory.CreateConnection();
        }
        catch (Exception ex)
        {
            Console.WriteLine($"--> Couldn't connect to MessageBus: {ex.Message}");
        }
    }

    public void PublishNewPlatform(PlatformPublishDto platformPublishDto)
    {
        throw new NotImplementedException();
    }
} 