using Achievements.Api.Abstractions;
using Achievements.Api.Dtos;

namespace Achievements.Api.Endpoints;

public static class UserAchievementsEndpoints
{
    public static void MapUserAchievementsEndpoints(this WebApplication app)
    {
        var group = app.MapGroup("/api/userachievements")
            .WithTags("UserAchievements")
            .WithDescription("Handles user achievements")
            .RequireAuthorization();

        group.MapGet("/", GetUserAchievements);
        group.MapPost("/", AddUserAchievements);


    }
    private static async Task<IResult> GetUserAchievements(HttpContext httpContext, IUserAchievementService service, CancellationToken ct = default)
    {
        var userId = httpContext.User.FindFirst("sub")?.Value
            ?? httpContext.User.FindFirst(System.Security.Claims.ClaimTypes.NameIdentifier)?.Value;

        if (string.IsNullOrEmpty(userId))
            return Results.Unauthorized();


        var userAchievements = await service.GetUserAchievementsAsync(userId, ct);
        return Results.Ok(userAchievements);
    }
    private static async Task<IResult> AddUserAchievements(HttpContext httpContext, AddUserAchievementRequest request, IUserAchievementService service, CancellationToken ct = default)
    {
        var userId = httpContext.User.FindFirst("sub")?.Value
            ?? httpContext.User.FindFirst(System.Security.Claims.ClaimTypes.NameIdentifier)?.Value;

        if (string.IsNullOrEmpty(userId))
            return Results.Unauthorized();

        try
        {
            var userAchievement = await service.AddUserAchievementAsync(userId, request, ct);
            return Results.Created("/api/userachievements", userAchievement);
        }
        catch (KeyNotFoundException ex)
        {
            return Results.NotFound(ex.Message);
        }
        catch (InvalidOperationException ex)
        {
            return Results.Conflict(ex.Message);
        }
    }
}
