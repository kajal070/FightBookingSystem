using FlightBookingSystemFolder.Models;
namespace FlightBookingSystemFolder.Repository;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using System.Security.Claims;
using System.IdentityModel.Tokens.Jwt;

public class TokenHandler : ITokenHandler
{
    private readonly IConfiguration configuration;
    public TokenHandler(IConfiguration configuration)
    {
        this.configuration=configuration;
    }
    public string CreateTokenAsync(Registration reg)
    {
         var key =new SymmetricSecurityKey(Encoding.UTF8.GetBytes(configuration["Jwt:Key"]));

            var claims= new Claim[]{
                new Claim(ClaimTypes.Name,reg.FullName),
                new Claim(ClaimTypes.NameIdentifier,reg.Email.ToString())
        
            };

            var signingCredentials= new SigningCredentials(
                key,SecurityAlgorithms.HmacSha256);
            
           var token=new JwtSecurityToken(
            configuration["Jwt:Issuer"],
            configuration["Jwt:Audience"],
            claims,
            expires:DateTime.Now.AddMinutes(10),
            signingCredentials:signingCredentials
           );
           var jwtTokenhandler = new JwtSecurityTokenHandler();

            return jwtTokenhandler.WriteToken(token);
        }
    }

