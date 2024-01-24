using System;
using System.Threading.Tasks;
using AxLink.Service;
using FlutterApp.Server.Client.Auth;
using FlutterApp.Server.Client.Codec;
using FlutterApp.Server.Database;
using FlutterApp.Server.Database.SocialIdentity;
using FlutterApp.Server.Database.User;
using FlutterApp.Server.Model.SocialIdentity;
using FlutterApp.Server.UseCase;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace FlutterApp.Server.Host.Controllers.Client;

public class AuthController : AbstractClientController<AuthController>
{
    public AuthController(ILogger<AuthController> logger, IUseCaseContainer useCase, IDatabaseContainer db) : base(logger, useCase, db)
    {
    }
    

   
    [HttpPost]
    [AllowAnonymous]
    [Consumes("application/json")]
    [ProducesResponseType(typeof(AuthByFirebase.Response), 200)]
    public async Task<IActionResult> AuthByFirebase([FromBody] AuthByFirebase request)
    {
        if (ModelState.IsValid == false)
        {
            return BadRequest("Auth Error");
        }

        var userModel = await UseCase.UserUseCase.LoginByFirebase(request.FirebaseToken);

        return Ok(new AuthByFirebase.Response(UserCodec.EncodeUser(userModel), ""));
    }

}