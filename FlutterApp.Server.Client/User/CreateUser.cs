namespace FlutterApp.Server.Client.User;

public sealed class CreateUser
{
    public string FirstName { get; set; }
    public string LastName { get; set; }

    public string Phone { get; set; }


    public sealed class Response
    {
        public Payload.User.User User { get; set; }
    }
}