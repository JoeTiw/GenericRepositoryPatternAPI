using System.ComponentModel.DataAnnotations;

namespace Dotnet.Services.DTO;

public class UserLogin
{
    [Required]
    public string Username { get; set; }

    [Required]
    public string Password { get; set; }
}