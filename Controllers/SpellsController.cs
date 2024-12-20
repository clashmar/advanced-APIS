using advanced_APIS.Services;
using Microsoft.AspNetCore.Mvc;

namespace advanced_APIS.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class SpellsController : ControllerBase
    {
        private readonly SpellsService _spellsService;

        public SpellsController(SpellsService spellsService)
        {
            _spellsService = spellsService;
        }

        [HttpGet]
        public IActionResult GetAllSpells()
        {
            var allSpells = _spellsService.GetSpells();
            return Ok(allSpells);
        }
    }
}
