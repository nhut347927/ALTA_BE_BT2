using System.Security.Claims;
using ALTA_BE_BT2.Models;
using ALTA_BE_BT2.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ALTA_BE_BT2.Controllers
{
    [Authorize]
    public class InternController : Controller
    {
        private readonly IInternService _internService;

        public InternController(IInternService internService)
        {
            _internService = internService;
        }

        public IActionResult Index()
        {
            return View();
        }

        public async Task<IActionResult> GetInternsJson()
        {
            var userId = int.Parse(User.FindFirst(ClaimTypes.NameIdentifier)?.Value);
            var interns = await _internService.GetInternsForUserAsync(userId);
            return Json(interns);
        }

        public IActionResult Create()
        {
            return View(new Intern());
        }

        [HttpPost]
        public async Task<IActionResult> Create(Intern intern)
        {
            await _internService.AddInternAsync(intern);
            return RedirectToAction(nameof(Index));
        }
    }
}