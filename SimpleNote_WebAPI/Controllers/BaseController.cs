

namespace SimpleNote_WebAPI.Controllers
{
    public class BaseController : ControllerBase
    {
        protected readonly IProjectsRepo _repoImp;
        protected readonly INotesServices _notesServices;
        protected readonly INotesRepo _noteRepo;
        protected readonly IMapper mapper;

        public BaseController(IProjectsRepo repoImp, INotesServices notesServices, INotesRepo noteRepo, IMapper _mapper)
        {
            _noteRepo = noteRepo;
            _repoImp = repoImp;
            _notesServices = notesServices;
            mapper = _mapper;
        }

        protected UsersDto GetCurrentUser()
        {
            var identity = HttpContext.User.Identity as ClaimsIdentity;
            if (identity != null)
            {
                var userClaims = identity.Claims;

                return new UsersDto
                {
                    UserName = userClaims.FirstOrDefault(u => u.Type == ClaimTypes.NameIdentifier)?.Value,
                };
            }

            return null;
        }
    }
}
