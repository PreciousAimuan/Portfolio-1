using Microsoft.AspNetCore.Mvc;

namespace SQ20.Net_Wee7_8_Task.Controllers
{
    public class DashboardController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
