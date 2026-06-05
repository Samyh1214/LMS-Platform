namespace Achievements.Api.Data.Entities;

public class Achievement
{
    public int Id { get; set; }
    public string AchievementName { get; set; } = null!;

    public ICollection<UserAchievement> UserAchievements { get; set; } = [];
 
}
