using Microsoft.AspNetCore.Mvc;
using SQ20.Net_Wee7_8_Task.Interfaces;
using SQ20.Net_Wee7_8_Task.Services;
using System.Net;
using Microsoft.Build.Evaluation;
using SQ20.Net_Wee7_8_Task.Models;
using SQ20.Net_Wee7_8_Task.ViewModels;

namespace SQ20.Net_Wee7_8_Task.Controllers
{
    public class ProjectController : Controller
    {
        private readonly IProjectRepository _projectRepository;
        private readonly IPhotoService _photoService;


        public ProjectController(IProjectRepository projectRepository, IPhotoService photoService)
        {
            _projectRepository = projectRepository;
            _photoService = photoService;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var projects = await _projectRepository.GetAll();
            return View(projects);
        }

        // work in progress
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(CreatePortfolioViewModel projectVm)
        {
            
            if (ModelState.IsValid)
            {
                var result = await _photoService.AddPhotoAsync(projectVm.Image);

                var project = new Portfolio()
                {
                    Title = projectVm.Title,
                    Description = projectVm.Description,
                    Image = result.Url.ToString(),
                };

                _projectRepository.Add(project);
                return RedirectToAction("Index");

            }
            else
            {
                ModelState.AddModelError("", "Photo Upload Failed");
            }

            return View(projectVm);
        }



        //
        [HttpGet]
        public async Task<IActionResult> Edit(Guid Id)
        {
            var projects = await _projectRepository.GetByIdAsync(Id);
            if (projects == null) return View("Error");
            var projectVM = new EditProjectViewModel()
            {
                Title = projects.Title,
                Description = projects.Description

            };

            return View(projectVM);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(Guid Id, EditProjectViewModel projectVm)
        {
            if (!ModelState.IsValid)
            {
                ModelState.AddModelError("", "Failed To Edit Club");
                View("Edit", projectVm);
            }

            var result = await _photoService.AddPhotoAsync(projectVm.Image);

            if (result.Error != null)
            {
                ModelState.AddModelError("Img", "Photo Failed To UPLOAD");
                return View("Edit", projectVm);
            }

            var projects = new Portfolio()
            {
                Id = Id,
                Title = projectVm.Title,
                Description = projectVm.Description,
                Image = result.Url.ToString(),
               
            };

            _projectRepository.Update(projects);
            return RedirectToAction("Index");

        }

    }
}

