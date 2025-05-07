using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Microsoft.IdentityModel.Tokens;
using Online_food_delivery_system.Interface;
using Online_food_delivery_system.Models;

namespace Online_food_delivery_system.Service
{
    public class TokenService: ITokenGenerate
    {
        private readonly SymmetricSecurityKey _key;
        public TokenService(IConfiguration configuration)
        {
            _key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(configuration["TokenKey"]!));
        }

        public string GenerateToken(User user)
        {
            string token = string.Empty;
            var claims = new List<Claim>
            {
                new Claim(JwtRegisteredClaimNames.NameId,user.Username!),
                 new Claim(JwtRegisteredClaimNames.Email,user.Email),
                  new Claim(ClaimTypes.Role, user.Role),
            };
            var cred = new SigningCredentials(_key, SecurityAlgorithms.HmacSha256);
            var tokenDescription = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(claims),
                Expires = DateTime.Now.AddDays(2),
                SigningCredentials = cred
            };
            var tokenHandler = new JwtSecurityTokenHandler();
            var myToken = tokenHandler.CreateToken(tokenDescription);
            token = tokenHandler.WriteToken(myToken);
            return token;
        }
    }
}
