using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleNote_WebAPI.Services.IServices
{
    public interface IProjectsServices: IGenericServices<ProjectsDto,ProjectsEntity>
    {
        public Task<int> GetProjectNoteCounts();
        public Task<int> GetNullProjectNoteCounts();
    }
}
