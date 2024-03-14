namespace SQ20.Net_Wee7_8_Task.Models
{
    public class Education : BaseEntity
    {
        public string Degree { get; set; }
        public string FieldOfStudy { get; set; }
        public string School { get; set; }
        public DateTime GraduationDate { get; set; }

    }
}
