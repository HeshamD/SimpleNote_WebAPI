using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleNote_WebAPI.Infrastructure.IRepositories
{
    public interface IProjectsRepo:IGenericRepo<ProjectsEntity>
    {
        public Task<int> GetProjectNoteCounts();
        public Task<int> GetNullProjectNoteCounts();
    }
}
