namespace SQ20.Net_Wee7_8_Task.Models
{
    public class BaseEntity
    {
        public Guid Id { get; set; }
        public DateTime? CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }
    }
}
