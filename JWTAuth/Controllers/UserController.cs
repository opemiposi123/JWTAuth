using JWTAuth.Model;
using JWTAuth.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace JWTAuth.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class UserController : ControllerBase
	{
		private readonly IUserService _userService;
		public UserController(IUserService userService)
		{
			_userService = userService;
		}

		[HttpPost("register")]
		public async Task<ActionResult> RegisterAsync(RegisterModel model)
		{
			var result = await _userService.RegisterAsync(model);
			return Ok(result);
		}

		[HttpPost("token")]
		public async Task<IActionResult> GetTokenAsync(TokenRequestModel model)
		{
			var result = await _userService.GetTokenAsync(model);
			return Ok(result);
		}

		[HttpPost("addrole")]
		public async Task<IActionResult> AddRoleAsync(AddRoleModel model)
		{
			var result = await _userService.AddRoleAsync(model);
			return Ok(result);
		}

	}
}
