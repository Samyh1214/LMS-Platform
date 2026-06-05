using Skills.Api.Dtos;

namespace Skills.Api.Abstractions;

public interface IUserSkillService
{
    Task<GetUserSkillResponse?> AddUserSkillAsync(string userId, int skillId, CancellationToken ct = default);

    Task<List<GetUserSkillResponse>> GetUserSkillsAsync(string userId, CancellationToken ct = default);

    Task<bool> DeleteUserSkillAsync(int id, CancellationToken ct = default);
}
