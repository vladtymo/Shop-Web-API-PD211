using Data.Entities;
using System.Security.Claims;

namespace Core.Interfaces
{
    public interface IJwtService
    {
        // ------- Access Token
        IEnumerable<Claim> GetClaims(User user);
        string CreateToken(IEnumerable<Claim> claims);

        // ------- Refresh Token
        //string CreateRefreshToken();
        //IEnumerable<Claim> GetClaimsFromExpiredToken(string token);
        //DateTime GetLastValidRefreshTokenDate();
    }
}
