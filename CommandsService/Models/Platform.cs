using System.ComponentModel.DataAnnotations;
using System.Runtime;

namespace CommandsService.Models;

public class Platform
{
    [Key]
    public int Id { get; set; }

    [Required]
    public int ExternalId { get; set; }

    [Required]
    public required string Name { get; set; }

    public ICollection<Command> Commands{ get; set; } = new List<Command>();

}