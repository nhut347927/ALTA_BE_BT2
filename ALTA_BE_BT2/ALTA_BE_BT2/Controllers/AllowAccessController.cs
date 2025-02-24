using ALTA_BE_BT2.Models;
using ALTA_BE_BT2.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ALTA_BE_BT2.Controllers
{
    [Authorize]
    public class AllowAccessController : Controller
    {
        private readonly IAllowAccessService _allowAccessService;
        private readonly IRoleService _roleService;

        public AllowAccessController(IAllowAccessService allowAccessService, IRoleService roleService)
        {
            _allowAccessService = allowAccessService;
            _roleService = roleService;
        }

        public async Task<IActionResult> Index()
        {
            var allowAccesses = await _allowAccessService.GetAllAllowAccessesAsync();
            return View(allowAccesses);
        }

        public async Task<IActionResult> Create()
        {
            ViewBag.Roles = await _roleService.GetAllRolesAsync();
            return View();
        }

        [HttpPost]

        public async Task<IActionResult> Create(AllowAccess allowAccess)
        {

            await _allowAccessService.AddAllowAccessAsync(allowAccess);
            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> Edit(int id)
        {
            var allowAccess = await _allowAccessService.GetAllowAccessByIdAsync(id);
            if (allowAccess == null)
            {
                return NotFound();
            }
            ViewBag.Roles = await _roleService.GetAllRolesAsync();
            return View(allowAccess);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(AllowAccess allowAccess)
        {
            await _allowAccessService.UpdateAllowAccessAsync(allowAccess);
            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> Delete(int id)
        {
            var allowAccess = await _allowAccessService.GetAllowAccessByIdAsync(id);
            if (allowAccess == null)
            {
                return NotFound();
            }
            return View(allowAccess);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            await _allowAccessService.DeleteAllowAccessAsync(id);
            return RedirectToAction(nameof(Index));
        }
    }
}