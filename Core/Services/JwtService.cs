using Core.Interfaces;
using Data.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace Core.Services
{
    public class JwtService : IJwtService
    {
        private readonly IConfiguration configuration;
        private readonly UserManager<User> userManager;
        //private readonly JwtOptions jwtOptions;

        public JwtService(IConfiguration configuration, UserManager<User> userManager)
        {
            this.configuration = configuration;
            this.userManager = userManager;
            //this.jwtOptions = configuration.GetSection(nameof(JwtOptions)).Get<JwtOptions>()!;
        }

        public string CreateToken(IEnumerable<Claim> claims)
        {
            // TODO: make separate method
            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("erhgugkayuergfaeur-ghiraekuyare-reaguhaekuyfghare"));
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

            var token = new JwtSecurityToken(
                issuer: "PD221 Group",
                claims: claims,
                expires: DateTime.UtcNow.AddMinutes(5),
                signingCredentials: credentials);

            return new JwtSecurityTokenHandler().WriteToken(token);
        }

        public IEnumerable<Claim> GetClaims(User user)
        {
            var claims = new List<Claim>
            {
                new Claim(ClaimTypes.NameIdentifier, user.Id),
                new Claim(ClaimTypes.Email, user.Email),
                new Claim(ClaimTypes.DateOfBirth, user.Birthdate.ToString())
            };

            var roles = userManager.GetRolesAsync(user).Result;
            claims.AddRange(roles.Select(role => new Claim(ClaimsIdentity.DefaultRoleClaimType, role)));

            return claims;
        }
    }
}
