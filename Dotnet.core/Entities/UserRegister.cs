using System.ComponentModel.DataAnnotations;

namespace Dotnet.core.Entities;

public class UserRegister
{
    [Key]
    public int Id { get; set; }
    public string Username { get; set; }
    public string Password { get; set; }
    public string Email { get; set; }
    public string Phone { get; set; }
    public string Address { get; set; }
    
    
}