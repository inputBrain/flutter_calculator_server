using System;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using FirebaseAdmin;
using FirebaseAdmin.Auth;
using Google.Apis.Auth.OAuth2;
using Microsoft.Extensions.Logging;

namespace AxLink.Service;

public class FirebaseService
{
    private readonly ILogger<FirebaseService> _logger;

    private readonly FirebaseApp _firebaseApp;


    public FirebaseService(ILogger<FirebaseService> logger, string credentialFilePath)
    {
        if (File.Exists(credentialFilePath) == false)
        {
            throw new Exception("File does not exist in: " + credentialFilePath);
        }
        
        _logger = logger;

        _firebaseApp = FirebaseApp.Create(
            new AppOptions()
            {
                Credential = GoogleCredential.FromFile(credentialFilePath)
            }
        );
    }


    public async Task<FirebaseUser?> GetUserInfo(string token)
    {
        try
        {
            var defaultAuth = FirebaseAuth.GetAuth(_firebaseApp);
            var result = await defaultAuth.VerifyIdTokenAsync(token);

            var user = await defaultAuth.GetUserAsync(result.Uid);
            return EncodeFirebaseUser(user);
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            return null;
        }
    }

    

    private FirebaseUser EncodeFirebaseUser(UserRecord userRecord)
    {
        var data = userRecord.ProviderData.FirstOrDefault();
        if (data == null)
        {
            throw new ArgumentException("Firebase User encode error. ProviderData is null");
        }

        var name = (userRecord.DisplayName != null) ? userRecord.DisplayName.Split(' ') : new[] {""};

        return new FirebaseUser(
            FirebaseProvider.Create(data.ProviderId, data.Uid),
            userRecord.Uid,
            name[0],
            name.Length == 2 ? name[1] : "",
            userRecord.Email,
            userRecord.PhoneNumber,
            userRecord.PhotoUrl
        );
    }
}