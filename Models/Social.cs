namespace SQ20.Net_Wee7_8_Task.Models
{
    public class Social : BaseEntity
    {
        public string Platform { get; set; }
        public string Username { get; set; }
        public string URL { get; set; }
        public AppUser AppUser { get; set; }
    }
}
