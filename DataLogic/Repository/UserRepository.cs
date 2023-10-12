using DataLogic.DataAccess;
using DataLogic.Models;
using Microsoft.EntityFrameworkCore;

namespace DataLogic.Repository;
public interface IUserRepository
{
    Task<List<User>> GetAllAsync();
    Task SaveUserAsync(User person);
    Task<User?> GetByIdAsync(int id);
    Task UpdateUserAsync(User user);
    Task DeleteUserAsync(int id);
}
public class UserRepository : IUserRepository
{
    private readonly UserContext _userContext;

    public UserRepository(UserContext personContext)
    {
        _userContext = personContext;
    }

    public async Task UpdateUserAsync(User user)
    {
        var currentUser = await GetByIdAsync(user.Id);
        if (currentUser != null)
        {
            currentUser.FirstName = user.FirstName;
            currentUser.LastName = user.LastName;
            currentUser.PhoneNumber = user.PhoneNumber;
            currentUser.EmailAddress = user.EmailAddress;
            currentUser.IsMarried = user.IsMarried;
            currentUser.DateOfBirth = user.DateOfBirth;
            currentUser.Position = user.Position;
            currentUser.Gender = user.Gender;
            await _userContext.SaveChangesAsync();
        }
        
    }
    public async Task SaveUserAsync(User user)
    {
      await  _userContext.AddAsync(user);
      await  _userContext.SaveChangesAsync();
    }
    public async Task<List<User>> GetAllAsync()
    {
        return await _userContext.Users
             .ToListAsync();
    }

    public async Task<User?> GetByIdAsync(int id)
    {

        return await _userContext.Users
       .Where(p => p.Id == id).FirstOrDefaultAsync();

    }
    public async Task DeleteUserAsync(int id)
    {
        var currentUser = await GetByIdAsync(id);
        if (currentUser != null)
        {
            _userContext.Users .Remove(currentUser);
            await _userContext.SaveChangesAsync();
        }
    }

    
}
