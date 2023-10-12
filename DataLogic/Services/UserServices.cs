using DataLogic.Models;
using DataLogic.Repository;
using System.Text;

namespace DataLogic.Services;
public interface IUserServices
{
    Task<byte[]?> ExportUsersToCSVAsync();
}
public class UserServices : IUserServices
{
    private readonly IUserRepository _userRepository;

    public UserServices(IUserRepository userRepository)
    {
        _userRepository = userRepository;
    }

    public async Task<byte[]?> ExportUsersToCSVAsync()
    {


            var users = await _userRepository.GetAllAsync();

            var csv = new StringBuilder();
            csv.AppendLine("Title,FirstName,LastName,BirthDate,Gender,Age");

            foreach (var user in users)
            {
                csv.AppendLine($"{GetUserTitle(user)},{user.FirstName},{user.LastName},{user.DateOfBirth},{user.Gender},{GetUserAge(user)}");
            }

            return Encoding.UTF8.GetBytes(csv.ToString());


    }

    private static string GetUserAge(User user)
    {
        if (user == null)
        {
            throw new ArgumentNullException(nameof(user));
        }

        var currentDate = DateTime.Now;
        var birthDate = new DateTime(user.DateOfBirth.Year, user.DateOfBirth.Month, user.DateOfBirth.Day);
        int age = currentDate.Year - birthDate.Year;

        if (currentDate < birthDate.AddYears(age))
        {
            age--;
        }

        return age.ToString();
    }

    private static string GetUserTitle(User user)
    {
        if (user.Gender == 0)
        {
            return "Mr.";
        }
        else
        {
            if (user.IsMarried)
            {
                return "Mrs.";
            }
            else
            {
                return "Ms.";
            }
        }
    }


}

