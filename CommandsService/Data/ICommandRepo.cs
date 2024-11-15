using CommandsService.Data;
using CommandsService.Models;

public interface ICommandRepo
{
    bool SaveChanges();

    //Platform
    IEnumerable<Platform> GetAllPlatforms();
    void CreatePlatform(Platform platform);
    bool PlatformExists(int platformId);

    //Commands
    IEnumerable<Command> GetCommandsforPlatform(int platformId);
    Command GetCommand(int platformId, int commandId);
    void CreateCommand(int platformId, Command command);
}