using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using Tarker.Booking.Application.External.GetTokenJwt;

namespace Tarker.Booking.External.GetTokenJwt;

public class GetTokenJwtService: IGetTokenJwtService
{
    private readonly IConfiguration _configuration;

    public GetTokenJwtService(IConfiguration configuration)
    {
        _configuration = configuration;
    }

    public string Execute(string id)
    {
        var tokenHandler = new JwtSecurityTokenHandler();
        string key = _configuration["SECRETKeyJwt"] ?? string.Empty;
        var signinkey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(key));

        var tokenDescriptor = new SecurityTokenDescriptor
        {
            Subject = new ClaimsIdentity(new Claim[]
            {
                new Claim(ClaimTypes.NameIdentifier, id)
            }),
            Expires = DateTime.UtcNow.AddMinutes(1),
            SigningCredentials = new SigningCredentials(signinkey, SecurityAlgorithms.HmacSha256Signature),
            Issuer = _configuration["IssuerJwt"],
            Audience = _configuration["AudienceJwt"]
        };

        var token = tokenHandler.CreateToken(tokenDescriptor);
        var tokenString = tokenHandler.WriteToken(token);

        return tokenString;
    }

}
