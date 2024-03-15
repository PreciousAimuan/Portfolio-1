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

        public ExperienceController(IExperienceRepository expRepository, IPhotoService photoService)
        {
            _expRepository = expRepository;
            _photoService = photoService;
           
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var exps = await _expRepository.GetAll();
            return View(exps);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(CreateExperienceViewModel expVm)
        {

            if (ModelState.IsValid)
            {
                /* var result = await _photoService.AddPhotoAsync(projectVm.Image);*/

                var experience = new Experience()
                {
                    Company = expVm.Company,
                    Description = expVm.Description
                };

                _expRepository.Add(experience);
                return RedirectToAction("Index");

            }
            else
            {
                ModelState.AddModelError("", "Photo Upload Failed");
            }

            return View(expVm);
        }

        [HttpGet]
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
