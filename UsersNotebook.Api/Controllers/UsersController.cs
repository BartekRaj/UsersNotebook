using Data.Models;
using DataLogic.Repository;
using Microsoft.AspNetCore.Mvc;

namespace UsersNotebook.Api.Controllers
{
    [ApiController]
    [Route("users")]
    public class UsersController : ControllerBase
    {
        private readonly IPersonRepository _personRepository;

        public UsersController(IPersonRepository personRepository)
        {
            _personRepository = personRepository;
        }

        [HttpGet("all")]
        public async Task<ActionResult<IEnumerable<Person>>> Get()
        {
            var people = await _personRepository.GetAll();
            return Ok(people);
        }

        [HttpPost("testpost")]
        public async void Dupa()
        {
            var osoba = new Person
            {
                FirstName = "John",
                LastName = "Doe",
                Gender = Gender.Male,
                IsMarried = true,
                DateOfBirth = new DateOnly(1995,10,26),
                Position = new JobPosition
                {
                    PositionName = "Software Engineer",
                    Description = "Senior Software Engineer"
                },
                EmailAddresses = new List<Email>
            {
                new Email { EmailAddress = "john.doe@example.com" }
            },
                PhoneNumbers = new List<Phone>
            {
                new Phone { PhoneNumber = "+1234567890" }
            }
            };

          await  _personRepository.SaveUser(osoba);

        }
    }
}