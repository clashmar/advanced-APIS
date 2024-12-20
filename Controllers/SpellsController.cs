using advanced_APIS.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.RateLimiting;

namespace advanced_APIS.Controllers
{
    [ApiController]
    [Route("[controller]")]
    
    public class SpellsController : ControllerBase
    {
        private readonly WizardsService _wizardsService;

        public SpellsController(WizardsService wizardsService)
        {
            _wizardsService = wizardsService;
        }

        [HttpGet]
        public IActionResult GetAllSpells()
        {
            var allSpells = _wizardsService.GetSpells();
            return Ok(allSpells);
        }

        [HttpGet("random")]
        [EnableRateLimiting("fixed")]
        public IActionResult GetRandomSpell()
        {
            var randomSPell = _wizardsService.GetRandomSpell();
            return Ok(randomSPell);
        }

    }
}
