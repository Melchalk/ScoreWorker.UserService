using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;
using UserService.Business.Credentials.Interfaces;
using UserService.Models.Dto.Requests;
using UserService.Models.Dto.Responses;

namespace UserService.Controllers;

[SwaggerTag("Управление учетными данными пользователей")]
[Authorize]
[ApiController]
[Route("api/credentials")]
[Produces("application/json")]
public class CredentialsController : ControllerBase
{
    [HttpPost("create")]
    public async Task<ResponseInfo<bool>> CreateAsync(
      [FromServices] ICreateCredentialsCommand command,
      [FromBody] CreateCredentialsRequest request,
      CancellationToken cancellationToken)
    {
        return await command.ExecuteAsync(request, cancellationToken);
    }
}
