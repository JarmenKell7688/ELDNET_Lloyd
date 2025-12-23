using ELDNET_Lloyd.Data;
using Microsoft.AspNetCore.Mvc;

namespace ELDNET_Lloyd.Controllers.AdminPanel
{
    public class StudentRecordsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public StudentRecordsController(ApplicationDbContext context)
        {
            _context = context;
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Delete(int id)
        {
            // Find the record by Id
            var student = await _context.Users.FindAsync(id);
            if (student != null)
            {
                // Remove it from the DbSet
                _context.Users.Remove(student);

                // Save changes to the database
                await _context.SaveChangesAsync();

                TempData["AlertStyle"] = "alert-success";
                TempData["Message"] = "Student record deleted successfully!";
            }
            else
            {
                TempData["AlertStyle"] = "alert-danger";
                TempData["Message"] = "Record not found.";
            }

            return RedirectToAction("StudentRecords", "AdminPanel");
        }

    }
}
