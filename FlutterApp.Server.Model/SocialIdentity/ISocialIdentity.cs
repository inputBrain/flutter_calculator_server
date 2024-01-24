namespace FlutterApp.Server.Model.SocialIdentity;

public interface ISocialIdentity
{
    int Id { get; set; }
    
    string Uid { get; set; }
    
    SocialType SocialType { get; set; }
}