namespace Dentistry.Api.Controllers;

[ApiController]
[Route("api/v1/[controller]/[action]")]
[AllowAnonymous]
[ProducesResponseType(type: typeof(Response<object?>), 200)]
[ProducesResponseType(400)]
[ProducesResponseType(500)]
[ProducesResponseType(401)]
[ProducesResponseType(403)]
public class ApplicationController : ControllerBase
{

}