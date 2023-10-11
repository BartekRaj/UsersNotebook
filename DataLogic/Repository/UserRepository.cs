using Data.DataAccess;
using Data.Models;
using Microsoft.EntityFrameworkCore;

namespace DataLogic.Repository;
public interface IUserRepository
{
    Task<List<User>> GetAll();
    Task SaveUser(User person);
}
public class UserRepository : IUserRepository
{
    private readonly UserContext _personContext;

    public UserRepository(UserContext personContext)
    {
        _personContext = personContext;
    }


    public async Task SaveUser(User person)
    {
      await  _personContext.AddAsync(person);
      await  _personContext.SaveChangesAsync();
    }
    public async Task<List<User>> GetAll()
    {
        return await _personContext.Users
             .Include(p => p.EmailAddresses)
             .Include(p => p.PhoneNumbers)
             .Include(p => p.Position)
             .ToListAsync();
    }
}
