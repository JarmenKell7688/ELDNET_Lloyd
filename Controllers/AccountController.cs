using System.Security.Claims;
using ELDNET_Lloyd.Models;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace ELDNET_Lloyd.Controllers
{
    public class AccountController : Controller
    {
        private readonly UserManager<Student> _userManager;
        private readonly SignInManager<Student> _signInManager;

        public AccountController(UserManager<Student> userManager,
                                 SignInManager<Student> signInManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;
        }

        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Login(LoginViewModel model)
        {
            if (!ModelState.IsValid)
                return View(model);

            var result = await _signInManager.PasswordSignInAsync(
                model.Email, model.Password, model.RememberMe, lockoutOnFailure: false);

            if (result.Succeeded)
            {
                var user = await _userManager.FindByEmailAsync(model.Email);
                var isStudent = await _userManager.IsInRoleAsync(user, "student");

                if(isStudent)
                    return RedirectToAction("Home", "StudentPanel");
                else
                    return RedirectToAction("Home", "AdminPanel");
            }

            TempData["AlertStyle"] = "alert-danger";
            TempData["Message"] = "Invalid Login Attempt.";
            return View(model);
        }

        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Register(RegisterViewModel model)
        {
            if (!ModelState.IsValid)
                return View(model);

            // Check if email already exists
            var existingUser = await _userManager.FindByEmailAsync(model.Email);
            if (existingUser != null)
            {
                ModelState.AddModelError("Email", "Email is already registered.");
                return View(model);
            }

            var user = new Student
            {
                UserName = model.Email,
                Email = model.Email,
                FirstName = model.FirstName,
                LastName = model.LastName,
                Course = model.Course,
            };

            if (model.StudentImage != null && model.StudentImage.Length > 0)
            {
                using (var memoryStream = new MemoryStream())
                {
                    await model.StudentImage.CopyToAsync(memoryStream);
                    user.StudentImage = memoryStream.ToArray(); // save as byte[]
                }
            }

            var result = await _userManager.CreateAsync(user, model.Password);

            if (result.Succeeded)
            {
                await _userManager.AddToRoleAsync(user, "Student");
                TempData["AlertStyle"] = "alert-success";
                TempData["Message"] = "Registration successful! You can now login.";
                // Redirect to Login page
                return RedirectToAction("Login", "Account");
            }
            else
            {
                return View();
            }
        }


        [HttpGet]
        public async Task<IActionResult> GetStudentImage()
        {
            // Get the current logged-in user
            var user = await _userManager.GetUserAsync(User);

            if (user?.StudentImage == null || user.StudentImage.Length == 0)
            {
                // Return default image from wwwroot/images/profile.jpg
                var defaultPath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/images/profile.jpg");
                var defaultBytes = await System.IO.File.ReadAllBytesAsync(defaultPath);
                return File(defaultBytes, "image/jpeg");
            }

            // Return user's DB image
            return File(user.StudentImage, "image/jpeg");
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Logout()
        {
            await _signInManager.SignOutAsync();
            return RedirectToAction("Login", "Account");
        } 
    }
}
