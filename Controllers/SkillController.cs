using Microsoft.AspNetCore.Mvc;
using SQ20.Net_Wee7_8_Task.Interfaces;
using SQ20.Net_Wee7_8_Task.Models;
using SQ20.Net_Wee7_8_Task.Repository;
using SQ20.Net_Wee7_8_Task.ViewModels;

namespace SQ20.Net_Wee7_8_Task.Controllers
{
    public class SkillController : Controller
    {
        private readonly ISkillRepository _skillRepository;
        private readonly IPhotoService _photoService;
        
        public SkillController(ISkillRepository skillRepository, IPhotoService photoService)
        {
            _skillRepository = skillRepository;
            _photoService = photoService;
           
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var skills = await _skillRepository.GetAll();
            return View(skills);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(CreateSkillViewModel skillVm)
        {

            if (ModelState.IsValid)
            {
               /* var result = await _photoService.AddPhotoAsync(projectVm.Image);*/

                var skill = new Skill()
                {
                    Name = skillVm.Name,
                    Description = skillVm.Description
                    /* Image = result.Url.ToString(),*/
                };

                _skillRepository.Add(skill);
                return RedirectToAction("Index");

            }
            else
            {
                ModelState.AddModelError("", "Photo Upload Failed");
            }

            return View(skillVm);
        }

        [HttpGet]
        public async Task<IActionResult> Edit(Guid Id)
        {
            var skill = await _skillRepository.GetByIdAsync(Id);
            if (skill == null) return View("Error");
            var skillVM = new EditSkillViewModel()
            {
                Name = skill.Name,
                Description = skill.Description

            };

            return View(skillVM);
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
