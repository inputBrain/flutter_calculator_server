using FlutterApp.Server.Database;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace FlutterApp.Server.Host.Controllers.Client;

public class UserController : AbstractClientController<UserController>
{
    public UserController(ILogger<UserController> logger, IDatabaseContainer db) : base(logger, db)
    {
    }
    
}