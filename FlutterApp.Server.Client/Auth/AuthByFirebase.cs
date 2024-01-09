using System.ComponentModel.DataAnnotations;

namespace FlutterApp.Server.Client.Auth;

public sealed class AuthByFirebase
{
    [Required]
    public string FirebaseToken { get; set; }


    public sealed class Response
    {
        [Required]
        public Payload.User.User User { get; }
        
        [Required]
        public string Token { get; }

        
        public Response(Payload.User.User user, string token)
        {
            User = user;
            Token = token;
        }
    }
}