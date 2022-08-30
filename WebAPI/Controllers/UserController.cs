using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers;
[ApiController]
[Route("[controller]")]
public class UserController : ControllerBase
{
    private readonly DBInterface _db;

    public UserController(DBInterface db)
    {
        _db = db;
    }

    [HttpGet("login/{username}/{password}")]
    public async Task<User> login(string username, string password)
    {
        return await _db.loginUser(username, password);
    }

    [HttpPost("create/{user}")]
    public async Task<User> createUser(User user)
    {
        return await _db.createUser(user);
    }

    [HttpPut("update/{user}")]
    public async Task<User> updateUser(User user)
    {
        return await _db.updateUser(user);
    }

    [HttpDelete("delete/{user}")]
    public async Task deleteUser(User user)
    {
        await _db.deleteUser(user);
    }

    [HttpPut("resetPassword/{email}/{username}")]
    public async Task resetPassword(string email, string username)
    {
        await _db.resetPassword(email, username);
    }
}