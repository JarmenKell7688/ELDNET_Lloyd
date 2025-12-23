using System.Security.Claims;
using ELDNET_Lloyd.Data;
using ELDNET_Lloyd.Models;
using Microsoft.AspNetCore.Mvc;

namespace ELDNET_Lloyd.Controllers.StudentPanel
{
    public class GatePassController : Controller
    {
        private readonly ApplicationDbContext _context;

        public GatePassController(ApplicationDbContext context)
        {
            _context = context;
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Submit(GatePass model)
        {
            if (!ModelState.IsValid)
            {
                return View("~/Views/StudentPanel/GatePass.cshtml", model);
            }
            // Convert uploaded files to JSON
            if (model.DocumentUploadFiles != null && model.DocumentUploadFiles.Count > 0)
            {
                var fileList = new List<object>();

                foreach (var file in model.DocumentUploadFiles)
                {
                    using (var ms = new MemoryStream())
                    {
                        await file.CopyToAsync(ms);
                        var fileBytes = ms.ToArray();

                        fileList.Add(new
                        {
                            file.FileName,
                            file.ContentType,
                            Base64Data = Convert.ToBase64String(fileBytes)
                        });
                    }
                }

                // Serialize to JSON for DB storage
                model.DocumentFilesJson = System.Text.Json.JsonSerializer.Serialize(fileList);
            }
            int currentUserId = int.Parse(User.FindFirst(ClaimTypes.NameIdentifier).Value);
            model.StudentId = currentUserId;

            // Save to database
            _context.GatePasses.Add(model);
            await _context.SaveChangesAsync();

            TempData["AlertStyle"] = "alert-success";
            TempData["Message"] = "Gate Pass successfully submitted!";
            return RedirectToAction("GatePass", "StudentPanel");
        }
    }
}
