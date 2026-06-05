namespace Achievements.Api.Data.Entities;

public class UserAchievement
{
    public int Id { get; set; }
    public string UserId { get; set; } = null!;
    public int AchievementId { get; set; }

    public Achievement Achievement { get; set; } = null!;
}