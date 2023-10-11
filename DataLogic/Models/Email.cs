using System.ComponentModel.DataAnnotations;

namespace Data.Models;

public class Email
{
    public int Id { get; set; }
    [EmailAddress]
    [Required]
    public string EmailAddress { get; set; } = null!;
}
