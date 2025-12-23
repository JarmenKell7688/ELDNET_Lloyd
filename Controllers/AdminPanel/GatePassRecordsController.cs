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
        public async Task<IActionResult> Approve(int id)
        {
            var gatePass = await _context.GatePasses.FindAsync(id);
            if (gatePass != null)
            {
                gatePass.Status = "Approved";
                _context.GatePasses.Update(gatePass);
                await _context.SaveChangesAsync();

                TempData["AlertStyle"] = "alert-success";
                TempData["Message"] = "Gate Pass request approved successfully!";
            }
            else
            {
                TempData["AlertStyle"] = "alert-danger";
                TempData["Message"] = "Record not found.";
            }

            return RedirectToAction("GatePassRecords", "AdminPanel");
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Deny(int id)
        {
            var gatePass = await _context.GatePasses.FindAsync(id);
            if (gatePass != null)
            {
                gatePass.Status = "Denied";
                _context.GatePasses.Update(gatePass);
                await _context.SaveChangesAsync();

                TempData["AlertStyle"] = "alert-warning";
                TempData["Message"] = "Gate Pass request denied.";
            }
            else
            {
                TempData["AlertStyle"] = "alert-danger";
                TempData["Message"] = "Record not found.";
            }

            return RedirectToAction("GatePassRecords", "AdminPanel");
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Delete(int id)
        {
            var gatePass = await _context.GatePasses.FindAsync(id);
            if (gatePass != null)
            {
                _context.GatePasses.Remove(gatePass);
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