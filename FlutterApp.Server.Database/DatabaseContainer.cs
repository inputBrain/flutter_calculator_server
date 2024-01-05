using FlutterApp.Server.Database.User;
using FlutterApp.Server.Database.User.Premium;
using Microsoft.Extensions.Logging;

namespace FlutterApp.Server.Database;

public class DatabaseContainer : IDatabaseContainer
{
    public IUserRepository UserRepository { get; set; }
    public IPremiumRepository PremiumRepository { get; set; }


    public DatabaseContainer(PostgreSqlContext context, ILoggerFactory loggerFactory)
    {
        UserRepository = new UserRepository(context, loggerFactory);
        PremiumRepository = new PremiumRepository(context, loggerFactory);
    }
}