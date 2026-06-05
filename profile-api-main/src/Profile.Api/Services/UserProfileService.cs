using Microsoft.EntityFrameworkCore;
using Profile.Api.Abstractions;
using Profile.Api.Data.Contexts;
using Profile.Api.Dtos;
using Profile.Api.Entities;

namespace Profile.Api.Services;

public class UserProfileService(DataContext context) : IUserProfileService
{
    public async Task<GetUserProfileResponse?> CreateUserProfileAsync(string userId, CreateUserProfileRequest request, CancellationToken ct = default)
    {
        var existing = await context.UserProfiles
            .FirstOrDefaultAsync(x => x.UserId == userId, ct);

        if (existing != null)
            return null;

        var userProfile = new UserProfile
        {
            UserId = userId,
            FirstName = request.FirstName,
            LastName = request.LastName
        };

        context.Add(userProfile);
        await context.SaveChangesAsync(ct);

        return new GetUserProfileResponse(
            userProfile.Id,
            userProfile.UserId,
            userProfile.FirstName,
            userProfile.LastName,
            userProfile.PhoneNumber,
            userProfile.Description,
            userProfile.ProfileImageUrl
        );
    }

    public async Task<GetUserProfileResponse?> GetUserProfileAsync(string userId, CancellationToken ct = default)
    {
        var userProfile = await context.UserProfiles
            .FirstOrDefaultAsync(x => x.UserId == userId, ct);

        if (userProfile == null)
            return null;

        return new GetUserProfileResponse(
            userProfile.Id,
            userProfile.UserId,
            userProfile.FirstName,
            userProfile.LastName,
            userProfile.PhoneNumber,
            userProfile.Description,
            userProfile.ProfileImageUrl
        );
    }

    public async Task<GetUserProfileResponse?> UpdateUserProfileAsync(string userId, UpdateUserProfileRequest request, CancellationToken ct = default)
    {
        var userProfile = await context.UserProfiles
            .FirstOrDefaultAsync(x => x.UserId == userId, ct);

        if (userProfile == null)
            return null;

        userProfile.FirstName = request.FirstName;
        userProfile.LastName = request.LastName;
        userProfile.PhoneNumber = request.PhoneNumber;
        userProfile.Description = request.Description;
        userProfile.ProfileImageUrl = request.ProfileImageUrl;

        await context.SaveChangesAsync(ct);

        return new GetUserProfileResponse(
            userProfile.Id,
            userProfile.UserId,
            userProfile.FirstName,
            userProfile.LastName,
            userProfile.PhoneNumber,
            userProfile.Description,
            userProfile.ProfileImageUrl
        );
    }
}
