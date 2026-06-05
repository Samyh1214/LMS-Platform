namespace Skills.Api.Data.Entities;

public class UserSkill
{
    public int Id { get; set; }
    public string UserId { get; set; } = null!;
    public int SkillId { get; set; } 


    public Skill Skill { get; set; } = null!;
}
