using System;
using System.Threading.Tasks;
using FlutterApp.Server.Client.Auth;
using FlutterApp.Server.Database;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace FlutterApp.Server.Host.Controllers.Client;

public class AuthController : AbstractClientController<AuthController>
{
    public AuthController(ILogger<AuthController> logger, IDatabaseContainer db) : base(logger, db)
    {
    }

    
    [HttpPost]
    [AllowAnonymous]
    [ProducesResponseType(typeof(AuthByFirebase.Response), 200)]
    public async Task<IActionResult> AuthByFirebase([FromBody] AuthByFirebase request)
    {
        if (ModelState.IsValid == false)
        {
            return BadRequest("Auth Error");
        }
        
        var user = await Db.UserRepository.
    }
}