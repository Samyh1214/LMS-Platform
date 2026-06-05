using Microsoft.AspNetCore.Authorization;
using Skills.Api.Abstractions;
using Skills.Api.Dtos;

namespace Skills.Api.Endpoints;


public static class SkillsEndpoints
{
    public static void MapSkillsEndpoints(this WebApplication app)
    {
        var group = app.MapGroup("/api/skills")
            .WithTags("Skills")
            .WithDescription("Handles skills");

        group.MapPost("/", AddSkill).RequireAuthorization("UserManage");
        group.MapGet("/", GetSkills);
        group.MapDelete("/{id}", DeleteSkill).RequireAuthorization("UserManage");

    }
    private static async Task<IResult> AddSkill(AddSkillRequest request, ISkillService service, CancellationToken ct = default)
    {
        if (string.IsNullOrWhiteSpace(request.SkillName))
            return Results.BadRequest("Skill name is required");

        var skill = await service.AddSkillAsync(request.SkillName, ct);

        if (skill == null)
            return Results.Conflict("Skill already exists");

        return Results.Created("/api/skills", skill);
    }

    private static async Task<IResult> GetSkills(ISkillService service, CancellationToken ct = default)
    {
        var skills = await service.GetSkillAsync(ct);
        return Results.Ok(skills);
    }

    private static async Task<IResult> DeleteSkill(int id, ISkillService service, CancellationToken ct = default)
    {
        var deleted = await service.DeleteSkillAsync(id, ct);

        if (!deleted)
            return Results.NotFound("Skill not found");

        return Results.NoContent();
    }
}
