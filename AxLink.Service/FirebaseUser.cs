namespace AxLink.Service;

public class FirebaseUser
{
    public string Uid { get; }

    public string? Email { get; }

    public string? PhoneNumber { get; }

    public string? AvatarUrl { get; }

    public string? FirstName { get; }

    public string? LastName { get; }

    public FirebaseProvider Provider { get; }


    public FirebaseUser(
        FirebaseProvider provider,
        string uid,
        string firstName,
        string lastName,
        string? email,
        string? phoneNumber,
        string? avatarUrl
    )
    {
        Uid = uid;
        Email = email;
        PhoneNumber = phoneNumber;
        AvatarUrl = avatarUrl;
        FirstName = firstName;
        LastName = lastName;
        Provider = provider;
    }
}