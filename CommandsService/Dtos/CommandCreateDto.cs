using System.ComponentModel.DataAnnotations;

namespace CommandsService.Dtos;

public class CommandCreateDto
{
    [Required]
    public required string HowTo { get; set; }
    [Required]
    public required string CommandLine { get; set; }

    // PlatformId comes in as part of POST URI,
    // so no need to specify in the class to avoid redundancy
}