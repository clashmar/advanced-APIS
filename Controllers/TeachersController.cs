using advanced_APIS.Models;
using advanced_APIS.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.OutputCaching;
using Microsoft.AspNetCore.RateLimiting;
using Microsoft.Extensions.Caching.Memory;

namespace advanced_APIS.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class TeachersController : Controller
    {
        private readonly WizardsService _wizardsService;
        private readonly IMemoryCache _cache;
        private const string ProductCacheKey = "TeachersList";

        public TeachersController(WizardsService wizardsService, IMemoryCache memoryCache)
        {
            _wizardsService = wizardsService;
            _cache = memoryCache;
        }

        [HttpGet]
        //[OutputCache(Duration = 20)]
        public IActionResult GetAllTeachers()
        {
            List<Teacher>? allTeachers;

            if(!_cache.TryGetValue(ProductCacheKey, out allTeachers))
            {
                allTeachers = _wizardsService.GetTeachers();

                var cacheEntryOptions = new MemoryCacheEntryOptions()
                    .SetAbsoluteExpiration(TimeSpan.FromMinutes(2));

                _cache.Set(ProductCacheKey, allTeachers, cacheEntryOptions);

            }
            return Ok(allTeachers);
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
