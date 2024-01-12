using System;
using System.Threading.Tasks;
using AxLink.Service;
using FlutterApp.Server.Client.Auth;
using FlutterApp.Server.Database;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace FlutterApp.Server.Host.Controllers.Client;

public class AuthController : AbstractClientController<AuthController>
{
    private readonly FirebaseService _firebaseService;
    
    
    public AuthController(ILogger<AuthController> logger, IDatabaseContainer db, FirebaseService firebaseService) : base(logger, db)
    {
        _firebaseService = firebaseService;
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

        var socialUser = await _firebaseService.GetUserInfo(request.FirebaseToken);
        if (socialUser == null)
        {
            throw new Exception("Invalid Firebase token");
        }
        var user = await Db.UserRepository.
    }
}