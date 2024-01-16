using System;
using System.Threading.Tasks;
using AxLink.Service;
using FlutterApp.Server.Client.Auth;
using FlutterApp.Server.Database;
using FlutterApp.Server.Database.SocialIdentity;
using FlutterApp.Server.Model.SocialIdentity;
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

        var socialUserModel = new SocialIdentityModel();
        var user = await Db.SocialIdentityRepository.FindByUid(socialUser.Uid);
        if (user.Item1 == null && user.Item2 == null)
        {
            var userModel = await Db.UserRepository.Create(socialUser.FirstName, socialUser.LastName, socialUser.PhoneNumber, DateTime.Now);
            
            
            socialUserModel = await Db.SocialIdentityRepository.Create(
                userModel.Id, 
                socialUser.Uid,
                user.Item1.SocialUid,
                SocialType.Google,
                DateTime.Now
                );
        }

        return SendOk(socialUserModel);
    }
}