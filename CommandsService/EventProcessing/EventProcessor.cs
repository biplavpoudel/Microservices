using System.Text.Json;
using AutoMapper;
using CommandsService.Dtos;

namespace CommandsService.EventProcessing;

public class EventProcessor : IEventProcessor
{
    private readonly IServiceScopeFactory _scopeFactory;
    private readonly IMapper _mapper;

    public EventProcessor(IServiceScopeFactory scopeFactory, IMapper mapper)
    {
        _scopeFactory = scopeFactory;
        _mapper = mapper;
    }
    public void ProcessEvent(string message)
    {
        throw new NotImplementedException();
    }

    private EventType DetermineEvent(string notificationMessage){
        Console.WriteLine("--> Determining Event from PlatformPublishDto");

        var eventType = JsonSerializer.Deserialize<GenericEventDto>(notificationMessage);

        switch (eventType.Event)
        {
            case "PlatformPublished":
                Console.WriteLine("--> Platform Published Event Detected!");
                return EventType.PlatformPublished;
            
            default:
                Console.WriteLine("--> Couldn't determine event type!!");
                return EventType.Undetermined;

        }
    }

    enum EventType
    {
        PlatformPublished,
        Undetermined
    }
}