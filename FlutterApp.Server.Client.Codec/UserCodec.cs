using FlutterApp.Server.Database.User;

namespace FlutterApp.Server.Client.Codec;

public static class UserCodec
{
    public static Payload.User.User EncodeUser(UserModel dbModel)
    {
        return new Payload.User.User()
        {
            Id = dbModel.Id,
            // FirstName = dbModel.FirstName,
            // LastName = dbModel.LastName,
            HasPremium = dbModel.HasPremium
        };
    }
}