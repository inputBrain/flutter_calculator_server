using AxLink.Service;
using FlutterApp.Server.Database;
using Microsoft.Extensions.Logging;

namespace FlutterApp.Server.UseCase;

public static class Factory
{
    public static IUseCaseContainer Create(ILoggerFactory loggerFactory, IDatabaseContainer databaseContainer, FirebaseService firebaseService)
    {
        return new UseCaseContainer(
            new UserUseCase(
                loggerFactory.CreateLogger<UserUseCase>(),
                databaseContainer.UserRepository,
                databaseContainer.SocialIdentityRepository,
                firebaseService
            )
        );
    }
}