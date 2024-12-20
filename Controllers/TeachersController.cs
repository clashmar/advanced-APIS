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

        [HttpGet("{id}")]
        public IActionResult GetTeacherById(int id)
        {
            if(id < 0) { return BadRequest("Please enter a valid teacher id.");  }
            var teacher = _wizardsService.GetTeacherById(id);
            if (teacher == null) { return NotFound($"There is no teacher with the id: {id}."); }
            return Ok(teacher);
        }
    }
}
