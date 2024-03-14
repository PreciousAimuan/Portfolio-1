using Microsoft.AspNetCore.Mvc;
using SQ20.Net_Wee7_8_Task.Interfaces;
using SQ20.Net_Wee7_8_Task.Models;
using SQ20.Net_Wee7_8_Task.Repository;
using SQ20.Net_Wee7_8_Task.ViewModels;

namespace SQ20.Net_Wee7_8_Task.Controllers
{
    public class ServiceController : Controller
    {
        private readonly IServiceRepository _serviceRepository;
        private readonly IPhotoService _photoService;


        public ServiceController(IServiceRepository serviceRepository, IPhotoService photoService)
        {
            _serviceRepository = serviceRepository;
            _photoService = photoService;
        }

        
        public async Task<IActionResult> Index()
        {
            var services = await _serviceRepository.GetAll();
            return View(services);
        }

        //
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(CreateServicesViewModel serviceVm)
        {
         
            if (ModelState.IsValid)
            {
                var result = await _photoService.AddPhotoAsync(serviceVm.Image);

                var service = new Service()
                {
                    Title = serviceVm.Title,
                    Description = serviceVm.Description,
                    Image = result.Url.ToString(),
                };

                _serviceRepository.Add(service);
                return RedirectToAction("Index");

            }
            else
            {
                ModelState.AddModelError("", "Photo Upload Failed");
            }

            return View(serviceVm);
        }


        //

        [HttpGet]
        public async Task<IActionResult> Edit(Guid Id)
        {
            var services = await _serviceRepository.GetByIdAsync(Id);
            if (services == null) return View("Error");
            var serviceVM = new EditServicesViewModel()
            {
                Title = services.Title,
                Description = services.Description

            };

            return View(serviceVM);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(Guid Id, EditServicesViewModel serviceVM)
        {
            if (!ModelState.IsValid)
            {
                ModelState.AddModelError("", "Failed To Edit Club");
                View("Edit", serviceVM);
            }

            var result = await _photoService.AddPhotoAsync(serviceVM.Image);

            if (result.Error != null)
            {
                ModelState.AddModelError("Img", "Photo Failed To UPLOAD");
                return View("Edit", serviceVM);
            }

            var services = new Service()
            {
                Id = Id,
                Title = serviceVM.Title,
                Description = serviceVM.Description,
                Image = result.Url.ToString(),

            };

            _serviceRepository.Update(services);
            return RedirectToAction("Index");

        }

    }
}
