using System.Data.Entity;
using Microsoft.AspNetCore.Mvc;
using SQ20.Net_Wee7_8_Task.Models;
using System.Diagnostics;
using SQ20.Net_Wee7_8_Task.Data;
using SQ20.Net_Wee7_8_Task.ViewModels;

namespace SQ20.Net_Wee7_8_Task.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly ApplicationDbContext _context;

        public HomeController(ILogger<HomeController> logger, ApplicationDbContext context)
        {
            _logger = logger;
            _context = context;
        }

        public IActionResult Index()
        {
            var abouts = _context.Abouts.ToList();
            var portfolios = _context.Projects.ToList();
            var experiences = _context.Experiences.ToList();
            var services = _context.Services.ToList();
            var skills = _context.Skills.ToList();   
            var educations = _context.Educations.ToList();

            var mymodel = new DashboardViewModel
            {
                Abouts = abouts,
                Portfolios = portfolios,
                Experiences = experiences,
                Services = services,
                Skills = skills,
                Educations = educations,
            };
            return View(mymodel);
        }

        public IActionResult Contact()
        {
            return View();
        }
        public IActionResult About()
        {
            return View();
        }

        public IActionResult Portfolio()
        {
            return View();
        }

        public IActionResult Services()
        {
            return View();
        }
       

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
