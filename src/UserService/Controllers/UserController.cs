using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;
using UserService.Business.User.Interfaces;
using UserService.Models.Dto.Requests;
using UserService.Models.Dto.Responses;

namespace UserService.Controllers;

[SwaggerTag("Управление пользователями")]
[Authorize]
[ApiController]
[Route("api/user")]
[Produces("application/json")]
public class UserController : ControllerBase
{
    [HttpPost("create")]
    public async Task<ResponseInfo<bool>> CreateAsync(
      [FromServices] ICreateUserCommand command,
      [FromBody] CreateUserRequest request,
      CancellationToken cancellationToken)
    {
        return await command.ExecuteAsync(request, cancellationToken);
    }

    [HttpGet("get")]
    public async Task<ResponseInfo<GetUserResponse>> GetAsync(
      [FromServices] IGetUserCommand command,
      [FromQuery] Guid id,
      CancellationToken cancellationToken)
    {
        return await command.ExecuteAsync(id, cancellationToken);
    }

    [HttpGet("get/current")]
    public async Task<ResponseInfo<GetUserResponse>> GetCurrentAsync(
      [FromServices] IGetCurrentUserCommand command,
      CancellationToken cancellationToken)
    {
        return await command.ExecuteAsync(cancellationToken);
    }

    [HttpPut("update")]
    public async Task<ResponseInfo<bool>> UpdateAsync(
      [FromServices] IUpdateUserCommand command,
      [FromBody] UpdateUserRequest request,
      CancellationToken cancellationToken)
    {
        return await command.ExecuteAsync(request, cancellationToken);
    }

    [HttpDelete("remove")]
    public async Task<ResponseInfo<bool>> RemoveAsync(
      [FromServices] IDeleteUserCommand command,
      [FromQuery] Guid id,
      CancellationToken cancellationToken)
    {
        return await command.ExecuteAsync(id, cancellationToken);
    }
}
