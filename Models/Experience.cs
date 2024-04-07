namespace SQ20.Net_Wee7_8_Task.Models
{
    public class Experience : BaseEntity
    {
        public string Title { get; set; }
        public string Company { get; set; }
        public string? Location { get; set; }
        public DateTime? StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public string? Description { get; set; }
        public IList<Skill?> Skills { get; set; }
    }
}
