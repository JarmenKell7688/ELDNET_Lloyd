using ELDNET_Lloyd.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ELDNET_Lloyd.Controllers.AdminPanel
{
    public class GatePassRecordsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public GatePassRecordsController(ApplicationDbContext context)
        { 
            _context = context;
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Delete(int id)
        {
            // Find the record by Id
            var gatePass = await _context.GatePasses.FindAsync(id);
            if (gatePass != null)
            {
                // Remove it from the DbSet
                _context.GatePasses.Remove(gatePass);

                // Save changes to the database
                await _context.SaveChangesAsync();

                TempData["AlertStyle"] = "alert-success";
                TempData["Message"] = "Gate Pass record deleted successfully!";
            }
            else
            {
                TempData["AlertStyle"] = "alert-danger";
                TempData["Message"] = "Record not found.";
            }

            return RedirectToAction("GatePassRecords", "AdminPanel");
        }

    }
}
