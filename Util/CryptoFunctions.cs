using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using WebApplication3.Domain.Models;

namespace WebApplication3.Util
{
    public class CryptoFunctions
    {
        public static string GenerateToken(IConfiguration configuration, User user) //takes a configuration
        {
            var s = Encoding.UTF8.GetBytes(configuration["SecurityKey"]);
            SymmetricSecurityKey key = new SymmetricSecurityKey(s);

            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            int tokenExpireTimeLapse = int.Parse(configuration["TokenExpireTimeLapse"]);

            var token = new JwtSecurityToken(
                issuer: configuration["Issuer"],
                audience: configuration["Audience"],
                expires: DateTime.Now.AddMinutes(tokenExpireTimeLapse),
                signingCredentials: creds);

            return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }
}
