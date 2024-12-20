using advanced_APIS.Models;
using advanced_APIS.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.RateLimiting;

namespace advanced_APIS.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class TeachersController : Controller
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

        [HttpPost]
        public IActionResult AddTeacher(Teacher teacher)
        {
            if (string.IsNullOrEmpty(teacher.Name))
            {
                return BadRequest("Teacher Name must not be empty.");
            }

            var addedTeacher = _wizardsService.AddTeacher(teacher);
            return Created($"{Request.Path.Value}/{addedTeacher.Id}", addedTeacher);
        }
    }
}
