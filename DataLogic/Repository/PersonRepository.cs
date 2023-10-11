using Data.DataAccess;
using Data.Models;
using Microsoft.EntityFrameworkCore;

namespace DataLogic.Repository;
public interface IPersonRepository
{
    Task<List<Person>> GetAll();
    Task SaveUser(Person person);
}
public class PersonRepository : IPersonRepository
{
    private readonly PersonContext _personContext;

    public PersonRepository(PersonContext personContext)
    {
        _personContext = personContext;
    }


    public async Task SaveUser(Person person)
    {
      await  _personContext.AddAsync(person);
      await  _personContext.SaveChangesAsync();
    }
    public async Task<List<Person>> GetAll()
    {
        return await _personContext.People
             .Include(p => p.EmailAddresses)
             .Include(p => p.PhoneNumbers)
             .Include(p => p.Position)
             .ToListAsync();
    }
}
