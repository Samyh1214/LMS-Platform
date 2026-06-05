using Microsoft.EntityFrameworkCore;
using Achievements.Api.Abstractions;
using Achievements.Api.Data.Contexts;
using Achievements.Api.Dtos;

namespace Achievements.Api.Services;

public class AchievementService(DataContext context) : IAchievementService
{
    public async Task<List<GetAchievementResponse>> GetAchievementsAsync(CancellationToken ct = default)
    {
        return await context.Achievements
            .Select(s => new GetAchievementResponse(s.Id, s.AchievementName))
            .ToListAsync(ct);
    }
}
