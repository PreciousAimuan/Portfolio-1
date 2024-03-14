using Microsoft.AspNetCore.Mvc;
using SQ20.Net_Wee7_8_Task.Data;
using SQ20.Net_Wee7_8_Task.Interfaces;
using SQ20.Net_Wee7_8_Task.Models;
using SQ20.Net_Wee7_8_Task.Repository;
using SQ20.Net_Wee7_8_Task.Services;
using SQ20.Net_Wee7_8_Task.ViewModels;

namespace SQ20.Net_Wee7_8_Task.Controllers
{
    public class AboutsController : Controller
    {
        private readonly IAboutRepository _aboutRepository;
        private readonly IPhotoService _photoService;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public AboutsController(IAboutRepository aboutRepository, IPhotoService photoService, IHttpContextAccessor httpContextAccessor)
        {
            _aboutRepository = aboutRepository;
            _photoService = photoService;
            _httpContextAccessor = httpContextAccessor;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var abouts = await _aboutRepository.GetAll();
            return View(abouts);
        }

        public async Task<IActionResult> Edit(Guid Id)
        {
            var abouts = await _aboutRepository.GetByIdAsync(Id);
            if (abouts == null) return View("Error");
            var aboutVm = new EditAboutViewModel()
            {
                Name = abouts.Name,
                Description = abouts.Description

            };

            return View(aboutVm);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(Guid Id, EditAboutViewModel aboutVm)
        {
            if (!ModelState.IsValid)
            {
                ModelState.AddModelError("", "Failed To Edit About");
                View("Edit", aboutVm);
            }
            // TO BE USED LATER ON
            /*var result = await _photoService.AddPhotoAsync(aboutVm.Image);*/

            /*if (result.Error != null)
            {
                ModelState.AddModelError("Img", "Photo Failed To UPLOAD");
                return View("Edit", aboutVm);
            }*/

            var abouts = new About()
            {
                Id = Id,
                Name = aboutVm.Name,
                Description = aboutVm.Description,
                /*Image = result.Url.ToString(),*/

            };

            _aboutRepository.Update(abouts);
            return RedirectToAction("Index");

        }

    }

}



