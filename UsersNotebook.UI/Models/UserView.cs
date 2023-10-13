using System.ComponentModel.DataAnnotations;

namespace UsersNotebook.UI.Models;

public class UserView
{
    public int Id { get; set; }
    [RegularExpression(@"^[a-zA-Z -]+$", ErrorMessage = "Please enter only letters (maximum 50 characters).")]
    [MaxLength(50)]
    [Required]
    public string FirstName { get; set; } = null!;
    [RegularExpression(@"^[a-zA-Z -]+$", ErrorMessage = "Please enter only letters (maximum 150 characters).")]
    [MaxLength(150)]
    [Required]
    public string LastName { get; set; } = null!;
    [Required]
    public GenderView Gender { get; set; }
    [Required]
    public bool IsMarried { get; set; }
    [Required]
    [DataType(DataType.Date)]
    public DateTime DateOfBirth { get; set; }
    [MaxLength(200, ErrorMessage ="Maximum 200 characters is allowed.")]
    public string? Position { get; set; }
    [EmailAddress]
    public string? EmailAddress { get; set; }
    [Phone]
    public string? PhoneNumber { get; set; }

}
