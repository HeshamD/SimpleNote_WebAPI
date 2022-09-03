using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleNote_WebAPI.Services.ServicesImp
{
    public class ProjectsServicesImp : GenericServicesImp<ProjectsDto,ProjectsEntity>, IProjectsServices
    {
        private readonly IProjectsRepo projectsRepo;
        public ProjectsServicesImp(IGenericRepo<ProjectsEntity> baseRepository, IProjectsRepo _projectsRepo, IMapper mapper) : base(baseRepository, mapper)
        {
            projectsRepo = _projectsRepo;
        }

        public Task<int> GetNullProjectNoteCounts()
        {
            return projectsRepo.GetNullProjectNoteCounts();
        }

        public Task<int> GetProjectNoteCounts()
        {
            return projectsRepo.GetProjectNoteCounts();
        }
    }
}
