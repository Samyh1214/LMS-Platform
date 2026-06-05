using Achievements.Api.Dtos;

namespace Achievements.Api.Abstractions;

public interface IUserAchievementService
{
    Task<List<GetUserAchievementResponse>> GetUserAchievementsAsync(string userId, CancellationToken ct = default);
    Task<GetUserAchievementResponse> AddUserAchievementAsync(string userId, AddUserAchievementRequest request, CancellationToken ct = default);
}
