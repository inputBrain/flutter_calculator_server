using System;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;

namespace FlutterApp.Server.Database.User.Premium;

public class PremiumRepository : AbstractRepository<PremiumModel>, IPremiumRepository
{
    public PremiumRepository(PostgreSqlContext context, ILoggerFactory loggerFactory) : base(context, loggerFactory)
    {
    }
    
    
    public async Task<PremiumModel> Create(int userId, DateTime startedAt, DateTime endedAt)
    {
        var model = PremiumModel.CreateModel(userId, startedAt, endedAt);

        var result = await CreateModelAsync(model);
        if (result == null)
        {
            throw new Exception("Premium model is not created");
        }
        
        return result;
    }
}