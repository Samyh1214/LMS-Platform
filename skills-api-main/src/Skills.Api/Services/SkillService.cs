
using Microsoft.EntityFrameworkCore;
using Skills.Api.Abstractions;
using Skills.Api.Data.Entities;
using Skills.Api.Data.Contexts;
using Skills.Api.Dtos;

namespace Skills.Api.Services;

public class SkillService(DataContext context) : ISkillService
{
    public async Task<GetSkillResponse> AddSkillAsync(string skillName, CancellationToken ct = default)
    {
        var existing = await context.Skills
            .FirstOrDefaultAsync(s => s.SkillName == skillName, ct);

        if (existing != null)
            return null;

        var skill = new Skill {  SkillName = skillName };

        context.Add(skill);
        await context.SaveChangesAsync(ct);

        return new GetSkillResponse(skill.Id, skill.SkillName);
    }

    public async Task<List<GetSkillResponse>> GetSkillAsync(CancellationToken ct = default)
    {
        return await context.Skills
            .Select(s => new GetSkillResponse(s.Id, s.SkillName))
            .ToListAsync(ct);
    }

    public async Task<bool> DeleteSkillAsync(int id, CancellationToken ct = default)
    {
        var skill = await context.Skills.FindAsync(id, ct);

        if (skill == null)
            return false;

        context.Remove(skill);
        await context.SaveChangesAsync(ct);
        return true;
    }
}
