using FlutterApp.Server.Database.User;

namespace FlutterApp.Server.Database;

public interface IDatabaseContainer
{
    IUserRepository UserRepository { get; }
}