using HouseRentingSystem.Core.Models.Agent;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace HouseRentingSystem.Controllers
{
    [Authorize]
    public class AgentControler : Controller
    {
        [HttpGet]
        public IActionResult Become()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Become(BecomeAgentModel model)
        {
            return RedirectToAction("All", "House");
        }
    }
}
