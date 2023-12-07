using Microsoft.IdentityModel.Tokens;
using MyWeb.Models;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace MyWeb.Services
{
    public class JwtService
    {
        public string GenarateKey(User user)
        {
            var sessionId = "";
            var claims = new Claim[]
            {
                new Claim(ClaimTypes.NameIdentifier, user.ID.ToString()),
                new Claim(ClaimTypes.Name, user.UserName ?? "")
            };
            var key = new SymmetricSecurityKey(Encoding.ASCII.GetBytes("47D528A3D79B3F8DF7824F847E5DA"));
            var creds =new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
            var jwtToken = new JwtSecurityToken(sessionId, null, claims,null,DateTime.UtcNow.AddMinutes(120), creds);
            var handler =  new JwtSecurityTokenHandler();   
            var accessToken = handler.WriteToken(jwtToken);
            return accessToken;
        }
    }
}
