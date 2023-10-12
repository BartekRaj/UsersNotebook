using System.ComponentModel.DataAnnotations;

namespace DataLogic.Models;

public class User
{
    public int Id { get; set; }
    [RegularExpression(@"^[a-zA-Z]+$")]
    [MaxLength(50)]
    [Required]
    public string FirstName { get; set; } = null!;
    [RegularExpression(@"^[a-zA-Z]+$")]
    [MaxLength(150)]
    [Required]
    public string LastName { get; set; } = null!;
    [Required]
    public Gender Gender { get; set; }
    [Required]
    public bool IsMarried { get; set; }
    [Required]
    [DataType(DataType.Date)]
    public DateTime DateOfBirth { get; set; }
    [MaxLength(200)]
    public string? Position { get; set; }
    [EmailAddress]
    public string? EmailAddress { get; set; }
    [Phone]
    public string? PhoneNumber { get; set; }
}