using System.ComponentModel.DataAnnotations;

namespace FlutterApp.Server.Client.User;

public sealed class CreatePremium
{
    [Required]
    public int UserId { get; set; }
    
    [Required]
    public int? StartedAt { get; set; }
    
    [Required]
    public int? EndedAt { get; set; }


    public sealed class Response : AbstractResponse
    {
        public Payload.User.Premium Premium { get; set; }
    }
}