using SQ20.Net_Wee7_8_Task.Models;

namespace SQ20.Net_Wee7_8_Task.ViewModels
{
    public class DashboardViewModel
    {
        public List<Portfolio> Portfolios { get; set; }
        public List<Service> Services { get; set; }
        public List<Skill> Skills { get; set; }
        public List<Education> Educations { get; set; }
        public List<Experience> Experiences { get; set; }
        public List<About> Abouts { get; set; }
    }
}
