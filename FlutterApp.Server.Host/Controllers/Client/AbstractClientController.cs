using FlutterApp.Server.Database;
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
    protected AbstractClientController(ILogger<T> logger, IDatabaseContainer db) : base(logger, db)
    {
    }
    
    
}