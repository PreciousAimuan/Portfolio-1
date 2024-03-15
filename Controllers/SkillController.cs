using Microsoft.AspNetCore.Mvc;
using SQ20.Net_Wee7_8_Task.Interfaces;
using SQ20.Net_Wee7_8_Task.Models;
using SQ20.Net_Wee7_8_Task.ViewModels;

namespace SQ20.Net_Wee7_8_Task.Controllers
{
    public class SkillController : Controller
    {
        private readonly ISkillRepository _skillRepository;
        private readonly IPhotoService _photoService;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public SkillController(ISkillRepository skillRepository, IPhotoService photoService, IHttpContextAccessor httpContextAccessor)
        {
            _skillRepository = skillRepository;
            _photoService = photoService;
            _httpContextAccessor = httpContextAccessor;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var skills = await _skillRepository.GetAll();
            return View(skills);
        }

        public async Task<IActionResult> Edit(Guid Id)
        {
            var skills = await _skillRepository.GetByIdAsync(Id);
            if (skills == null) return View("Error");
            var skillVm = new EditSkillViewModel()
            {
                Name = skills.Name,
                Description = skills.Description

            };

            return View(skillVm);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(Guid Id, EditSkillViewModel skillVm)
        {
            if (!ModelState.IsValid)
            {
                ModelState.AddModelError("", "Failed To Edit About");
                View("Edit", skillVm);
            }

            var skill = new Skill()
            {
                Id = Id,
                Name = skillVm.Name,
                Description = skillVm.Description,
                /*Image = result.Url.ToString(),*/

            };

            _skillRepository.Update(skill);
            return RedirectToAction("Index");

        }
    }
}
