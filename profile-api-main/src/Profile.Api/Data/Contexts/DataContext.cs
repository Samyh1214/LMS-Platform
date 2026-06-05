using Microsoft.EntityFrameworkCore;
using Profile.Api.Entities;

namespace Profile.Api.Data.Contexts;

public class DataContext(DbContextOptions<DataContext> options) : DbContext(options)
{
    public DbSet<UserProfile> UserProfiles => Set<UserProfile>();

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.Entity<UserProfile>(x =>
        {
            x.ToTable("UserProfiles");

            x.HasKey(x => x.Id);

            x.Property(x => x.UserId)
                .IsRequired();

            x.HasIndex(x => x.UserId)
                .IsUnique();
        });
    }
}
