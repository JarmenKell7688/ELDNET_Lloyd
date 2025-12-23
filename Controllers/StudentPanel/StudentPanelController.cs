using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ELDNET_Lloyd.Controllers.StudentPanel
{
    [Authorize(Roles = "Student")]
    public class StudentPanelController : Controller
    {
        [HttpGet]
        public IActionResult Home()
        {
            return View();
        }

        [HttpGet]
        public IActionResult GatePass()
        {
            return View();
        }

        [HttpGet]
        public IActionResult Locker()
        {
            return View();
        }

        [HttpGet]
        public IActionResult Activity()
        {
            return View();
        }
    }
}
