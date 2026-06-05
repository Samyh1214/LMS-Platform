using Achievements.Api.Abstractions;

namespace Achievements.Api.Endpoints;

public static class AchievementsEndpoints
{
    public static void MapAchievementsEndpoints(this WebApplication app)
    {
        var group = app.MapGroup("/api/achievements")
            .WithTags("Achievements")
            .WithDescription("Handles achievements");

        group.MapGet("/", GetAchievements);


    }
    private static async Task<IResult> GetAchievements(IAchievementService service, CancellationToken ct = default)
    {
        var achievements = await service.GetAchievementsAsync(ct);
        return Results.Ok(achievements);
    }
}