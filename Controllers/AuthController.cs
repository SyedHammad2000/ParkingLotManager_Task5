using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

[ApiController]
[Route("api/[controller]")]

public class AuthController : Controller
{
    private readonly IConfiguration _configuration;

    public AuthController(IConfiguration configuration)
    {
        _configuration = configuration;
    }

    [HttpPost("login")]
    public ActionResult Login(LoginRequest request)
    {
        if (request.Username != "admin" ||
            request.Password != "123456")
        {
            return Unauthorized();
        }

        var jwt = _configuration.GetSection("Jwt");

        var claims = new[]
        {
        new Claim(ClaimTypes.Name, request.Username)
    };

        var key = new SymmetricSecurityKey(
            Encoding.UTF8.GetBytes(jwt["Key"]!));

        var credentials = new SigningCredentials(
            key,
            SecurityAlgorithms.HmacSha256);

        var token = new JwtSecurityToken(
            issuer: jwt["Issuer"],
            audience: jwt["Audience"],
            claims: claims,
            expires: DateTime.UtcNow.AddMinutes(
                Convert.ToDouble(jwt["ExpiryMinutes"])),
            signingCredentials: credentials);

        var jwtToken = new JwtSecurityTokenHandler()
            .WriteToken(token);

        return Ok(new LoginResponse
        {
            Token = jwtToken
        });
    }
}


