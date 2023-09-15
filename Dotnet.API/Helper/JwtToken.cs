using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Microsoft.IdentityModel.Tokens;

namespace Learning_API.Helper;

public class JwtToken
{
    public static async Task<string> GenerateAccessToken(string audience, string issuer, string secretKey,
        string username)
    {
        var tokenHandler = new JwtSecurityTokenHandler();
        var key = Encoding.UTF8.GetBytes(secretKey);
        var claimsIdentity = new ClaimsIdentity(new[]
        {
            new Claim(ClaimTypes.NameIdentifier, username)
        });
        
        //var currentTime = DateTime.Now; 
        
        var signingCredential =
            new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature);
        var tokenDescriptor = new SecurityTokenDescriptor
        {
            Subject = claimsIdentity,
            Issuer = issuer,
            Audience = audience,
            Expires = DateTime.Now.AddMinutes(15),
            NotBefore = DateTime.Now.AddSeconds(-5),
            SigningCredentials = signingCredential
        };
        var securityToken = tokenHandler.CreateToken(tokenDescriptor);
        return tokenHandler.WriteToken(securityToken);
    }
}