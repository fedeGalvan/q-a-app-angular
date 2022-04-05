using Api.Domain.IServices;
using Api.Domain.Models;
using Api.DTO;
using Api.Utils;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace Api.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class UserController : Controller
    {
        private readonly IUserService _userService;
        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpPost]
        public async Task<IActionResult> CreateUser([FromBody] User user)
        {
            try
            {
                var validateExistence = await _userService.UserAlreadyExists(user);

                if (validateExistence)
                {
                    return BadRequest(new { message = "Username already taken!" });
                }
                user.Password = Crypt.CryptPassword(user.Password);
                await _userService.SaveUser(user);
                return Ok(new
                {
                    message = "User successfully created."
                });
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            };

        }

        [HttpPut]
        public async Task<IActionResult> ChangePassword([FromBody] ChangePasswordDTO password)
        {
            try
            {

                int userId = 10;
                string criptedPassword = Crypt.CryptPassword(password.prevPassword);

                var user = await _userService.ValidatePassword(userId, criptedPassword);

                if (user == null)
                {
                    return BadRequest(new { message = "The password is not correct." });
                }
                else
                {
                    user.Password = Crypt.CryptPassword(password.newPassword);

                    await _userService.UpdatePassword(user);
                    return Ok(new
                    {
                        message = "The password was successfully updated."
                    });
                }


            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
