using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SQ20.Net_Wee7_8_Task.Models;
using System.Diagnostics;

namespace SQ20.Net_Wee7_8_Task.Controllers
{
    //[Authorize(Roles = "Admin")]
    public class DashBoardController : Controller
    {
        private readonly ILogger<DashBoardController> _logger;

        public DashBoardController(ILogger<DashBoardController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
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