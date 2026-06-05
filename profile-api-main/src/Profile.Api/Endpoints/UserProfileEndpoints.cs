using Microsoft.AspNetCore.Authorization;
using Profile.Api.Abstractions;
using Profile.Api.Dtos;

namespace Profile.Api.Endpoints;

public static class UserProfileEndpoints
{
    public static void MapUserProfileEndpoints(this WebApplication app)
    {
        var group = app.MapGroup("/api/profile")
            .WithTags("Profile")
            .WithDescription("Handles user profile");
            

        group.MapGet("/", GetUserProfile).RequireAuthorization(); 
        group.MapPut("/", UpdateUserProfile).RequireAuthorization();
        group.MapPost("/", CreateUserProfile).RequireAuthorization();
        group.MapGet("/{userId}", GetUserProfileById);
    }

    private static async Task<IResult> CreateUserProfile(HttpContext httpContext, CreateUserProfileRequest request, IUserProfileService service, CancellationToken ct = default)
    {
        var userId = httpContext.User.FindFirst("sub")?.Value
            ?? httpContext.User.FindFirst(System.Security.Claims.ClaimTypes.NameIdentifier)?.Value;

        if (string.IsNullOrEmpty(userId))
            return Results.Unauthorized();

        var userProfile = await service.CreateUserProfileAsync(userId, request, ct);

        if (userProfile == null)
            return Results.Conflict("Profile already exists");

        return Results.Created("/api/profile", userProfile);
    }
    private static async Task<IResult> GetUserProfile(HttpContext httpContext, IUserProfileService service, CancellationToken ct = default)
    {
        var userId = httpContext.User.FindFirst("sub")?.Value 
            ?? httpContext.User.FindFirst(System.Security.Claims.ClaimTypes.NameIdentifier)?.Value;

        if (string.IsNullOrEmpty(userId))
            return Results.Unauthorized();

        var userProfile = await service.GetUserProfileAsync(userId, ct);

        return Results.Ok(userProfile);
    }
    private static async Task<IResult> GetUserProfileById(string userId, IUserProfileService service, CancellationToken ct = default)
    {
        var userProfile = await service.GetUserProfileAsync(userId, ct);

        if (userProfile == null)
            return Results.NotFound();

        return Results.Ok(userProfile);
    }


    private static async Task<IResult> UpdateUserProfile(HttpContext httpContext, UpdateUserProfileRequest request,
        IUserProfileService service, CancellationToken ct = default)
    {
        var userId = httpContext.User.FindFirst("sub")?.Value
            ?? httpContext.User.FindFirst(System.Security.Claims.ClaimTypes.NameIdentifier)?.Value;

        if (string.IsNullOrEmpty(userId))
            return Results.Unauthorized();

        var userProfile = await service.UpdateUserProfileAsync(userId, request, ct);

        if (userProfile == null)
            return Results.NotFound();

        return Results.Ok(userProfile);
    }

}
