using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using FlutterApp.Server.Database.SocialIdentity;
using FlutterApp.Server.Database.User.Premium;

namespace FlutterApp.Server.Database.User;

public class UserModel : AbstractModel
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int Id { get; set; }

    public string? FirstName { get; set; }
    
    public string? LastName { get; set; }
    
    public string? Phone { get; set; }
    
    public bool HasPremium { get; set; }
    
    public PremiumModel? Premium { get; set; }
    
    public SocialIdentityModel? SocialIdentity { get; set; }
    
    public DateTime CreatedAt { get; set; }


    public static UserModel CreateModel(string? firstName, string? lastName, string? phone, DateTime createdAt)
    {
        return new UserModel
        {
            FirstName = firstName,
            LastName = lastName,
            Phone = phone,
            HasPremium = false,
            CreatedAt = createdAt
        };
    }
}