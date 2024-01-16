using AxLink.Service;
using FlutterApp.Server.Database;
using FlutterApp.Server.Database.SocialIdentity;
using FlutterApp.Server.Database.User;
using Microsoft.Extensions.Logging;

namespace FlutterApp.Server.UseCase;

public class UserUseCase : IUserUseCase
{
    private readonly ILogger<UserUseCase> _logger;
    private readonly IUserRepository _userRepository;
    private readonly ISocialIdentityRepository _socialIdentityRepository;
    private readonly FirebaseService _firebaseService;
    
    
    public UserUseCase(
        ILogger<UserUseCase> logger,
        IUserRepository userRepository,
        ISocialIdentityRepository socialIdentityRepository,
        FirebaseService firebaseService
    )
    {
        _logger = logger;
        _userRepository = userRepository;
        _socialIdentityRepository = socialIdentityRepository;
        _firebaseService = firebaseService;
    }
}