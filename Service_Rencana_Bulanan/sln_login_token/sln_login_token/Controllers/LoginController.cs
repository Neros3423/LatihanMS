using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using sln_login_token.ModelsMeta;
using System.IdentityModel.Tokens.Jwt;
using System.Text;

namespace sln_login_token.Controllers
{
    [Route("api/LoginUser")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        private IConfiguration config;

        public LoginController(IConfiguration _configuration)
        {
            config = _configuration;
        }

        private Users UserAuthenticate(Users obj)
        {
            if (obj.username=="Admin" && obj.password=="cieadmin123")
            {
                return obj;
            }
            else
            {
                return null;
            }
        }

        private string GenerateToken(Users users)
        {
            var securitykey= new SymmetricSecurityKey(Encoding.UTF8.GetBytes(config["Jwt:Key"]));
            var credentials = new SigningCredentials(securitykey, SecurityAlgorithms.HmacSha256);

            var token= new JwtSecurityToken(config["Jwt:Issuer"], config["Jwt:Audience"],null,null,
                expires:DateTime.Now.AddMinutes(5),signingCredentials:credentials);
            return new JwtSecurityTokenHandler().WriteToken(token);
        }

        [AllowAnonymous]
        [HttpPost]
        public IActionResult login(Users users)
        {
            IActionResult response = Unauthorized();
            var auth_user = UserAuthenticate(users);
            if (auth_user != null)
            {
                var token = GenerateToken(auth_user);
                response = Ok(new { token = token });
            }
            return response;
        }

    }
}
