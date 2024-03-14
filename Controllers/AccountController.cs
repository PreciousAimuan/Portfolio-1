using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using SQ20.Net_Wee7_8_Task.Models;
using SQ20.Net_Wee7_8_Task.ViewModels;

namespace SQ20.Net_Wee7_8_Task.Controllers
{
    public class AccountController : Controller
    {
        //these are 2 dependencies from identity to perform dependency inversion with our constructor
        private readonly UserManager<AppUser> _userManager;
        private readonly SignInManager<AppUser> _signInManager;

        public AccountController(UserManager<AppUser> userManager, SignInManager<AppUser> signInManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;
        }

        [HttpGet]
        public IActionResult Login()
        {
            var response = new LoginViewModel();
            return View(response);
        }

        [HttpPost]
        public async Task<IActionResult> Login(LoginViewModel loginVm)
        {
            // var response = new LoginViewModel();
            //validation
            if (!ModelState.IsValid) return View(loginVm);
            // return View();


            var user = await _userManager.FindByEmailAsync(loginVm.EmailAddress);
            if (user != null)
            {
                //user password check
                var passwordCheck = await _userManager.CheckPasswordAsync(user, loginVm.Password);
                if (passwordCheck)
                {
                    //password correct,then sign in
                    var result = await _signInManager.PasswordSignInAsync(user, loginVm.Password, false, false);
                    if (result.Succeeded)
                    {
                        return RedirectToAction("Index", "DashBoard");
                    }

                }

                TempData["Error"] = "wrong credential pls try again";
            }

            TempData["Error"] = "You are not a registered user, try again";

            return View(loginVm);

        }

        public async Task<IActionResult> Logout()
        {
            await _signInManager.SignOutAsync();
            return RedirectToAction("index", "Home");
        }
    }
}
