using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace UserService.Controllers;

[SwaggerTag("Управление пользователями")]
[Authorize]
[ApiController]
[Route("api/user")]
[Produces("application/json")]
public class UserController : ControllerBase
{

}
