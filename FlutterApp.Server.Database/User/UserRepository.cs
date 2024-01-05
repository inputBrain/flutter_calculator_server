using System;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;

namespace FlutterApp.Server.Database.User;

public class UserRepository : AbstractRepository<UserModel>, IUserRepository
{
    public UserRepository(PostgreSqlContext context, ILoggerFactory loggerFactory) : base(context, loggerFactory)
    {
    }
    
    
    public async Task<UserModel> Create(string firstName, string lastName)
    {
        var model = UserModel.CreateModel(firstName, lastName);

        var result = await CreateModelAsync(model);
        if (result == null)
        {
            throw new Exception("User model is not created");
        }
        
        return result;
    }
}