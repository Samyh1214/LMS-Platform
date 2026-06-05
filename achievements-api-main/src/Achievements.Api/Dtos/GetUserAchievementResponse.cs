namespace Achievements.Api.Dtos;

public record GetUserAchievementResponse
(
    int Id,
    string UserId,
    int AchievementId,
    string AchievementName
);
