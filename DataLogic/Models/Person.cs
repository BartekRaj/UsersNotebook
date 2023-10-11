using System.ComponentModel.DataAnnotations;

namespace Data.Models;

public class Person
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
    public DateOnly DateOfBirth { get; set; }
    public JobPosition? Position { get; set; }
    public List<Email> EmailAddresses { get; set; } = new List<Email>();
    public List<Phone> PhoneNumbers { get; set; } = new List<Phone>();
}