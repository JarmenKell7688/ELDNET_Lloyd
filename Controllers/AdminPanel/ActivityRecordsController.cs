using ELDNET_Lloyd.Data;
using Microsoft.AspNetCore.Mvc;

namespace ELDNET_Lloyd.Controllers.AdminPanel
{
    public class ActivityRecordsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public ActivityRecordsController(ApplicationDbContext context)
        {
            _context = context;
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Delete(int id)
        {
            // Find the record by Id
            var activity = await _context.Activities.FindAsync(id);
            if (activity != null)
            {
                // Remove it from the DbSet
                _context.Activities.Remove(activity);

                // Save changes to the database
                await _context.SaveChangesAsync();

                TempData["AlertStyle"] = "alert-success";
                TempData["Message"] = "Activity area record deleted successfully!";
            }
            else
            {
                TempData["AlertStyle"] = "alert-danger";
                TempData["Message"] = "Record not found.";
            }

            return RedirectToAction("ActivityRecords", "AdminPanel");
        }
    }
}
