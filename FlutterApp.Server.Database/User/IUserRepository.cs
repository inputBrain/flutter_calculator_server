using System;
using System.Threading.Tasks;

namespace FlutterApp.Server.Database.User;

public interface IUserRepository
{
    Task<UserModel?> Create(string? firstName, string? lastName, string? avatarUrl, string? phone, DateTime createdAt);

    Task<UserModel> GetOne(int userId);

    Task<bool> UpdateHasPremium(UserModel model, bool hasPremium);
}