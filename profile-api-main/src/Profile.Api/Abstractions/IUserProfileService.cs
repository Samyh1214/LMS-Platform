using Profile.Api.Dtos;

namespace Profile.Api.Abstractions;

public interface IUserProfileService
{
    Task<GetUserProfileResponse?> GetUserProfileAsync(string userId, CancellationToken ct = default);
    Task<GetUserProfileResponse?> UpdateUserProfileAsync(string userId, UpdateUserProfileRequest request, CancellationToken ct = default);
    Task<GetUserProfileResponse?> CreateUserProfileAsync(string userId, CreateUserProfileRequest request, CancellationToken ct = default);
}
