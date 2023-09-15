using System.Text.Json.Serialization;

namespace Dotnet.Services.DTO;

public class UserRegister
{
   
    public string Username { get; set; }
    public string Password { get; set; }
    
    [JsonIgnore]
    public string? PasswordSalt { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string Email { get; set; }
    public string Phone { get; set; }
    public string Address { get; set; }


}