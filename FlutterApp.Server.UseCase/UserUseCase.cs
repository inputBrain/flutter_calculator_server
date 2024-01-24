using System;
using System.Threading.Tasks;
using AxLink.Service;
using FlutterApp.Server.Database;
using FlutterApp.Server.Database.SocialIdentity;
using FlutterApp.Server.Database.User;
using FlutterApp.Server.Model.SocialIdentity;
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
    
    
    public async Task<UserModel?> LoginByFirebase(string firebaseToken)
    {
        var socialUser = await _firebaseService.GetUserInfo(firebaseToken);
        if (socialUser == null)
        {
            throw new Exception("Invalid Firebase token");
        }
        
        var user = await _socialIdentityRepository.FindByUid(socialUser.Uid);
        if (user.Item1 == null && user.Item2 == null)
        {
            var userModel = await _userRepository.Create(socialUser.FirstName, socialUser.LastName, socialUser.AvatarUrl, socialUser.PhoneNumber, DateTime.Now);
            
            
             user.Item1 = await _socialIdentityRepository.Create(
                userModel.Id, 
                socialUser.Uid,
                SocialType.Google,
                DateTime.Now
            );
        }

        return user.Item2;
    }
}