namespace SQ20.Net_Wee7_8_Task.Models
{
    public class Portfolio : BaseEntity
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public string Image { get; set; }
        public int? AddressId { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public IList<Skill> Skills { get; set; }

    }
}
