using Microsoft.Extensions.Logging;

namespace FlutterApp.Server.Database.SocialIdentity;

public class SocialIdentityRepository : AbstractRepository<SocialIdentityModel>, ISocialIdentityRepository
{
    public SocialIdentityRepository(PostgreSqlContext context, ILoggerFactory loggerFactory) : base(context, loggerFactory)
    {
    }
}