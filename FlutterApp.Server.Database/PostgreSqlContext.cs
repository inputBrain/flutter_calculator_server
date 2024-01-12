using FlutterApp.Server.Database.SocialIdentity;
using FlutterApp.Server.Database.User;
using FlutterApp.Server.Database.User.Premium;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace FlutterApp.Server.Database;

public class PostgreSqlContext : DbContext
{
    public IDatabaseContainer Db { get; set; }
    
    public DbSet<UserModel> User { get; set; }
    public DbSet<PremiumModel> Premium { get; set; }
    public DbSet<SocialIdentityModel> SocialIdentity { get; set; }
    
    
    public PostgreSqlContext(DbContextOptions<PostgreSqlContext> options, ILoggerFactory loggerFactory) : base(options)
    {
        Db = new DatabaseContainer(this, loggerFactory);
    }
}