namespace Profile.Api.Dtos;

public record UpdateUserProfileRequest
(
    string? FirstName,
    string? LastName,
    string? PhoneNumber,
    string? Description,
    string? ProfileImageUrl
);