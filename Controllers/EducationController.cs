using Microsoft.AspNetCore.Mvc;
using SQ20.Net_Wee7_8_Task.Interfaces;
using SQ20.Net_Wee7_8_Task.Models;
using SQ20.Net_Wee7_8_Task.ViewModels;

namespace SQ20.Net_Wee7_8_Task.Controllers
{
    public class EducationController : Controller
    {
        private readonly IEducationRepository _edRepository;
        private readonly IPhotoService _photoService;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public EducationController(IEducationRepository edRepository, IPhotoService photoService, IHttpContextAccessor httpContextAccessor)
        {
            _edRepository = edRepository;
            _photoService = photoService;
            _httpContextAccessor = httpContextAccessor;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var educations = await _edRepository.GetAll();
            return View(educations);
        }

        public async Task<IActionResult> Edit(Guid Id)
        {
            var educate = await _edRepository.GetByIdAsync(Id);
            if (educate == null) return View("Error");
            var edVm = new EditEducationViewModel()
            {
                Degree = educate.Degree,
                School = educate.School,
                GraduationDate = educate.GraduationDate,

            };

            return View(edVm);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(Guid Id, EditEducationViewModel edVm)
        {
            if (!ModelState.IsValid)
            {
                ModelState.AddModelError("", "Failed To Edit ED");
                View("Edit", edVm);
            }

            var educations = new Education()
            {
                Id = Id,
                School = edVm.School,
                Degree = edVm.Degree,
                GraduationDate = edVm.GraduationDate
            

            };

            _edRepository.Update(educations);
            return RedirectToAction("Index");

        }
    }
}
