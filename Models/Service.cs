namespace SQ20.Net_Wee7_8_Task.Models
{
    public class Service : BaseEntity
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public string Image { get; set; }
        public AppUser? AppUser { get; set; }
    }
}
