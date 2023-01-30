using Infinite.AdminPage.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using Microsoft.VisualBasic;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using static System.Net.WebRequestMethods;

namespace Infinite.AdminPage.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AdminController : ControllerBase
    {
            private readonly IConfiguration _configuration;
            private readonly ApplicationDbContext _dbContext;
            public AdminController(IConfiguration configuration, ApplicationDbContext dbContext)
            {
                _configuration = configuration;
                _dbContext = dbContext;
            }
            [HttpPost("Login")]
            public IActionResult Login([FromBody] Login login)
            {
                var logu = _dbContext.admins.FirstOrDefault(a => a.Email == login.Email);
                if (logu == null)
                {
                    return BadRequest("Invalid Username");
                }
                var logp = _dbContext.admins.FirstOrDefault(b => b.Password == login.Password);
                if (logp == null)
                {
                    return BadRequest("Invalid Password");
                }
                var token = GenerateToken(logu);
                if(token==null)
                {
                return NotFound("Invalid Credentials");
                }

                return Ok(token);
            }
        [NonAction]
        public string GenerateToken(AdminHome admin)
        {
            var securitykey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["JWT:SecretKey"]));
            var credentials = new SigningCredentials(securitykey, SecurityAlgorithms.HmacSha512);
            var claim = new List<Claim>
            {
                new Claim(ClaimTypes.Name,admin.Email),
                new Claim(ClaimTypes.Name,admin.Password)

            };
            var token = new JwtSecurityToken(issuer: _configuration["JWT:issuer"], audience: _configuration["JWT:audience"], claims: claim, signingCredentials: credentials);
            JwtSecurityTokenHandler obj = new JwtSecurityTokenHandler();
            obj.WriteToken(token);
            return new JwtSecurityTokenHandler().WriteToken(token);
            
        }
    }
}
