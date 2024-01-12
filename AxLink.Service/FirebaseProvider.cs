using System;

namespace AxLink.Service;

public class FirebaseProvider
{
    public FirebaseProviderType Type { get; }

    public string ProviderUid { get; }



    public FirebaseProvider(FirebaseProviderType type, string providerUid)
    {
        Type = type;
        ProviderUid = providerUid;
    }


    public static FirebaseProvider Create(string provider, string providerUid)
    {
        switch (provider)
        {
            case "google.com":
                return new FirebaseProvider(FirebaseProviderType.Google, providerUid);
        }

        throw new ArgumentException("Error: tried to create provider with providerUid: " + providerUid);
    }
}