using FlutterApp.Server.Database.User;
using Microsoft.Extensions.Logging;

namespace FlutterApp.Server.Database;

public class DatabaseContainer : IDatabaseContainer
{
    public IUserRepository UserRepository { get; set; }
    
    
    public DatabaseContainer(PostgreSqlContext context, ILoggerFactory loggerFactory)
    {
        UserRepository = new UserRepository(context, loggerFactory);
    }
}