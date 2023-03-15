using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using API.Entities;
using API.Interfaces;
using Microsoft.IdentityModel.Tokens;

namespace API.Services
{
    public class TokenService : ITokenService
    {
        private readonly SymmetricSecurityKey _key;

        public TokenService(IConfiguration configuration)
        {
            _key = new SymmetricSecurityKey(Encoding.UTF8
                .GetBytes(configuration["TokenKey"]));
        }

        public string CreateToken(AppUser user)
        {
            List<Claim> claims = new()
            {
                new Claim(JwtRegisteredClaimNames.NameId, user.UserName)
            };

            SigningCredentials signingCreds = new(
                _key, SecurityAlgorithms.HmacSha512Signature
                );

            // Describes what's in our token...
            SecurityTokenDescriptor tokenDescriptor = new()
            {
                Subject = new ClaimsIdentity(claims),
                Expires = DateTime.UtcNow.AddDays(7),
                SigningCredentials = signingCreds
            };

            JwtSecurityTokenHandler tokenHandler = new();

            SecurityToken token = tokenHandler
                .CreateToken(tokenDescriptor);

            return tokenHandler.WriteToken(token);
        }
    }
}

