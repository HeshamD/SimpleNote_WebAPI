using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace SimpleNote_WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]

    public class ProjectsController : BaseController
    {
        public ProjectsController(IProjectsRepo repoImp, INotesServices notesServices, INotesRepo noteRepo, IMapper _mapper) : base(repoImp, notesServices, noteRepo, _mapper)
        {
        }

        [HttpGet("GetProjectsNotesCount")]
        public async Task<IActionResult> GetProjectsNotesCount()
        {
            var count = await _repoImp.GetProjectNoteCounts();

            return StatusCode(200, count);
        }

        [HttpGet("GetNullProjectsNotesCount")]
        public async Task<IActionResult> GetNullProjectsNotesCount()
        {
            var count = await _repoImp.GetNullProjectNoteCounts();

            return StatusCode(200, count);
        }
    }
}
