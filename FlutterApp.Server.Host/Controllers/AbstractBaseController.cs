using FlutterApp.Server.Database;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace FlutterApp.Server.Host.Controllers;

[ApiController]
public abstract class AbstractBaseController<T> : ControllerBase
{
    protected readonly ILogger<T> Logger;

    protected readonly IDatabaseContainer Db;


    protected AbstractBaseController(ILogger<T> logger, IDatabaseContainer db)
    {
        Logger = logger;
        Db = db;
    }
    
    protected IActionResult SendOk()
    {
        return Ok();
    }


    protected IActionResult SendOk(object response)
    {
        return Ok(response);
    }
}