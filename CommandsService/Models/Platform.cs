using System.ComponentModel.DataAnnotations;
using System.Runtime;

namespace CommandsService.Models;

public class Platform
{
    [Key]
    public int Id { get; set; } //assgined by database

    [Required]
    public int ExternalId { get; set; } //to check for duplicity of platforms; comes from PlatformService

    [Required]
    public required string Name { get; set; }

    public ICollection<Command> Commands{ get; set; } = new List<Command>();

}