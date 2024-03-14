namespace SQ20.Net_Wee7_8_Task.Models
{
    public class Contact : BaseEntity
    {
        public string Name { get; set; }
        public string Email { get; set; }
        public string Message { get; set; }
        public DateTime DateSent { get; set; }
    }
}
