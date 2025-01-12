using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TaskApp.Business.DTOs.Auth;
using TaskApp.Business.Service.Interface;

namespace TaskApp.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        IUserService userService;

        public AuthController(IUserService userService)
        {
            this.userService = userService;
        }

        [HttpPost("[Action]")]
        public async Task<IActionResult> Register([FromForm]RegisterDto registerDto)
        {
            await userService.Register(registerDto);
            return Ok();
        }

        [HttpPost("[Action]")]
        public async Task<IActionResult> Login([FromForm]LoginDto loginDto)
        {
            return Ok(await userService.Login(loginDto));
        }


    }
}
