using System;
using System.Threading.Tasks;
using FlutterApp.Server.Client.Codec;
using FlutterApp.Server.Client.Payload.User;
using FlutterApp.Server.Client.User;
using FlutterApp.Server.Database;
using FlutterApp.Server.Utils;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace FlutterApp.Server.Host.Controllers.Client;

public class UserController : AbstractClientController<UserController>
{
    public UserController(ILogger<UserController> logger, IDatabaseContainer db) : base(logger, db)
    {
    }


    [HttpGet]
    public async Task<GetOne.Response> GetOneUser([FromBody] GetOne request)
    {
        var model = await Db.UserRepository.GetOne(request.UserId);

        return new GetOne.Response
        {
            Ussr = UserCodec.EncodeUser(model)
        };
    }


    [HttpPost]
    [AllowAnonymous]
    public async Task<CreateUser.Response> CreateUser([FromBody] CreateUser request)
    {
        var model = await Db.UserRepository.Create(request.FirstName, request.LastName, request.Phone, DateTime.Now);

        return new CreateUser.Response
        {
            User = UserCodec.EncodeUser(model)
        };
    }


    [HttpPost]
    public async Task<CreatePremium.Response> CreatePremium([FromBody] CreatePremium request)
    {
        var user = await Db.UserRepository.GetOne(request.UserId);
        
        var premium = await Db.PremiumRepository.Create(
            user,
            request.StartedAt != null ? Timestamp.TimestampToDateTime(request.StartedAt.Value) : (DateTime?) null,
            request.EndedAt != null ? Timestamp.TimestampToDateTime(request.EndedAt.Value) : (DateTime?) null
        );

        var updateHasPremiumStatus = await Db.UserRepository.UpdateHasPremium(user, true);

        return new CreatePremium.Response()
        {
            Premium = new Premium()
            {
                Id = premium.Id,
                User = UserCodec.EncodeUser(user),
                StartedAt = premium.PremiumStartedAt != null ? Timestamp.ToUnixTime(premium.PremiumStartedAt.Value) : (int?) null,
                EndedAt = premium.PremiumEndedAt != null ? Timestamp.ToUnixTime(premium.PremiumEndedAt.Value) : (int?) null,
            }
        };
    }
}