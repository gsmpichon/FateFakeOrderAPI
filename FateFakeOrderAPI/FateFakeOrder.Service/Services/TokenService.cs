using FateFakeOrder.Data;
using FateFakeOrder.Data.Models;
using FateFakeOrder.Service.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace FateFakeOrder.Service.Services
{
    public class TokenService : ITokenService
    {
        private readonly AuthenticationConfig _authenticationConfig;



        public TokenService(AuthenticationConfig authenticationConfig)
        {
            _authenticationConfig = authenticationConfig;
        }
        public string CreateToken(User user)
        {
            var tokenKey = Encoding.ASCII.GetBytes(_authenticationConfig.JWTSigningKey);
            var tokenDescriptor = new SecurityTokenDescriptor // <-- creates the format of the token
            {
                Subject = new ClaimsIdentity(new Claim[]{
                    new Claim(ClaimTypes.Name,user.Username) // <-- indentifier
                }),
                Expires = DateTime.UtcNow.AddMinutes(Convert.ToDouble(_authenticationConfig.JWTValidMins)),
                SigningCredentials = new SigningCredentials(
                    new SymmetricSecurityKey(tokenKey),
                    SecurityAlgorithms.HmacSha256Signature)

            };

            var handler = new JwtSecurityTokenHandler();
            var token = handler.CreateToken(tokenDescriptor);
            return handler.WriteToken(token);



        }
    }
}
