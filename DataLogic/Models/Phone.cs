using System.ComponentModel.DataAnnotations;

namespace Data.Models;

public class Phone
{
    public int Id { get; set; }
    [Phone]
    [Required]
    public string PhoneNumber { get; set; } = null!;
}
