using Microsoft.EntityFrameworkCore;
using Skills.Api.Data.Entities;

namespace Skills.Api.Data.Contexts;

public class DataContext(DbContextOptions<DataContext> options) : DbContext(options)
{
    public DbSet<Skill> Skills => Set<Skill>();
    public DbSet<UserSkill> UserSkills => Set<UserSkill>();

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.Entity<Skill>(x =>
        {
            x.ToTable("Skills");

            x.HasKey(x => x.Id);

            x.Property(x => x.SkillName)
                .IsRequired();

            x.HasIndex(x => x.SkillName)
                .IsUnique();
        });

        modelBuilder.Entity<UserSkill>(x =>
        {
            x.ToTable("UserSkills");

            x.HasKey(x => x.Id);

            x.Property(x => x.UserId)
                .IsRequired();

            x.Property(x => x.SkillId)
                .IsRequired();

            x.HasIndex(x => new { x.UserId, x.SkillId })
                .IsUnique();

            x.HasOne(x => x.Skill)
                .WithMany(x => x.UserSkills)
                .HasForeignKey(x => x.SkillId)
                .OnDelete(DeleteBehavior.Cascade);
        });
    }
}
