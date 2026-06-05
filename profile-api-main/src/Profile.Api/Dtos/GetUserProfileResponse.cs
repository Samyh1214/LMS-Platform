namespace Profile.Api.Dtos;

public record GetUserProfileResponse
(
     int Id,
     string UserId,
     string? FirstName,
     string? LastName,
     string? PhoneNumber,
     string? Description,
     string? ProfileImageUrl
);
