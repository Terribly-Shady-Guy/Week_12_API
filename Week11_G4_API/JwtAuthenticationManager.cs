using Microsoft.AspNetCore.Authentication;
using System.IdentityModel.Tokens.Jwt;
using System.Text;
using Microsoft.IdentityModel.Tokens;
using System.Security.Claims;

namespace Week11_G4_API
{
    public class JwtAuthenticationManager
    {
        private readonly string _key;
        private readonly Dictionary<string, string> _users = new Dictionary<string, string>()
        {
            { "Tyler", "Password123" },
            { "Joe", "Program" }
        };

        public JwtAuthenticationManager(string key)
        {
            _key = key;
        }

        public string Authenticate(string userName, string password)
        {
            if (!_users.Any(u => u.Key == userName && u.Value == password))
            {
                return "";
            }

            var tokenHandler = new JwtSecurityTokenHandler();
            var tokenKey = Encoding.ASCII.GetBytes(_key);

            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new Claim[]
                {
                    new Claim(ClaimTypes.Name, userName)
                }),
                Expires = DateTime.UtcNow.AddHours(1),
                SigningCredentials = new SigningCredentials(
                    new SymmetricSecurityKey(tokenKey), 
                    SecurityAlgorithms.HmacSha256Signature)
            };

            var token = tokenHandler.CreateToken(tokenDescriptor);

            return tokenHandler.WriteToken(token);
        }
    }
}
