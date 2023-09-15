using Dotnet.Services.DTO;
using Dotnet.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Learning_API.Controllers;


[Route("api/[controller]")]
[ApiController]
public class AccountController : ControllerBase
{

    public readonly IAccountService _accountService;
    private readonly IConfiguration _configuration;

    public AccountController(IAccountService accountService, IConfiguration configuration)
    {
        _accountService = accountService;
        _configuration = configuration;
    }

    [HttpPost]

    public async Task<IActionResult> Login(UserLogin userLogin)
    {

        var user = await _accountService.GetUserByUsername(userLogin.Username);
        if (user == null)
        {
            return BadRequest(new { success = false, message = "Invalid Username!" });
        }
        
        //var passwordSalt = Helper.PasswordEncryption.GetSecurePasswordSalt();
        var hashPassword = Helper.PasswordEncryption.HashPassword(userLogin.Password, Convert.FromBase64String(user.PasswordSalt));
       // userLogin.Password = hashPassword;

        if (user.Password != hashPassword)
        {
            return BadRequest(new { success = false, message = "Invalid Password!" });
        }

        // var response = await _accountService.LoginUser(userLogin);
        // if (response)
        // {
            string secretKey = _configuration.GetValue<string>("JWTTokenConfig:SecretKey");
            string audience = _configuration.GetValue<string>("JWTTokenConfig:Audience");
            string issuer = _configuration.GetValue<string>("JWTTokenConfig:Issuer");
            
            var accessToken = await Helper.JwtToken.GenerateAccessToken(audience, issuer, secretKey, userLogin.Username );
           
            return Ok(new { success = true, message = "Login Success", access_Token = accessToken  });
        //}
        //else
           // return BadRequest(new {success = false, message = "Login Failed"});
    }

    [HttpPost]
    [Route("SignUp")]
    public async Task<IActionResult> Register(UserRegister userRegister)
    {
        var existingUser = await _accountService.GetUserByUsername(userRegister.Username);
        if (existingUser != null)
        {
            return BadRequest(new {success = false, message = "User Already Exist"});
        }

        var passwordSalt = Helper.PasswordEncryption.GetSecurePasswordSalt();
        var hashPassword = Helper.PasswordEncryption.HashPassword(userRegister.Password, passwordSalt);
        
        userRegister.Password = hashPassword;
        userRegister.PasswordSalt = Convert.ToBase64String(passwordSalt);
        
        var response = await _accountService.AddUser(userRegister);
        if (response)
            return Ok(new { success = true, message = "SignUp Success" });
        else
            return BadRequest(new {success = false, message = "SignUp Failed"});
    }
}