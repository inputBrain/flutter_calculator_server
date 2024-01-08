using System.ComponentModel.DataAnnotations;

namespace FlutterApp.Server.Client.Payload.User;

public class Premium
{
    [Required]
    public int Id { get; set; }
        
    [Required]
    public User User { get; set; }
    
    [Required]
    public int? StartedAt { get; set; }
    
    [Required]
    public int? EndedAt { get; set; }

}