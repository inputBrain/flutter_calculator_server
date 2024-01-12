using FlutterApp.Server.Database.SocialIdentity;
using FlutterApp.Server.Database.User;
using FlutterApp.Server.Database.User.Premium;

namespace FlutterApp.Server.Database;

public interface IDatabaseContainer
{
    IUserRepository UserRepository { get; }
    IPremiumRepository PremiumRepository { get; }
    ISocialIdentityRepository SocialIdentityRepository { get; }
}