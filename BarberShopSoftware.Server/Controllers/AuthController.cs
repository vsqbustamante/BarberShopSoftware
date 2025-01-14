using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using BarberShopSoftware.Server.DTO;
using BarberShopSoftware.Server.Models;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Microsoft.AspNetCore.Identity.Data;

namespace BarberShop.Controllers.Server
{
    [ApiController]
    [Route("api/[controller]")]
    public class AuthController : ControllerBase
    {
        private readonly List<User> _users = new() // Simulated user storage
        {
            new User { Id = 1, Username = "admin", Password = "password", Role = "Admin" },
            new User { Id = 2, Username = "user", Password = "password", Role = "User" }
        };

        [HttpPost("login")]
        public IActionResult Login([FromBody] BarberShopSoftware.Server.DTO.LoginRequest login)
        {
            var user = _users.FirstOrDefault(u => u.Username == login.Username && u.Password == login.Password);
            if (user == null)
            {
                return Unauthorized("Invalid credentials");
            }

            var token = GenerateJwtToken(user);
            return Ok(new LoginResponse { Token = token, Role = user.Role });
        }

        private string GenerateJwtToken(User user)
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes("SecretKey12345"); // Replace with a secure key
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new[]
                {
                    new Claim(ClaimTypes.Name, user.Username),
                    new Claim(ClaimTypes.Role, user.Role)
                }),
                Expires = DateTime.UtcNow.AddHours(1),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };

            var token = tokenHandler.CreateToken(tokenDescriptor);
            return tokenHandler.WriteToken(token);
        }
    }
}
