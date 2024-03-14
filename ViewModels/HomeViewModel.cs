using SQ20.Net_Wee7_8_Task.Models;

namespace SQ20.Net_Wee7_8_Task.ViewModels
{
    public class HomeViewModel
    {
        public IEnumerable<Portfolio> Portfolios { get; set; }
        public IEnumerable<Service> Services { get; set; }
        public IEnumerable<Skill> Skills { get; set; }
        public IEnumerable<Education> Educations { get; set; }
        public IEnumerable<Experience> Experiences { get; set; }
        public About Abouts { get; set; }
    }
}
