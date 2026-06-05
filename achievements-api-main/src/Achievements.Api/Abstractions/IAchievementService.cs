using Achievements.Api.Dtos;

namespace Achievements.Api.Abstractions;

public interface IAchievementService
{
    Task<List<GetAchievementResponse>> GetAchievementsAsync(CancellationToken ct = default);
}
