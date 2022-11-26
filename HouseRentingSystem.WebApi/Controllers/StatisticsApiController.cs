using HouseRentingSystem.Core.Contracts;
using HouseRentingSystem.Core.Models.Statistic;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HouseRentingSystem.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StatisticsApiController : ControllerBase
    {
        private readonly IStatisticService statisticService;

        public StatisticsApiController(IStatisticService _statisticService)
        {
            statisticService = _statisticService;
        }
        /// <summary>
        ///     Gets statistics about number of houses and rented houses
        /// </summary>
        /// <returns>Total houses and total rents</returns>
        [HttpGet]
        [Produces("application/json")]
        [ProducesResponseType(200, Type = typeof(StatisticsServiceModel))]
        public async Task<IActionResult> GetStatistics()
        {
            var model = await statisticService.Tottal();

            return Ok(model);
        }
    }
}
