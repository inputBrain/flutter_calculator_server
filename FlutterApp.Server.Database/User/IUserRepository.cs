using System.Threading.Tasks;

namespace FlutterApp.Server.Database.User;

public interface IUserRepository
{
    Task<UserModel> Create(string firstName, string lastName);
}