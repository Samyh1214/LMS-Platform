namespace Skills.Api.Dtos;

public record GetUserSkillResponse 
(
    int Id,
    string UserId,
    int SkillId,
    string SkillName
);