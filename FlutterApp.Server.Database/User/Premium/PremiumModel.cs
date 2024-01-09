using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FlutterApp.Server.Database.User.Premium;

public class PremiumModel : AbstractModel
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int Id { get; set; }

    public int UserId { get; set; }
    
    [ForeignKey("UserId")]
    public UserModel User { get; set; }
    
    public DateTime? PremiumStartedAt { get; set; }
    
    public DateTime? PremiumEndedAt { get; set; }

    
    public static PremiumModel CreateModel(UserModel user, DateTime? startedAt, DateTime? endedAt)
    {
        return new PremiumModel
        {
            User = user,
            PremiumStartedAt = startedAt,
            PremiumEndedAt = endedAt
        };
    }
}