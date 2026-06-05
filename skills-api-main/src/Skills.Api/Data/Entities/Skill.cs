namespace Skills.Api.Data.Entities;

public class Skill
{
    public int Id { get; set; }
    public string SkillName { get; set; } = null!;


    public ICollection<UserSkill> UserSkills { get; set; } = [];
}
