using advanced_APIS.Services;
using Microsoft.AspNetCore.Mvc;

namespace advanced_APIS.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class TeachersController : ControllerBase
    {
        private readonly WizardsService _wizardsService;

        public TeachersController(WizardsService wizardsService)
        {
            _wizardsService = wizardsService;
        }

        [HttpGet]
        public IActionResult GetAllTeachers()
        {
            var allSpells = _wizardsService.GetTeachers();
            return Ok(allSpells);
        }
    }
}
