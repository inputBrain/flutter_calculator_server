using System.Threading.Tasks;
using FlutterApp.Server.Database.User;

namespace FlutterApp.Server.UseCase;

public interface IUserUseCase
{
    Task<UserModel?> LoginByFirebase(string firebaseToken);
}