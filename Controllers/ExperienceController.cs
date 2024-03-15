using Microsoft.AspNetCore.Mvc;
using SQ20.Net_Wee7_8_Task.Interfaces;
using SQ20.Net_Wee7_8_Task.Models;
using SQ20.Net_Wee7_8_Task.ViewModels;

namespace SQ20.Net_Wee7_8_Task.Controllers
{
    public class ExperienceController : Controller
    {
        private readonly IExperienceRepository _expRepository;
        private readonly IPhotoService _photoService;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public ExperienceController(IExperienceRepository expRepository, IPhotoService photoService, IHttpContextAccessor httpContextAccessor)
        {
            _expRepository = expRepository;
            _photoService = photoService;
            _httpContextAccessor = httpContextAccessor;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var exps = await _expRepository.GetAll();
            return View(exps);
        }

        public async Task<IActionResult> Edit(Guid Id)
        {
            var exp = await _expRepository.GetByIdAsync(Id);
            if (exp == null) return View("Error");
            var expVm = new EditExperienceViewModel()
            {
                Company = exp.Company,
                Description = exp.Description

            };

            return View(expVm);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(Guid Id, EditExperienceViewModel expVm)
        {
            if (!ModelState.IsValid)
            {
                ModelState.AddModelError("", "Failed To Edit About");
                View("Edit", expVm);
            }

            var exp = new Experience()
            {
                Id = Id,
                Company = expVm.Company,
                Description = expVm.Description,
               

            };

            _expRepository.Update(exp);
            return RedirectToAction("Index");

        }
    }
}
