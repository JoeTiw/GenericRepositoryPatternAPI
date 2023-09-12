using Dotnet.core.Entities;
using Dotnet.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Learning_API.Controllers;

[Route("api/[controller]")]
[ApiController]
public class AccountController : ControllerBase
{

    public readonly IAccountService _accountService;

    public AccountController(IAccountService accountService)
    {
        _accountService = accountService;
    }

    [HttpPost]

    public async Task<IActionResult> Login(UserLogin userLogin)
    {
        var response = await _accountService.LoginUser(userLogin);
        if (response)
            return Ok(new { success = true, message = "Login Success" });
        else
            return BadRequest(new {success = false, message = "Login Failed"});
    }

    [HttpPost]
    [Route("SignUp")]
    public async Task<IActionResult> Register(UserRegister userRegister)
    {
        var response = await _accountService.AddUser(userRegister);
        if (response)
            return Ok(new { success = true, message = "SignUp Success" });
        else
            return BadRequest(new {success = false, message = "SignUp Failed"});
    }
}