using Todo.Common.Models.Authentification;
using Todo.Services;
using CSharpFunctionalExtensions;
using Microsoft.AspNetCore.Mvc;

namespace Todo.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AuthController : BaseApiController
    {
        private readonly UserService _userService;

        public AuthController(UserService userService)
        {
            _userService = userService;
        }

        [HttpPost("authenticate")]
        public async Task<IActionResult> Authenticate(AuthenticateRequest model)
        {
            Result<AuthenticateResponse> response = await _userService.Authenticate(model);

            if (!response.IsSuccess)
                return NotFound(response.Error);

            return Ok(response.Value);
        }

        [HttpPost("register")]
        public async Task<IActionResult> Register(CreateUserRequest model)
        {
            Result<AuthenticateResponse> response = await _userService.Register(model);

            if (!response.IsSuccess)
                return NotFound(response.Error);

            return Ok(response.Value);
        }
    }
}