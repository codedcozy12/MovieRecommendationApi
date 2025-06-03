using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Microsoft.IdentityModel.Tokens;
using MovieRecommendationApi.Dto;

namespace MovieRecommendationApi.Auth
{
      public class AuthService : IAuthService
    {
        private readonly IConfiguration _config;
        public AuthService(IConfiguration config)
        {
            _config = config;
        }
        public string GenerateJwtToken(UserDto userDto)
        {
            var jwt = _config.GetSection("Jwt");
            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(jwt["key"]!));
            var claims = new List<Claim>
            {
                new Claim(ClaimTypes.NameIdentifier,userDto.Id.ToString()),
                new Claim(ClaimTypes.Email, userDto.Email),
                new Claim(ClaimTypes.Role, userDto.Role.ToString())
            };
            var token = new JwtSecurityToken
            (
                issuer: jwt["issuer"],
                audience: jwt["audience"],
                claims: claims,
                expires: DateTime.Now.AddMinutes(double.Parse(jwt["expiryTime"]!)),
                signingCredentials: new SigningCredentials(key, SecurityAlgorithms.HmacSha256)
            );
            return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }
}