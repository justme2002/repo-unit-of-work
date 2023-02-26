using Microsoft.AspNetCore.Mvc;
using App.Services;
using App.Services.Interface;
using App.Infrastructure.Data.Request;
using App.Infrastructure.Data.Response;

namespace App.Controllers
{
  [Route("api/[controller]")]
  [ApiController]
  public class UserController : ControllerBase
  {
    private readonly IUserService userService;
    public UserController(IUserService userService)
    {
      this.userService = userService;
    }
    [HttpPost]
    public async Task<IActionResult> Get([FromBody] AddUserRequest AddUserRequest)
    {
      var result = await this.userService.AddUserAsync(AddUserRequest);
      if (result.Status != true)
      {
        return StatusCode(StatusCodes.Status400BadRequest, new BaseResponse
        {
          Status = false,
          Message = "Bad Request"
        });
      }
      return StatusCode(StatusCodes.Status200OK, new BaseResponse
      {
        Status = true,
        Message = "OK"
      });
    }
  }
}