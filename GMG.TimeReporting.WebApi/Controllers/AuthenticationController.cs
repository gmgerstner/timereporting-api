using GMG.TimeReporting.Core.PasswordArchiveData;
using GMG.TimeReporting.WebApi.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;

namespace GMG.TimeReporting.WebApi.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class AuthenticationController : ControllerBase
    {
        private const int DefaultTokenExpiration = 240; //in minutes
        private IConfiguration _configuration;
        private readonly PasswordArchiveContext passwordArchiveContext;

        public AuthenticationController(IConfiguration configuration, PasswordArchiveContext passwordArchiveContext)
        {
            _configuration = configuration;
            this.passwordArchiveContext = passwordArchiveContext;
        }

        /// <summary>
        /// Login to system
        /// </summary>
        /// <param name="username"></param>
        /// <param name="password"></param>
        /// <returns></returns>
        [Route("Login")]
        [AllowAnonymous]
        [HttpPost]
        public ActionResult<User> Login([FromBody] LoginCredentials login)
        {
            try
            {
                var owner = passwordArchiveContext.Passwords
                    .Where(p => p.Url == "https://timereporting.gmgdigitaltechnologies.com")
                    .Where(p => p.Username == login.Username)
                    .SingleOrDefault();
                if (owner == null)
                {
                    //Log.Warning($"Invalid log in for user: {login.Username}");
                    return BadRequest();
                }
                if (owner.PasswordValue != login.Password)
                {
                    //Log.Warning($"Invalid log in for user: {login.Username}");
                    return BadRequest();
                }

                var expires = DateTime.Now.AddMinutes(DefaultTokenExpiration);

                var endOfWorkDay = DateTime.Today.AddHours(12 + 6);//5 PM
                if (endOfWorkDay > expires)
                {
                    //prevent expiration before work day is done
                    expires = endOfWorkDay;
                }

                var userresult = new User
                {
                    Username = owner.Username,
                    Token = GenerateJSONWebToken(owner, expires),
                    Expires = expires
                };
                var token = GenerateJSONWebToken(owner, expires);

                //Log.Information($"User logged in: {login.Username}");
                return Ok(userresult);
            }
            catch (Exception ex)
            {
                //Log.Error(ex, "Error logging in.");
                throw;
            }
        }

        private string GenerateJSONWebToken(Password userInfo, DateTime expires)
        {
            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["Jwt:Key"]));
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

            var claims = new[] {
                new Claim(JwtRegisteredClaimNames.Sub, userInfo.SystemUserId.ToString()),
                //new Claim(JwtRegisteredClaimNames.Email, userInfo.EmailAddress),
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),

                new Claim("userid", userInfo.PasswordId.ToString()),
                new Claim("username", userInfo.Username),
            };

            var token = new JwtSecurityToken(
                _configuration["Jwt:Issuer"],
                _configuration["Jwt:Issuer"],
                claims,
                expires: expires,
                signingCredentials: credentials);

            return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }
}
