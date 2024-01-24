using System;
using System.Threading.Tasks;
using FlutterApp.Server.Database.User;
using FlutterApp.Server.Model.SocialIdentity;

namespace FlutterApp.Server.Database.SocialIdentity;

public interface ISocialIdentityRepository
{
    Task<SocialIdentityModel> Create(
        int userId,
        string uid,
        SocialType socialType,
        DateTime createdAt
    );
    
    Task<(SocialIdentityModel?, UserModel?)> FindByUid(string uid);
}