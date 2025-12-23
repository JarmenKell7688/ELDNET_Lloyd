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
        public async Task<IActionResult> Approve(int id)
        {
            var locker = await _context.Lockers.FindAsync(id);
            if (locker != null)
            {
                // Add your approval logic here
                // For example, you could add a Status field to the model
                // locker.Status = "Approved";
                // await _context.SaveChangesAsync();

                TempData["AlertStyle"] = "alert-success";
                TempData["Message"] = "Locker request approved successfully!";
            }
            else
            {
                TempData["AlertStyle"] = "alert-danger";
                TempData["Message"] = "Record not found.";
            }

            return RedirectToAction("LockerRecords", "AdminPanel");
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Deny(int id)
        {
            var locker = await _context.Lockers.FindAsync(id);
            if (locker != null)
            {
                // Add your denial logic here
                // For example, you could add a Status field to the model
                // locker.Status = "Denied";
                // await _context.SaveChangesAsync();

                TempData["AlertStyle"] = "alert-warning";
                TempData["Message"] = "Locker request denied.";
            }
            else
            {
                TempData["AlertStyle"] = "alert-danger";
                TempData["Message"] = "Record not found.";
            }

            return RedirectToAction("LockerRecords", "AdminPanel");
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Delete(int id)
        {
            var locker = await _context.Lockers.FindAsync(id);
            if (locker != null)
            {
                _context.Lockers.Remove(locker);
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