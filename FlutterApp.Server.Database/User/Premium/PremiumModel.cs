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
    
    public DateTimeOffset? PremiumStartedAt { get; set; }
    
    public DateTimeOffset? PremiumEndedAt { get; set; }

    
    public static PremiumModel CreateModel(int userId, DateTime startedAt, DateTime endedAt)
    {
        return new PremiumModel
        {
            UserId = userId,
            PremiumStartedAt = startedAt,
            PremiumEndedAt = endedAt
        };
    }
}