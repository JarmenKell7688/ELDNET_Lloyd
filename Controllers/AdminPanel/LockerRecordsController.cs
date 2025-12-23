using ELDNET_Lloyd.Data;
using Microsoft.AspNetCore.Mvc;

namespace ELDNET_Lloyd.Controllers.AdminPanel
{
    public class LockerRecordsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public LockerRecordsController(ApplicationDbContext context)
        {
            _context = context;
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Delete(int id)
        {
            // Find the record by Id
            var locker = await _context.Lockers.FindAsync(id);
            if (locker != null)
            {
                // Remove it from the DbSet
                _context.Lockers.Remove(locker);

                // Save changes to the database
                await _context.SaveChangesAsync();

                TempData["AlertStyle"] = "alert-success";
                TempData["Message"] = "Locker record deleted successfully!";
            }
            else
            {
                TempData["AlertStyle"] = "alert-danger";
                TempData["Message"] = "Record not found.";
            }

            return RedirectToAction("LockerRecords", "AdminPanel");
        }
    }
}
