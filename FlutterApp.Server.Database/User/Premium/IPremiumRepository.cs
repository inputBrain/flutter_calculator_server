using System;
using System.Threading.Tasks;

namespace FlutterApp.Server.Database.User.Premium;

public interface IPremiumRepository
{
    Task<PremiumModel> Create(UserModel user, DateTime? startedAt, DateTime? endedAt);
}