using Microsoft.AspNetCore.Mvc;
using SQ20.Net_Wee7_8_Task.Interfaces;
using SQ20.Net_Wee7_8_Task.Models;
using SQ20.Net_Wee7_8_Task.Repository;
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

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(CreateEducationViewModel edVm)
        {

            if (ModelState.IsValid)
            {
                /* var result = await _photoService.AddPhotoAsync(projectVm.Image);*/

                var education = new Education()
                {
                    Degree = edVm.Degree,
                    School = edVm.School,
                    GraduationDate = edVm.GraduationDate,
                };

                _edRepository.Add(education);
                return RedirectToAction("Index");

            }
            else
            {
                ModelState.AddModelError("", "Photo Upload Failed");
            }

            return View(edVm);
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
