using ALTA_BE_BT2.Services;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Security.Claims;
using System.Threading.Tasks;

namespace ALTA_BE_BT2.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class InternAPIController : ControllerBase
    {
        private readonly IInternService _internService;

        public InternAPIController(IInternService internService)
        {
            _internService = internService;
        }

        // API to retrieve the list of interns
        [HttpGet]
        public async Task<IActionResult> GetAllInternsAsync()
        {
            try
            {
                // Get User ID from claims
                var userIdClaim = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
                if (string.IsNullOrEmpty(userIdClaim))
                {
                    return Unauthorized("User ID not found. Please log in.");
                }

                if (!int.TryParse(userIdClaim, out int userId))
                {
                    return BadRequest("Invalid User ID.");
                }

                // Retrieve interns list
                var interns = await _internService.GetInternsForUserAsync(userId);
                
                // Check if the list is empty
                if (interns == null || interns.Count() == 0)
                {
                    return NotFound("No interns found.");
                }

                return Ok(interns); // Return interns list
            }
            catch (System.Exception ex)
            {
                return StatusCode(500, $"Server error: {ex.Message}");
            }
        }
    }
}
