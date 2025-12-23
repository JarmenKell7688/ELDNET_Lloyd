using System.Security.Claims;
using ELDNET_Lloyd.Data;
using ELDNET_Lloyd.Models;
using Microsoft.AspNetCore.Mvc;

namespace ELDNET_Lloyd.Controllers.StudentPanel
{
    public class ActivityController : Controller
    {
        private readonly ApplicationDbContext _context;

        public ActivityController(ApplicationDbContext context)
        {
            _context = context;
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Submit(Activity model)
        {
            if (!ModelState.IsValid)
            {
                return View("~/Views/StudentPanel/Activity.cshtml", model);
            }
            int currentUserId = int.Parse(User.FindFirst(ClaimTypes.NameIdentifier).Value);
            model.StudentId = currentUserId;

            // Save to database
            _context.Activities.Add(model);
            await _context.SaveChangesAsync();

            TempData["AlertStyle"] = "alert-success";
            TempData["Message"] = "Activity Area Reservation successfully submitted!";
            return RedirectToAction("Activity", "StudentPanel");
        }
    }
}
