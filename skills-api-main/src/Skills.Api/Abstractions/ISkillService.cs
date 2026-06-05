using Skills.Api.Dtos;

namespace Skills.Api.Abstractions;

public interface ISkillService
{
    Task<GetSkillResponse> AddSkillAsync(string skillName, CancellationToken ct = default);

    Task<List<GetSkillResponse>> GetSkillAsync(CancellationToken ct = default);

    Task<bool> DeleteSkillAsync(int id, CancellationToken ct = default);
}
