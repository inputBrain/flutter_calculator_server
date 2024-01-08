namespace FlutterApp.Server.Client.User;

public sealed class GetOne
{
    public int UserId { get; set; }
    
    public sealed class Response
    {
        public Payload.User.User Ussr { get; set; }
    }
}