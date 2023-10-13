using DataLogic.Models;
using DataLogic.Repository;
using DataLogic.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace UsersNotebook.Api.Controllers;

[ApiController]
[Route("users")]
public class UsersController : ControllerBase
{
    private readonly IUserRepository _userRepository;
    private readonly IUserServices _userServices;

    public UsersController(IUserRepository userRepository, IUserServices userServices)
    {
        _userRepository = userRepository;
        _userServices = userServices;
    }

    [HttpGet("all")]
    public async Task<ActionResult<IEnumerable<User>>> Get()
    {
        var users = await _userRepository.GetAllAsync();
        return Ok(users);
    }
    [HttpGet("{id}")]
    public async Task<ActionResult<User>> GetById(int id)
    {
        var user = await _userRepository.GetByIdAsync(id);
        if (user != null)
        {
            return Ok(user);

        }
        return NotFound();
    }

    [HttpPost("add")]
    public async Task AddUser([FromBody] User user)
    {
        await _userRepository.SaveUserAsync(user);
    }

    [HttpPost("update")]
    public async Task UpdateUser([FromBody] User user)
    {
        await _userRepository.UpdateUserAsync(user);
    }

    [HttpDelete("delete/{id}")]
    public async Task DeleteUser(int id)
    {
        await _userRepository.DeleteUserAsync(id);
    }
    [HttpGet("csv/download")]
    public async Task<ActionResult> DownloadCsvAsync()
    {
        try
        {
            var csvData = await _userServices.ExportUsersToCSVAsync();
            string fileName = $"{DateTime.Now:yyyyMMddHHmmss}.csv";

            if (csvData != null)
            {
                return Ok(File(csvData, "text/csv", fileName)); 
            }
            return BadRequest();
        }
        catch (Exception ex)
        {
            return StatusCode(500, ex.Message);
        }
    }


}