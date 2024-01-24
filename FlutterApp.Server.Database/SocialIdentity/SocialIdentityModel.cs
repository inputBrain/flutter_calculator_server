using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using FlutterApp.Server.Database.User;
using FlutterApp.Server.Model.SocialIdentity;

namespace FlutterApp.Server.Database.SocialIdentity;

public class SocialIdentityModel : AbstractModel, ISocialIdentity
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int Id { get; set; }

    public int UserId { get; set; }

    [ForeignKey("UserId")]
    public UserModel User { get; set; }

    public string Uid { get; set; }

    public SocialType SocialType { get; set; }

    [DataType(DataType.Date)]
    public DateTime CreatedAt { get; set; }


    public static SocialIdentityModel CreateModel(int userId, string uid, SocialType socialType, DateTime createdAt)
    {
        return new SocialIdentityModel
        {
            UserId = userId,
            Uid = uid,
            SocialType = socialType,
            CreatedAt = createdAt,
        };
    }
}