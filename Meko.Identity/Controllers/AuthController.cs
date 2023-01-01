using Meko.Identity.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace Meko.Identity.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        [HttpPost("login")]
        public IActionResult Login(LoginModel user)
        {
            if (user is null) { }

            if (user.UserName == "mahmoud" && user.Password == "P@ssw0rd")
            {
                var secretKey = new SymmetricSecurityKey(
                    Encoding.UTF8.GetBytes("AnaBabaYala@AnaBabaYala")
                );
                var signingCredential = new SigningCredentials(
                    secretKey,
                    SecurityAlgorithms.HmacSha256
                );

                var tokenOptions = new JwtSecurityToken(
                    issuer: "https://localhost:5001",
                    audience: "https://localhost:5001",
                    claims: new List<Claim>(),
                    expires: DateTime.Now.AddMinutes(5),
                    signingCredentials: signingCredential
                );

                var tokenString = new JwtSecurityTokenHandler().WriteToken(
                    tokenOptions
                );
                return Ok(tokenString);
            }
            return Unauthorized();
        }
    }
}
