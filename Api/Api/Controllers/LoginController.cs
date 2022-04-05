using Api.Domain.IServices;
using Api.Domain.Models;
using Api.Utils;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace Api.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class LoginController : Controller
    {
        private readonly ILoginService _loginService;
        public LoginController(ILoginService loginService)
        {
            _loginService = loginService;
        }


        public async Task<IActionResult> Auth([FromBody] User user)
        {
            try
            {

                user.Password = Crypt.CryptPassword(user.Password);
                var username = await _loginService.ValidateUser(user);

                if (username == null)
                {
                    return NotFound(new { message = "User or password invalid" });
                }
                else
                {
                    return Ok(new { user = user.Username });
                }



            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);
            };
        }

    }
}
