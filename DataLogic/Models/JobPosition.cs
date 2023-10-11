using System.ComponentModel.DataAnnotations;

namespace Data.Models;

public class JobPosition
{
    public int Id { get; set; }
    [MaxLength(200)]
    [Required]
    public string PositionName { get; set; } = null!;
    [MaxLength(1000)]
    [Required]
    public string Description { get; set; } = null!;
}
