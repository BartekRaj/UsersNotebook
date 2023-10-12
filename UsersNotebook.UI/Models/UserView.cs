using System.ComponentModel.DataAnnotations;

namespace UsersNotebook.UI.Models;

public class UserView
{
    public int Id { get; set; }
    public string? FirstName { get; set; }
    public string? LastName { get; set; }
    public GenderView Gender { get; set; }
    public bool IsMarried { get; set; }
    public DateOnly DateOfBirth { get; set; }
    public string? Position { get; set; }
    public string? EmailAddress { get; set; }
    public string? PhoneNumber { get; set; }

    public UserView()
    {
     
    }

}
