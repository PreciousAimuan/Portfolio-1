using SQ20.Net_Wee7_8_Task.Models;

namespace SQ20.Net_Wee7_8_Task.ViewModels
{
    public class EditProjectViewModel
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public int? AddressId { get; set; }
        public IFormFile Image { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public IList<Skill> Skills { get; set; }
    }
}
