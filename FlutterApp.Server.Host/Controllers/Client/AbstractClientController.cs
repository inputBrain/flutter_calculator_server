using FlutterApp.Server.Database;
using FlutterApp.Server.UseCase;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace FlutterApp.Server.Host.Controllers.Client;

[ApiController]
[Authorize]
[Produces("application/json")]
[Route("api/[controller]/[action]")]
public abstract class AbstractClientController<T> : AbstractBaseController<T>
{
    protected AbstractClientController(ILogger<T> logger, IUseCaseContainer useCase, IDatabaseContainer db) : base(logger, useCase, db)
    {
    }
}