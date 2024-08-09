using BusinessLogicLayer.IService;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace BusinessLogicLayer.Service
{
    public class TokenService : ITokenService
    {
        private readonly IConfiguration _config;
        private readonly SymmetricSecurityKey _singningKey;
        public TokenService(IConfiguration config)
        {
            _config = config;
            _singningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config["JWT:SigningKey"]));
        }
        public string GenerateToken(string email)
        {
            var claims = new List<Claim>
            {
                new Claim(JwtRegisteredClaimNames.Email, email),
                new Claim(JwtRegisteredClaimNames.GivenName, email)
            };

            var creds = new SigningCredentials(_singningKey, SecurityAlgorithms.HmacSha256);

            var tokenDiscriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(claims),
                Expires = DateTime.Now.AddHours(1),
                SigningCredentials = creds,
                Issuer = _config["JWT:Issuer"],
                Audience = _config["JWT:Audience"]
            };

            var tokenHandler = new JwtSecurityTokenHandler();
            var token = tokenHandler.CreateToken(tokenDiscriptor);

            return tokenHandler.WriteToken(token);
        }
    }
}
