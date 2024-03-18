using Application.Applcation;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebApplication.Models;
using WebApplication.Token;

namespace WebApplication.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly ApplicationUser _applicationUser;

        public UserController(ApplicationUser applicationUser)
        {
            _applicationUser = applicationUser;
        }

        [AllowAnonymous]
        [Produces("application/json")]
        [HttpPost("/api/CreateToken")]
        public async Task<IActionResult> CreateToken([FromBody] Login login)
        {
            if (string.IsNullOrWhiteSpace(login.email) || string.IsNullOrWhiteSpace(login.password))
                return Unauthorized();

            var result = await _applicationUser.ExistUser(login.email, login.password); 
            if (result)
            {
                var token = new TokenJWTBuilder()
                    .AddSecurityKey(JWTSecurity.Create("Secret_Key-12345678"))
                    .AddSubject("Empresa - idk")
                    .AddIssuer("DDD.Securiry.Bearer")
                    .AddAudience("DDD.Securiry.Bearer")
                    .AddClaim("UserAPINumber", "1")
                    .AddExpiry(5)
                    .Builder();

                return Ok(token.value);
            }
            return Unauthorized();
        }

        public async Task<IActionResult> CreateUser([FromBody] Login login)
        {
            if (string.IsNullOrWhiteSpace(login.email) || string.IsNullOrWhiteSpace(login.password))
                return BadRequest("Error in also input");


            var result = await _applicationUser.AddUser(login.email, login.password, login.age, login.phone);
            if (result)
            {
                return Ok("Sucess");
            }
            return BadRequest("Fail");
        }
    }
}
