using ELDNET_Lloyd.Data;
using ELDNET_Lloyd.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ELDNET_Lloyd.Controllers.AdminPanel
{
    [Authorize(Roles = "Admin")]
    public class AdminPanelController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly UserManager<Student> _userManager;

        public AdminPanelController(UserManager<Student> userManager, ApplicationDbContext context)
        {
            _context = context;
            _userManager = userManager;
        }

        [HttpGet]
        public IActionResult Home()
        {
            return View();
        }

        [HttpGet]
        public async Task<IActionResult> StudentRecords()
        {
            var students = await _context.Users.ToListAsync();

            // Only send student users
            var studentsWithoutAdmin = new List<Student>();
            foreach (var student in students)
            {
                if (!await _userManager.IsInRoleAsync(student, "Admin"))
                {
                    studentsWithoutAdmin.Add(student);
                }
            }

            return View(studentsWithoutAdmin);
        }

        [HttpGet]
        public async Task<IActionResult> GatePassRecords()
        {
            var gatePasses = await _context.GatePasses.ToListAsync();
            return View(gatePasses);
        }

        [HttpGet]
        public async Task<IActionResult> LockerRecords()
        {
            var lockers = await _context.Lockers.ToListAsync();
            return View(lockers);
        }

        [HttpGet]
        public async Task<IActionResult> ActivityRecords()
        {
            var activities = await _context.Activities.ToListAsync();
            return View(activities);
        }
    }
}
