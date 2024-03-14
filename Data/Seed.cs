using System.Collections;
using SQ20.Net_Wee7_8_Task.Models;
using System.Net;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;
using System.Xml.Linq;
using SQ20.Net_Wee7_8_Task.Data.Enum;
using static System.Net.WebRequestMethods;
using Microsoft.AspNetCore.Identity;

namespace SQ20.Net_Wee7_8_Task.Data
{
    public class Seed
    {
        public static void SeedData(IApplicationBuilder applicationBuilder)
        {
            using (var serviceScope = applicationBuilder.ApplicationServices.CreateScope())
            {
                var context = serviceScope.ServiceProvider.GetService<ApplicationDbContext>();
                context.Database.EnsureCreated();

                if (!context.Experiences.Any())
                {
                    var experiences = new List<Experience>
                    {
                        new Experience
                        {
                            Title = ".Net Fullstack Developer",
                            Company = "Decagon",
                            Description = "Worked on a number of projects",
                            Location = "Lagos",
                            StartDate = new DateTime(2023, 01, 17),
                            EndDate = new DateTime(2023, 05, 17),
                        
                        },
                        new Experience
                        {
                            Title = "Embedded Systems Engineer",
                            Company = "Gentro",
                            Description = "Graduate Intern",
                            Location = "Lagos",
                            StartDate = DateTime.Today,
                            EndDate = new DateTime(2022, 02, 20),

                        },
                        new Experience
                        {
                            Title = "Power Systems Engineer",
                            Company = "Egbin Power Plant",
                            Description = "Technical Assistant",
                            Location = "Lagos",
                            StartDate = DateTime.Today,
                            EndDate = new DateTime(2023, 12, 20),

                        }

                    };

                    context.Experiences.AddRange(experiences);
                    context.SaveChanges();
                }

                if (!context.Contacts.Any())
                {
                    var contacts = new List<Contact>
                    {
                        new Contact
                        {
                            Name = "Precious Aimuan",
                            Email = "preciousaimuan@gmail.com",
                            Message = "Hi, Love your portfolio. Can we meet?",
                            DateSent = new DateTime(2022, 01, 05)
                        },
                        new Contact
                        {
                            Name = "Favour Ezeh",
                            Email = "favourezeh@gmail.com",
                            Message = "Hi, I'm really looking forward to working with you!",
                            DateSent = new DateTime(2022, 02, 13)
                        }
                    };
                    context.Contacts.AddRange(contacts);
                    context.SaveChanges();
                }

                if (!context.Educations.Any())
                {
                    var education = new List<Education>
                    {
                        new Education()
                        {
                            School = "University of Benin",
                            FieldOfStudy = "Electrical/Electronics Engineering",
                            Degree = "Bachelor of Engineering",
                            GraduationDate = new DateTime(2022, 10, 15),
                            CreatedAt = DateTime.Now,
                            /*UpdatedAt = null*/
                        },
                        new Education()
                        {
                            School = "Vera Grace Comprehensive College",
                            FieldOfStudy = "Science",
                            Degree = "Second Degree",
                            GraduationDate = new DateTime(2016, 06, 20),
                            CreatedAt = DateTime.Now,
                            /*UpdatedAt = null*/
                        }
                    };
                    context.Educations.AddRange(education);
                    context.SaveChanges();
                }

                if (!context.Projects.Any())
                {
                    var Projects = new List<Portfolio>
                    {
                        new Portfolio()
                        {
                            Title = "Garbage Disposal App Design",
                            Description = "App for garbage disposal",
                            Image = "https://localhost:7064/images/3309172.jpg",
                            AddressId = 1,
                            StartDate = new DateTime(2021, 10, 12),
                            CreatedAt = DateTime.Now,
                            UpdatedAt = null

                        },
                        new Portfolio()
                        {
                            Title = "Fitness Tracker App Design",
                            Description = "App for fitness tracking",
                            Image = "https://localhost:7064/images/4307057.jpg",
                            AddressId = 2,
                            StartDate = new DateTime(2021, 10, 12),
                            CreatedAt = DateTime.Now,
                            UpdatedAt = null

                        },
                        new Portfolio()
                        {
                            Title = "Smart Home App Design",
                            Description = "For an Interactive Home",
                            Image = "https://localhost:7064/images/4215605.jpg",
                            AddressId = 4,
                            StartDate = new DateTime(2021, 10, 12),
                            CreatedAt = DateTime.Now,
                            UpdatedAt = null

                        },
                        new Portfolio()
                        {
                            Title = "Real Estate App Design",
                            Description = "For Easy access to information on Affordable Properties",
                            Image = "https://localhost:7064/images/real-estate-app-interface-template_107173-12938.jpg",
                            AddressId = 5,
                            StartDate = new DateTime(2021, 10, 12),
                            CreatedAt = DateTime.Now,
                            UpdatedAt = null

                        },
                        new Portfolio()
                        {
                            Title = "Taxi App Interface Design",
                            Description = "App for Booking a Taxi",
                            Image = "https://localhost:7064/images/taxi-app-interface-concept_23-2148496314.jpg",
                            AddressId = 6,
                            StartDate = new DateTime(2021, 10, 12),
                            CreatedAt = DateTime.Now,
                            UpdatedAt = null

                        },
                        new Portfolio()
                        {
                            Title = "Online Course Application",
                            Description = "App for Taking Online Courses",
                            Image = "https://localhost:7064/images/taxi-app-interface-concept_23-2148496314.jpg",
                            AddressId = 6,
                            StartDate = new DateTime(2021, 10, 12),
                            CreatedAt = DateTime.Now,
                            UpdatedAt = null

                        }

                    };
                    context.Projects.AddRange(Projects);
                    context.SaveChanges();
                }

                if (!context.Services.Any())
                {
                    var services = new List<Service>
                    {
                        new Service()
                        {
                            Title = "Web Development",
                            Description = "Developing both frontend and backend components using HTML, CSS, JavaScript, and various web development frameworks.",
                            Image = "https://localhost:7064/images/s-1.svg"

                        },
                        new Service()
                        {
                            Title = "UI/UX Enhancement",
                            Description = "Integrating design aesthetics into web development to craft interfaces that are both visually engaging and intuitively user-friendly.",
                            Image = "https://localhost:7064/images/s-2.svg"


                        },
                        new Service()
                        {
                            Title = "Security Implementation",
                            Description = "Implementing security best practices in both embedded systems and web applications to ensure data integrity and user safety.",
                            Image = "https://localhost:7064/images/s-3.svg"

                        },

                    };
                    context.Services.AddRange(services);
                    context.SaveChanges();
                }

                if (!context.Abouts.Any())
                {
                    var abouts = new List<About>
                    {
                        new About()
                        {
                            Name = "Precious Aimuan",
                            Description = " I am a versatile Embedded Systems and Software Engineer, adept in hardware design and passionate about creating innovative and user-friendly websites. Proficient in HTML, CSS, JavaScript, and various web development tools, I seamlessly integrate software solutions into dynamic web applications. Committed to delivering high-quality work with keen attention to detail, my portfolio reflects the successful fusion of embedded systems and web development expertise.\r\n"
                        }

                    };
                    context.Abouts.AddRange(abouts);
                    context.SaveChanges();
                }

                if (!context.Skills.Any())
                {
                    var skills = new List<Skill>
                    {
                        new Skill()
                        {
                            Name = "Web Development",
                            Description = "HTML, CSS, JavaScript, and more. Frontend Frameworks, Backend Frameworks",
                            ProficiencyLevel = ProficiencyLevel.Intermediate,
                            CreatedAt = new DateTime(2020, 02, 20),
                            UpdatedAt = new DateTime(2021, 03, 26),
                        },
                        new Skill()
                        {
                            Name = "Database Management",
                            Description = "MySQL, PostgreSQL, NoSQL, MongoDB",
                            ProficiencyLevel = ProficiencyLevel.Advanced,
                            CreatedAt = new DateTime(2021, 02, 20),
                            UpdatedAt = new DateTime(2022, 03, 26),
                        },
                        new Skill()
                        {
                            Name = "Embedded Systems Design & Internet Of Things",
                            Description = "Shaping IoT Experiences with Innovative Solutions. Crafting Innovative Embedded Devices",
                            ProficiencyLevel = ProficiencyLevel.Advanced,
                            CreatedAt = new DateTime(2021, 02, 20),
                            UpdatedAt = new DateTime(2022, 03, 26),
                        },
                        new Skill()
                        {
                            Name = "API, Web Services & Version Control",
                            Description = "Designing, building, and consuming APIs. Git and platforms like GitHub",
                            ProficiencyLevel = ProficiencyLevel.Advanced,
                            CreatedAt = new DateTime(2021, 02, 20),
                            UpdatedAt = new DateTime(2022, 03, 26),
                        }
                    };
                    context.Skills.AddRange(skills);
                    context.SaveChanges();
                }
                if (!context.Socials.Any())
                {
                    var socials = new List<Social>
                    {
                        new Social()
                        {
                            Platform = "LinkedIn",
                            URL = "www.LinkedIn.com/example",
                            Username = "Precious Aimuan",
                           /* AppUser = new AppUser()
                            {
                                FullName = "Precious Aimuan",
                                DateOfBirth = new DateTime(2001, 06, 26),
                                Nationality = "Nigerian",
                                Address = "10, bola ahmed street, Era road, Lagos",
                                PhoneNumber = "08161452975",
                                Email = "preciousaimuan@gmail.com"
                            },*/
                            CreatedAt = new DateTime(2018, 02, 20),
                            UpdatedAt = new DateTime(2023, 03, 26),
                        },
                        new Social()
                        {
                            Platform = "GitHub",
                            URL = "www.github.com/example",
                            Username = "Precious Aimuan",
                            CreatedAt = new DateTime(2019, 02, 20),
                            UpdatedAt = new DateTime(2023, 04, 26),
                        },
                        new Social()
                        {
                            Platform = "FaceBook",
                            URL = "www.facebook.com/example",
                            Username = "Precious Aimuan",
                            CreatedAt = new DateTime(2021, 02, 20),
                            UpdatedAt = new DateTime(2023, 06, 26),
                        }
                    };
                    context.Socials.AddRange(socials);
                    context.SaveChanges();
                }
            }
        }
        public static async Task SeedUsersAndRolesAsync(IApplicationBuilder applicationBuilder)
        {
            using (var serviceScope = applicationBuilder.ApplicationServices.CreateScope())
            {
                //Roles
                var roleManager = serviceScope.ServiceProvider.GetRequiredService<RoleManager<IdentityRole>>();

                if (!await roleManager.RoleExistsAsync(UserRoles.Admin))
                    await roleManager.CreateAsync(new IdentityRole(UserRoles.Admin));
          

                //Users
                var userManager = serviceScope.ServiceProvider.GetRequiredService<UserManager<AppUser>>();
                string email = "dammydeji.dd@gmail.com";

                var adminUser = await userManager.FindByEmailAsync(email);

                if (adminUser == null)
                {
                    var newAdminUser = new AppUser
                    {
                        FullName = "Precious",
                        Email = email,
                        UserName = email,
                        EmailConfirmed = true,
                        Address = "10, era road"
                    };
                    await userManager.CreateAsync(newAdminUser, "Coding@1234?");
                    await userManager.AddToRoleAsync(newAdminUser, UserRoles.Admin);
                }

            }
        }
    }
}