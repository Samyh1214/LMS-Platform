using Microsoft.EntityFrameworkCore;
using Skills.Api.Abstractions;
using Skills.Api.Data.Contexts;
using Skills.Api.Data.Entities;
using Skills.Api.Dtos;

namespace Skills.Api.Services;

public class UserSkillService(DataContext context) : IUserSkillService
{
    public async Task<GetUserSkillResponse?> AddUserSkillAsync(string userId, int skillId, CancellationToken ct = default)
    {
        var skill = await context.Skills.FindAsync(skillId, ct);

        if (skill == null)
            return null;

        var userSkill = new UserSkill { UserId = userId, SkillId = skillId };

        context.Add(userSkill);
        await context.SaveChangesAsync(ct);

        return new GetUserSkillResponse(userSkill.Id, userSkill.UserId, userSkill.SkillId, userSkill.Skill.SkillName);
    }
    public async Task<List<GetUserSkillResponse>> GetUserSkillsAsync(string userId, CancellationToken ct = default)
    {
        return await context.UserSkills
            .Include(us => us.Skill)
            .Where(us => us.UserId == userId)
            .Select(us => new GetUserSkillResponse(us.Id, us.UserId, us.SkillId, us.Skill.SkillName))
            .ToListAsync(ct);
    }

    public async Task<bool> DeleteUserSkillAsync(int id, CancellationToken ct = default)
    {
        var userSkill = await context.UserSkills.FindAsync(id, ct);

        if (userSkill == null)
            return false;

        context.Remove(userSkill);
        await context.SaveChangesAsync(ct);
        return true;
    }


}
