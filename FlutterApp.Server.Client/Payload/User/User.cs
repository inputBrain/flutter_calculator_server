using System.ComponentModel.DataAnnotations;

namespace FlutterApp.Server.Client.Payload.User;

public class User
{
    [Required]
    public int Id { get; set; }
    
    [Required]
    public string FirstName { get; set; }
    
    [Required]
    public string LastName { get; set; }
    
    [Required]
    public bool HasPremium { get; set; }
}