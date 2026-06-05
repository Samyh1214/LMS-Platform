using Microsoft.EntityFrameworkCore;
using Achievements.Api.Abstractions;
using Achievements.Api.Data.Contexts;
using Achievements.Api.Dtos;
using Achievements.Api.Data.Entities;

namespace Achievements.Api.Services;

public class UserAchievementService(DataContext context) : IUserAchievementService
{
    public async Task<GetUserAchievementResponse> AddUserAchievementAsync(string userId, AddUserAchievementRequest request, CancellationToken ct = default)
    {
        var achievement = await context.Achievements
            .FirstOrDefaultAsync(a => a.AchievementName == request.AchievementName, ct);

        if (achievement == null)
            throw new KeyNotFoundException("Achievement not found");

        var existing = await context.UserAchievements
             .FirstOrDefaultAsync(ua => ua.UserId == userId && ua.AchievementId == achievement.Id, ct);

        if (existing != null)
            throw new InvalidOperationException("User already has this achievement");

        var userAchievement = new UserAchievement
        {
            UserId = userId,
            AchievementId = achievement.Id
        };

        context.Add(userAchievement);
        await context.SaveChangesAsync(ct);

        return new GetUserAchievementResponse(
            userAchievement.Id, 
            userAchievement.UserId, 
            userAchievement.AchievementId, 
            achievement.AchievementName 
        );
    }

    public async Task<List<GetUserAchievementResponse>> GetUserAchievementsAsync(string userId, CancellationToken ct = default)
    {
        return await context.UserAchievements
            .Include(ua => ua.Achievement)
            .Where(ua => ua.UserId == userId)
            .Select(ua => new GetUserAchievementResponse(ua.Id, ua.UserId, ua.AchievementId, ua.Achievement.AchievementName))
            .ToListAsync(ct);
    }
}
