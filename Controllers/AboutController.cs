using Microsoft.AspNetCore.Mvc;
using SQ20.Net_Wee7_8_Task.Data;
using SQ20.Net_Wee7_8_Task.Interfaces;
using SQ20.Net_Wee7_8_Task.Models;
using SQ20.Net_Wee7_8_Task.Repository;
using SQ20.Net_Wee7_8_Task.Services;

namespace SQ20.Net_Wee7_8_Task.Controllers
{
    public class AboutsController : Controller
    {
        private readonly AboutRepository _aboutRepository;
        private readonly IPhotoService _photoService;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public AboutsController(AboutRepository aboutRepository, IPhotoService photoService, IHttpContextAccessor httpContextAccessor)
        {
            _aboutRepository = aboutRepository;
            _photoService = photoService;
            _httpContextAccessor = httpContextAccessor;
        }

        public async Task<IActionResult> Index()
        {
            var abouts = await _aboutRepository.GetAll();
            return View(abouts);
        }


    }

}



