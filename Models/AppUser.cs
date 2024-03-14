using Microsoft.AspNetCore.Identity;

namespace SQ20.Net_Wee7_8_Task.Models
{
    public class AppUser: IdentityUser
    {
        public string? FullName { get; set; }
        public DateTime? DateOfBirth { get; set; }
        public string? Nationality { get; set; }
        public string? Password { get; set; }
        public string? Address { get; set; }
        public IList<Social?> Socials { get; set; }
        public string? CV { get; set; }
        public IList<Service?> Services { get; set; }
        public IList<Contact?> Contacts { get; set; }
    }
}
