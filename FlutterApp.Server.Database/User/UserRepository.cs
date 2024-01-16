using System;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;

namespace FlutterApp.Server.Database.User;

public class UserRepository : AbstractRepository<UserModel>, IUserRepository
{
    public UserRepository(PostgreSqlContext context, ILoggerFactory loggerFactory) : base(context, loggerFactory)
    {
    }
    
    
    public async Task<UserModel> Create(string? firstName, string? lastName, string? phone, DateTime createdAt)
    {
        var model = UserModel.CreateModel(firstName, lastName, phone, createdAt);

        var result = await CreateModelAsync(model);
        if (result == null)
        {
            throw new Exception("User model is not created");
        }
        
        return result;
    }
    
    
    public async Task<UserModel> GetOne(int userId)
    {
        var model = await FindOne(userId);
        if (model == null)
        {
            throw new Exception("User not found");
        }

        return model;
    }
    
    
    public async Task<bool> UpdateHasPremium(UserModel model, bool hasPremium)
    {
        model.HasPremium = hasPremium;
        var result = await UpdateModelAsync(model);
        return true;
    }
}