




namespace SimpleNote_WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    public class NotesController : BaseController
    {
        public NotesController(IProjectsRepo repoImp, INotesServices notesServices, INotesRepo noteRepo, IMapper _mapper) : base(repoImp, notesServices, noteRepo, _mapper)
        {
        }

        [HttpGet("GetAllNotes")]
        public async Task<IActionResult> GetAllNotes()
        {
            //validate token

            var currentUser = GetCurrentUser();
            if(currentUser == null)
            {
                return StatusCode(401, "Unauthorized");
            }
            var notes = await _notesServices.GetAllAsync();
            return StatusCode(200, notes);
        }

        [HttpGet("GetNotes/project/{projectId?}")]
        [HttpGet("GetNotes/Attribute/{AttributeId?}")]
        [HttpGet("GetNotes/{projectId?}/{AttributeId?}")]
        public async Task<IActionResult> GetNotes(int? projectId=null,int? AttributeId=null)
        {
            var currentUser = GetCurrentUser();
            if (currentUser == null)
            {
                return StatusCode(401, "Unauthorized");
            }
            try
            {
                var notes_ = await _noteRepo.GetNotes(projectId, AttributeId);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
            var notes = await _noteRepo.GetNotes(projectId, AttributeId);

            return StatusCode(200,notes);
        }

        [HttpDelete("DeleteNote/{id}")]
        public async Task<IActionResult> DeleteNote(int id)
        {
            try
            {
                _noteRepo.DeleteByIdAsync(id);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }

            return StatusCode(200, "Content Deleted Successfully ");
        }

        [HttpPost("CreateNewNote")]
        public async Task<IActionResult> CreateNewNote([FromBody] NotesDto _Notedto)
        {
            if(!ModelState.IsValid)
            {
                return StatusCode(400, "Please insert a valid values");
            }

            try
            {
                var noteEntity = mapper.Map<NotesEntity>(_Notedto);

                await _noteRepo.AddAsync(noteEntity);
            }
            catch(Exception ex)
            {
                return StatusCode(500, ex.Message);
            }

            return StatusCode(201,"Created Successfully");
        }

        [HttpPut("UpdateExistingNote/{id}")]
        public async Task<IActionResult> UpdateNote([FromBody] NotesDto _Notedto,[FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return StatusCode(400, "Please insert a valid values");
            }

            try
            {
                //search by id 
                var Existednote = await _noteRepo.GetByIdAsync(id);

                if(Existednote == null)
                {
                    return StatusCode(404, $"There is no such note with that id = {id}");
                }

                Existednote.Attribute_Id_FK = _Notedto.Attribute_Id_FK;
                Existednote.Completed = _Notedto.Completed;
                Existednote.Project_ID_FK = _Notedto.Project_ID_FK;
                Existednote.User_Id_FK = _Notedto.User_Id_FK;
                Existednote.Note = _Notedto.Note;

                await _noteRepo.UpdateAsync(Existednote);
            }
            
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }

            return StatusCode(201, "Updated Successfully");

        }
    }
}
