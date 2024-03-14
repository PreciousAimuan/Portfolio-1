using SQ20.Net_Wee7_8_Task.Data.Enum;

namespace SQ20.Net_Wee7_8_Task.Models
{
    public class Skill : BaseEntity
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public ProficiencyLevel ProficiencyLevel { get; set; }
        public IList<Experience> Experiences { get; set; }
        public IList<Portfolio> Projects { get; set; }
    }
}
