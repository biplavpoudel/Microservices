using System.ComponentModel.DataAnnotations;

namespace CommandsService.Dtos;

public class CommandCreateDto
{
    [Required]
    public required string HowTo { get; set; }
    [Required]
    public required string CommandLine { get; set; }

    // PlatformId comes in as part of POST URI: "..../api/c/platforms/{platformId}/commands/"
}