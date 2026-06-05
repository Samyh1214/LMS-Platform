using Achievements.Api.Data.Entities;
using Microsoft.EntityFrameworkCore;

namespace Achievements.Api.Data.Contexts;

public class DataContext(DbContextOptions<DataContext> options) : DbContext(options)
{
    public DbSet<Achievement> Achievements => Set<Achievement>();
    public DbSet<UserAchievement> UserAchievements => Set<UserAchievement>();

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.Entity<Achievement>(x =>
        {
            x.ToTable("Achievements");
            x.HasKey(x => x.Id);
            x.Property(x => x.AchievementName)
                .IsRequired();
            x.HasIndex(x => x.AchievementName)
                .IsUnique();
        });

        modelBuilder.Entity<UserAchievement>(x =>
        {
            x.ToTable("UserAchievements");
            x.HasKey(x => x.Id);
            x.Property(x => x.UserId)
                .IsRequired();
            x.Property(x => x.AchievementId)
                .IsRequired();
            x.HasIndex(x => new { x.UserId, x.AchievementId })
                .IsUnique();
            x.HasOne(x => x.Achievement)
                .WithMany(x => x.UserAchievements)
                .HasForeignKey(x => x.AchievementId)
                .OnDelete(DeleteBehavior.Cascade);
        });
    }
}
