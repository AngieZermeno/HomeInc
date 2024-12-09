using HomeInc.Domain.Entities;
using HomeInc.Infraestructure.DataBase;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace HomeInc.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthenticationController : ControllerBase
    {
        private readonly HomeContext _context;

        private readonly string SecretKey;

        public AuthenticationController(IConfiguration configuration, HomeContext context)
        {
            SecretKey = configuration.GetSection("Settins:SecretKey").Value;
            _context = context;
        }

        [HttpPost]
        public  IActionResult LoginValidation([FromBody] Login login)
        {
            var result =  _context.Usuarios.FirstOrDefaultAsync(x => x.Email == login.Email && x.Password == login.Password);

            if(result != null)
            {
                var keyBytes = Encoding.UTF8.GetBytes(SecretKey);
                var claims = new ClaimsIdentity();

                claims.AddClaim(new Claim(ClaimTypes.NameIdentifier, login.Email));
                claims.AddClaim(new Claim(ClaimTypes.Name, login.Email));

                var tokenDesc = new SecurityTokenDescriptor
                {
                    Subject = claims,
                    Expires = DateTime.UtcNow.AddMinutes(20),
                    SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(keyBytes), SecurityAlgorithms.HmacSha256)
                };

                var tokenHanlder = new JwtSecurityTokenHandler();
                var tokenConfig = tokenHanlder.CreateToken(tokenDesc);

                var tokenCreado = tokenHanlder.WriteToken(tokenConfig);               

                return Ok(tokenCreado);
            }

            return Unauthorized(new { message = "Usuario no encontrado"});

        }
    }
}
