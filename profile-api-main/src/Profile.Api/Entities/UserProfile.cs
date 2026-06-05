namespace Profile.Api.Entities;

public class UserProfile
{
    public int Id { get; set; }
    public string UserId { get; set; } = null!;
    public string? FirstName { get; set; }
    public string? LastName { get; set; } 
    public string? PhoneNumber { get; set; }
    public string? Description { get; set; }
    public string? ProfileImageUrl { get; set; }
}
