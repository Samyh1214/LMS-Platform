using Skills.Api.Abstractions;
using Skills.Api.Dtos;

namespace Skills.Api.Endpoints;

public static class UserSkillsEndpoints
{
    public static void MapUserSkillsEndpoints(this WebApplication app)
    {
        var group = app.MapGroup("/api/userskills")
            .WithTags("UserSkills")
            .WithDescription("Handles user skills")
            .RequireAuthorization();

        group.MapPost("/", AddUserSkill);
        group.MapGet("/", GetUserSkills);
        group.MapDelete("/{id}", DeleteUserSkill);

    }

    private static async Task<IResult> AddUserSkill(HttpContext httpContext, AddUserSkillRequest request, 
        IUserSkillService service, CancellationToken ct = default)
    {
        var userId = httpContext.User.FindFirst("sub")?.Value
            ?? httpContext.User.FindFirst(System.Security.Claims.ClaimTypes.NameIdentifier)?.Value;

        if (string.IsNullOrEmpty(userId))
            return Results.Unauthorized();

        if (request.SkillId <= 0)
            return Results.BadRequest("SkillId is required");

        var userSkill = await service.AddUserSkillAsync(userId, request.SkillId, ct);

        if (userSkill == null)
            return Results.NotFound("Skill not found");

        return Results.Created("/api/userskills", userSkill);
    }

    private static async Task<IResult> GetUserSkills(HttpContext httpContext, IUserSkillService service, CancellationToken ct = default)
    {

        var userId = httpContext.User.FindFirst("sub")?.Value
            ?? httpContext.User.FindFirst(System.Security.Claims.ClaimTypes.NameIdentifier)?.Value;

        if (string.IsNullOrEmpty(userId))
            return Results.Unauthorized();

        var userSkills = await service.GetUserSkillsAsync(userId, ct);
        return Results.Ok(userSkills);
    }

    private static async Task<IResult> DeleteUserSkill(int id, IUserSkillService service, CancellationToken ct = default)
    {
        var deleted = await service.DeleteUserSkillAsync(id, ct);

        if (!deleted)
            return Results.NotFound("User skill not found");

        return Results.NoContent();
    }
}
